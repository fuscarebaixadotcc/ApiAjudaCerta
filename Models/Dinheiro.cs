using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAjudaCerta.Models
{
    public class Dinheiro
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public List<Doacao> Doacoes { get; set; }
    }
}