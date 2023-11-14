using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ApiAjudaCerta.Models.Enuns;

namespace ApiAjudaCerta.Models
{
    public class Agenda
    {
        public int Id { get; set; }     
        public DateTime Data { get; set; }
        public StatusDoacaoEnum Status { get; set; }
        public Pessoa Pessoa { get; set; }
        public Endereco Endereco { get; set; }
        public Doacao Doacao { get; set; }
    }
}