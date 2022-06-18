using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class ConsultaVendaContatoViewModel
    {
        public int VendaContatoID { get; set; }

        public int ContatoID { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal Valor { get; set; }

     //   public ConsultaContatoViewModel Contato { get;set; }

    }
}