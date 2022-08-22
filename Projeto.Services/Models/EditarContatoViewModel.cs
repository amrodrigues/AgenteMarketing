using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class EditarContatoViewModel
    {
        public int ContatoID { get; set; }
        [Required(ErrorMessage = "Por favor, informe o nome do contato.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, selecione o sexo do contato.")]
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string DataCadastro { get; set; }
        public string email { get; set; }
        public string CPF { get; set; }

    }
}