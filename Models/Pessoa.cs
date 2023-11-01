using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ApiAjudaCerta.Models.Enuns;

namespace ApiAjudaCerta.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public FisicaJuridicaEnum fisicaJuridica { get; set; }
        public string Telefone { get; set; }
        public string? Genero { get; set;}
        public DateTime DataNasc { get; set; }
        public TipoPessoaEnum Tipo { get; set; }
       // [JsonIgnore]
        public Usuario Usuario { get; set; }
        //[JsonIgnore]
        public Endereco Endereco { get; set; }
        public List<Agenda> Agendas { get; set; }
        public List<Doacao> Doacoes { get; set; }
    }
}