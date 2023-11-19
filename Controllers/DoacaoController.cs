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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Doacao> lista = await _context.Doacao.ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarConcluidas")]
        public async Task<IActionResult> ListarDoacoesConcluidas()
        {
            try
            {
                List<Doacao> lista = await _context.Doacao
                .Where(d => d.StatusDoacao == StatusDoacaoEnum.CONCLUIDO)
                .ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarPendentes")]
        public async Task<IActionResult> ListarDoacoesPendentes()
        {
            try
            {
                List<Doacao> lista = await _context.Doacao
                .Where(d => d.StatusDoacao == StatusDoacaoEnum.PENDENTE)
                .ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("ListarCancelados")]
        public async Task<IActionResult> ListarDoacoesCanceladas()
        {
            try
            {
                List<Doacao> lista = await _context.Doacao
                .Where(d => d.StatusDoacao == StatusDoacaoEnum.CANCELADO)
                .ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarIndisponiveis")]
        public async Task<IActionResult> ListarDoacoesIndisponiveis()
        {
            try
            {
                List<Doacao> lista = await _context.Doacao
                .Where(d => d.StatusDoacao == StatusDoacaoEnum.INDISPONIVEL)
                .ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpPost("DoacaoDinheiro")]
        public async Task<IActionResult> DoarDinheiro(Doacao novaDoacao)
        {
            try
            {
                if (novaDoacao.Agenda.Data < DateTime.Now)
                    throw new Exception("Não é possível agendar doações em datas inválidas.");

                Usuario uDoador = _context.Usuario.FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());
                novaDoacao.Pessoa = _context.Pessoa.FirstOrDefault(pBusca => pBusca.Usuario.Id == uDoador.Id);

                if (novaDoacao.Dinheiro <= 0)
                    throw new Exception("Deve inserir um valor para realizar a doação");
                
                await _context.Doacao.AddAsync(novaDoacao);
                await _context.SaveChangesAsync();

                return Ok(novaDoacao.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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
                            
                            if(novoItemDoacaoDoado.Doacao.Pessoa.Tipo == TipoPessoaEnum.BENEFICIARIO)
                                lista.FirstOrDefault(produto).StatusItem = StatusItemEnum.INDISPONIVEL;
                            else
                                lista.FirstOrDefault(produto).StatusItem = StatusItemEnum.DISPONIVEL;
                        }
                    }
                    else if(novoItemDoacaoDoado.ItemDoacao.TipoItem == TipoItemEnum.MOBILIA)
                    {
                        List<Mobilia> lista = novoItemDoacaoDoado.ItemDoacao.Mobilias;
                        foreach (Mobilia m in lista)
                        {
                            if(novoItemDoacaoDoado.Doacao.Pessoa.Tipo == TipoPessoaEnum.BENEFICIARIO)
                                lista.FirstOrDefault(m).StatusItem = StatusItemEnum.INDISPONIVEL;
                            else
                                lista.FirstOrDefault(m).StatusItem = StatusItemEnum.DISPONIVEL;
                        }
                    }
                    else if(novoItemDoacaoDoado.ItemDoacao.TipoItem == TipoItemEnum.ROUPA)
                    {
                        List<Roupa> lista = novoItemDoacaoDoado.ItemDoacao.Roupas;
                        foreach (Roupa r in lista)
                        {
                            if(novoItemDoacaoDoado.Doacao.Pessoa.Tipo == TipoPessoaEnum.BENEFICIARIO)
                                lista.FirstOrDefault(r).StatusItem = StatusItemEnum.INDISPONIVEL;
                            else
                                lista.FirstOrDefault(r).StatusItem = StatusItemEnum.DISPONIVEL;
                        }
                    }
                    else if(novoItemDoacaoDoado.ItemDoacao.TipoItem == TipoItemEnum.ELETRODOMESTICO)
                    {
                        List<Eletrodomestico> lista = novoItemDoacaoDoado.ItemDoacao.Eletrodomesticos;
                        foreach (Eletrodomestico e in lista)
                        {
                            if(novoItemDoacaoDoado.Doacao.Pessoa.Tipo == TipoPessoaEnum.BENEFICIARIO)
                                lista.FirstOrDefault(e).StatusItem = StatusItemEnum.INDISPONIVEL;
                            else
                                lista.FirstOrDefault(e).StatusItem = StatusItemEnum.DISPONIVEL;
                        }
                    }
                        

                    await _context.ItemDoacaoDoado.AddAsync(novoItemDoacaoDoado);
                    await _context.SaveChangesAsync();

                    return Ok(novoItemDoacaoDoado.Doacao.Id);
                }
                else
                    throw new Exception("Nenhum item foi registrado.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CancelarDoacao")]
        public async Task<IActionResult> CancelarDoacao(Doacao d)
        {
            try
            {
                Doacao doacao = await _context.Doacao //Busca o usuário no banco através do Id
                .FirstOrDefaultAsync(x => x.Id == d.Id);
                doacao.StatusDoacao = d.StatusDoacao;
                var attach = _context.Attach(doacao);
                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.StatusDoacao).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarDoacao")]
        public async Task<IActionResult> AtualizarDoacao(Doacao d)
        {
            try
            {
                Doacao doacao = await _context.Doacao //Busca o usuário no banco através do Id
                .FirstOrDefaultAsync(x => x.Id == d.Id);
                doacao.StatusDoacao = d.StatusDoacao;
                var attach = _context.Attach(doacao);
                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.StatusDoacao).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}