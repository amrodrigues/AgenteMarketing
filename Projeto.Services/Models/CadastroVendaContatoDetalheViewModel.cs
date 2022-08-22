using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class CadastroVendaContatoDetalheViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o produto.")]
         public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade.")]
        public int Quantidade { get; set; }

        public int VendaContatoId { get; set; }

        public decimal Valor { get; set; }

    }
}