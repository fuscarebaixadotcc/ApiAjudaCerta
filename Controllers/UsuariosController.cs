using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAjudaCerta.Data;
using ApiAjudaCerta.Models;
using ApiAjudaCerta.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAjudaCerta.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> UsuarioExistente(string email)
        {
            if (await _context.Usuario.AnyAsync(u => u.Email == email))
            {
                return true;
            }
            return false;
        }

        private static bool IsEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                List<Usuario> lista =  await _context.Usuario.ToListAsync();
                return Ok(lista);   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                Usuario u = await _context.Usuario.FirstOrDefaultAsync(uBusca => uBusca.Id == id);
                return Ok(u);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Add(Usuario novoUsuario)
        {
            try
            {
                if (!IsEmail(novoUsuario.Email))
                {
                    throw new Exception("Endereço de e-mail inválido.");
                }
                else if (await UsuarioExistente(novoUsuario.Email))
                {
                    throw new System.Exception("Este e-mail já está cadastrado.");
                }
                else if (novoUsuario.Senha.Length < 8)
                {
                    throw new Exception("A senha requer 8 caracteres ou mais.");
                }
                Criptografia.CriarPasswordHash(novoUsuario.Senha, out byte[] hash, out byte[] salt);
                novoUsuario.Senha = string.Empty;
                novoUsuario.Senha_Hash = hash;
                novoUsuario.Senha_Salt = salt;
                await _context.Usuario.AddAsync(novoUsuario);
                await _context.SaveChangesAsync();

                return Ok(novoUsuario.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuario
                    .FirstOrDefaultAsync(u => u.Email == credenciais.Email);
                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia
                    .VerificarPasswordHash(credenciais.Senha, usuario.Senha_Hash, usuario.Senha_Salt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    return Ok("Usuário de id: " + usuario.Id + " foi autenticado com sucesso.");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar(Usuario atualizarUsuario)
        {
            try
            {
                _context.Usuario.Update(atualizarUsuario);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
               {
                return BadRequest(ex.Message);
            }
        } 

        [HttpDelete(("{id}"))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Usuario u = await _context.Usuario.FirstOrDefaultAsync(uBusca => uBusca.Id == id);

                _context.Usuario.Remove(u);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}