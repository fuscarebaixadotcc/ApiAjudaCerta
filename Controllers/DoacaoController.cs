using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAjudaCerta.Data;
using ApiAjudaCerta.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAjudaCerta.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class DoacaoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoacaoController(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("Doar")]
        public async Task<IActionResult> Add(Doacao novaDoacao)
        {
            try
            {
                await _context.Doacao.AddAsync(novaDoacao);
                await _context.SaveChangesAsync();

                return Ok(novaDoacao.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}