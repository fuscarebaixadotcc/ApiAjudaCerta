using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiAjudaCerta.Data;
using ApiAjudaCerta.Models;
using ApiAjudaCerta.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAjudaCerta.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PessoasController(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        private int ObterUsuarioId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
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

        [AllowAnonymous]
        [HttpPost("RegistrarPF")]
        public async Task<IActionResult> Add(Pessoa novaPessoa)
        {
            try
            {
                if(!Validacao.ValidaCPF(novaPessoa.Documento))
                    throw new Exception("CPF inválido.");
                else if(!Validacao.VerificaMaioridade(novaPessoa.DataNasc))
                    throw new Exception("O usuário precisa ser maior de idade.");


                novaPessoa.Usuario = _context.Usuario.FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());

                await _context.Pessoa.AddAsync(novaPessoa);
                await _context.SaveChangesAsync();

                return Ok(novaPessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}