using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Business.Contracts
{
    public interface IVendaDetalheContatoBusiness : IBaseBusiness<VendaDetalheContato>
    {
        List<VendaDetalheContato> ConsultarTodos();

        List<VendaDetalheContato> ConsultarTodos(int id);
    }
}
