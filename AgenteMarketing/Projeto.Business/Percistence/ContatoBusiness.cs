using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Repository;

namespace Projeto.Business
{
    public class ContatoBusiness : BaseBusiness<Contato>, IContatoBusiness
    {
        private IContatoRepository repository;

    
        public ContatoBusiness(IContatoRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public List<Contato> ConsultaPorNome(string nome)
        {
            return repository.FindByNome(nome);
        }

        public List<Contato> ConsultarTodos()
        {
            return repository.FindAll();
        }
    }
}