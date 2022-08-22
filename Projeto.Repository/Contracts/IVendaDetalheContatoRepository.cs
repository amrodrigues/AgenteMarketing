using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository.Contracts
{
    public interface IVendaDetalheContatoRepository : IBaseRepository<VendaDetalheContato>
    {
        List<VendaDetalheContato> FindAll(int id);
    }
}
