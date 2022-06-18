using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class VendaContato
    {
        public int VendaContatoID { get; set; }

        public int ContatoID { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal Valor { get; set; }

       public Contato Contato { get; set; }

        
    }
}
