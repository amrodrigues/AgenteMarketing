using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class ConsultaContatoViewModel
    {
        public int ContatoID { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string DataCadastro { get; set; }
        public string email { get; set; }
        public string CPF { get; set; }
    }
}
