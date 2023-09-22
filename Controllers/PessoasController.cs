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
    public class PessoasController : ControllerBase
    {
        private readonly DataContext _context;

        public PessoasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Pessoa p = await _context.Pessoa
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                    
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost("RegistrarPF")]
        public async Task<IActionResult> Add(Pessoa novaPessoa)
        {
            try
            {
                if(!Validacao.ValidaCPF(novaPessoa.Documento))
                    throw new Exception("CPF inválido.");
                else if(!Validacao.VerificaMaioridade(novaPessoa.DataNasc))
                    throw new Exception("O usuário precisa ser maior de idade.");

                await _context.Pessoa.AddAsync(novaPessoa);
                await _context.SaveChangesAsync();

                return Ok(novaPessoa.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}