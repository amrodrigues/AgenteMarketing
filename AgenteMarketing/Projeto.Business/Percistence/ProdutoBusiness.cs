using Projeto.Business.Contracts;
using Projeto.Entities;
using Projeto.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Business.Percistence
{
   public class ProdutoBusiness : BaseBusiness<Produto>, IProdutoBusiness
    {
        private IProdutoRepository repository;


        public ProdutoBusiness(IProdutoRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public List<Produto> ConsultaPorNome(string nome)
        {
            return repository.FindByNome(nome);
        }

        public List<Produto> ConsultarTodos()
        {
            return repository.FindAll();
        }
    }
}
   