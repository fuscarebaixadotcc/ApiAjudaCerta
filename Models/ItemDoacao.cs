using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAjudaCerta.Models
{
    public class ItemDoacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Eletrodomestico> Eletrodomesticos { get; set; }
        public List<Mobilia> Mobilias { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<Roupa> Roupas { get; set; }
        public List<ItemDoacaoDoado> ItemDoacaoDoados { get; set; }
    }
}