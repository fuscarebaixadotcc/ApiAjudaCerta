using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ApiAjudaCerta.Models.Enuns;

namespace ApiAjudaCerta.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string? Genero { get; set;}
        public DateTime DataNasc { get; set; }
        public TipoPessoaEnum Tipo { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        [ForeignKey("EnderecoId")]
        public Endereco Endereco { get; set; }
        public List<Agenda> Agendas { get; set; }
        public List<Doacao> Doacoes { get; set; }
    }
}