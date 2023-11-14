using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiAjudaCerta.Data;
using ApiAjudaCerta.Models;
using ApiAjudaCerta.Models.Enuns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        private int ObterUsuarioId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public DoacaoController(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetByUser()
        {
            try
            {
                Usuario u = _context.Usuario.FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());
                Pessoa p = _context.Pessoa.FirstOrDefault(pBusca => pBusca.Usuario.Id == u.Id);
                if (p == null)
                    throw new Exception("Não existe cadastro com este id.");

                List<Doacao> lista = await _context.Doacao.Where(d => d.Pessoa.Id == p.Id).ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // [HttpPost("DoacaoDinheiro")]
        // public async Task<IActionResult> DoarDinheiro(Doacao novaDoacao)
        // {
        //     try
        //     {
        //         if (novaDoacao.Agenda.Data < DateTime.Now)
        //             throw new Exception("Não é possível agendar doações em datas inválidas.");

        //         Usuario uDoador = _context.Usuario.FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());
        //         novaDoacao.Pessoa = _context.Pessoa.FirstOrDefault(pBusca => pBusca.Usuario.Id == uDoador.Id);

        //         if (novaDoacao.Dinheiro != null)
        //         {
        //             if(novaDoacao.Dinheiro.Valor <= 0)
        //                 throw new Exception("Não se pode registrar doações sem valor.");

                    
        //         }

        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

        [HttpPost("DoacaoItens")]
        public async Task<IActionResult> DoarItens(ItemDoacaoDoado novoItemDoacaoDoado)
        {
            try
            {
                if (novoItemDoacaoDoado.Doacao.Agenda.Data < DateTime.Now)
                    throw new Exception("Não é possível agendar doações em datas inválidas.");

                Usuario uDoador = _context.Usuario.FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());
                novoItemDoacaoDoado.Doacao.Pessoa = _context.Pessoa.FirstOrDefault(pBusca => pBusca.Usuario.Id == uDoador.Id);

                if (novoItemDoacaoDoado.ItemDoacao != null)
                {
                    if (novoItemDoacaoDoado.ItemDoacao.TipoItem == TipoItemEnum.PRODUTO)
                    {
                        // Produto produto = novoItemDoacaoDoado.ItemDoacao.Produtos.FirstOrDefault();
                        List<Produto> lista = novoItemDoacaoDoado.ItemDoacao.Produtos;
                        foreach (Produto produto in lista)
                        {
                            if (produto.Validade <= DateTime.Now)
                                throw new Exception("O produto deve ter uma data de validade superior ao dia de hoje."); // ou exception
                        }
                    }
                    // else if(novoItemDoacaoDoado.ItemDoacao.TipoItem == TipoItemEnum.MOBILIA)
                    // {
                    //     Mobilia mobilia = novoItemDoacaoDoado.ItemDoacao.Mobilias.FirstOrDefault();
                    // }
                    // else if(novoItemDoacaoDoado.ItemDoacao.TipoItem == TipoItemEnum.ROUPA)
                    // {

                    // }
                    // else if(novoItemDoacaoDoado.ItemDoacao.TipoItem == TipoItemEnum.ELETRODOMESTICO)
                    // {

                    // }

                    await _context.ItemDoacaoDoado.AddAsync(novoItemDoacaoDoado);
                    await _context.SaveChangesAsync();

                    return Ok();
                }
                else
                    throw new Exception("Nenhum item foi registrado.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}