using System.Collections.Generic;
using System.Linq;
using Projeto.Entities;
using Projeto.Repository.Context;
using Projeto.Repository.Persistence;

namespace Projeto.Repository
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        public List<Contato> FindByNome(string nome)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Contato
                    .Where(f => f.Nome.Contains(nome))
                    .OrderBy(f => f.Nome)
                    .ToList();
            }
        }
    }
}


