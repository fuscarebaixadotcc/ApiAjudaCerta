using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAjudaCerta.Models
{
    public class Eletrodomestico
    {
        public int Id { get; set; }
        public string Medida { get; set; }
        public string Condicao { get; set; }
        public ItemDoacao ItemDoacao { get; set; }
    }
}