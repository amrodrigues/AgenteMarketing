
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
   public class VendaDetalheContatoRepository : BaseRepository<VendaDetalheContato>, IVendaDetalheContatoRepository
    {
        //public override List<VendaDetalheContato> FindAll()
        //{
        //    using (DataContext ctx = new DataContext())
        //    {
        //        return ctx.VendaDetalheContato
        //            .Include(d => d.Produto)
        //            .ToList();
        //    }
        //}
    }
}
