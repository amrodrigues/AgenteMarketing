using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Repository
{
   public interface IContatoRepository : IBaseRepository<Contato>
    {
        List<Contato> FindByNome(string nome);
    }
}


