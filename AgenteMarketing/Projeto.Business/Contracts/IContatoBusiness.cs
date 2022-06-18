using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Business
{
    public interface IContatoBusiness : IBaseBusiness<Contato>
    {
        List<Contato> ConsultaPorNome(string nome);
        List<Contato> ConsultarTodos();
    }
}