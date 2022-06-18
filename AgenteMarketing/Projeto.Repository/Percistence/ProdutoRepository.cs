using Projeto.Entities;
using Projeto.Repository.Context;
using Projeto.Repository.Contracts;
using Projeto.Repository.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository.Percistence
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public List<Produto> FindByNome(string nome)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Produto
                    .Where(p => p.NomeProduto.Contains(nome))
                    .OrderBy(p => p.NomeProduto)
                    .ToList();
            }
        }
    }
}


