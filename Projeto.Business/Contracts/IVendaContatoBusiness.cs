using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Business.Contracts
{
   public interface IVendaContatoBusiness : IBaseBusiness<VendaContato>

    {
        List<VendaContato> ConsultarTodos();

        List<VendaContato> ConsultarTodos(int id);
    }
}
