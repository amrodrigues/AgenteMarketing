using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Business.Contracts
{
  public  interface IProdutoBusiness : IBaseBusiness<Produto>
    {
        List<Produto> ConsultaPorNome(string nome);
        List<Produto> ConsultarTodos();
    }
}
