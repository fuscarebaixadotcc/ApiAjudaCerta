using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAjudaCerta.Data;
using ApiAjudaCerta.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAjudaCerta.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class EnderecosController : ControllerBase
    {
        private readonly DataContext _context;

        public EnderecosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Endereco e = await _context.Endereco
                    .FirstOrDefaultAsync(eBusca => eBusca.Id == id);
                
                return Ok(e);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Post(Endereco novoEndereco)
        {
            try
            {
                await _context.Endereco.AddAsync(novoEndereco);
                await _context.SaveChangesAsync();

                return Ok(novoEndereco.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}