using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAjudaCerta.Models.Enuns;

namespace ApiAjudaCerta.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public DateTime Validade { get; set; }
        public TipoProdutoEnum TipoProduto { get; set; }
        public StatusItemEnum StatusItem { get; set; }
        public ItemDoacao ItemDoacao { get; set; }
    }
}