using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class ConsultaVendaDetalheContatoViewModel
    {
        public int VendaDetalheContatoid { get; set; }
        public int VendaContatoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

        public ConsultaProdutoViewModel Produto { get; set; }

    }
}