using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class VendaDetalheContato
    {
        public int VendaDetalheContatoid { get; set; }
        public int VendaContatoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

        public  Produto Produto { get; set; }

        public VendaContato VendaContato { get; set; }

    }
}
