using Projeto.Entities;
using Projeto.Repository.Context;
using Projeto.Repository.Contracts;
using Projeto.Repository.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Projeto.Repository.Percistence
{
    public class VendaContatoRepository : BaseRepository<VendaContato>, IVendaContatoRepository
    {
        public List<VendaContato> FindAll(int id)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.VendaContato
                     .Where(d => (d.ContatoID == id))
                    .ToList();
            }
        }
    }
}
