using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Business.Contracts;
using Projeto.Repository;
using Projeto.Repository.Contracts;

namespace Projeto.Business.Percistence
{
    public class VendaContatoBusiness : BaseBusiness<VendaContato>, IVendaContatoBusiness
    {
        private IVendaContatoRepository repository;

        public VendaContatoBusiness(IVendaContatoRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public List<VendaContato> ConsultarTodos()
        {
            return repository.FindAll();
        }

        public List<VendaContato> ConsultarTodos(int id)
        {
            return repository.FindAll(id);
        }
    }
}
