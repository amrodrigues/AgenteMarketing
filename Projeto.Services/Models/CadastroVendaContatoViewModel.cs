using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class CadastroVendaContatoViewModel
    {
        [Required(ErrorMessage = "Por favor, selecione o contato.")]
        public int ContatoID { get; set; }
      
        public decimal Valor { get; set; }

    }
}