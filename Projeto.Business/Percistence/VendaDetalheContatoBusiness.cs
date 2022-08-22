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
  public class VendaDetalheContatoBusiness : BaseBusiness<VendaDetalheContato>, IVendaDetalheContatoBusiness
    {
        private IVendaDetalheContatoRepository repository;

        public VendaDetalheContatoBusiness(IVendaDetalheContatoRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public List<VendaDetalheContato> ConsultarTodos()
        {
            return repository.FindAll();
        }
        public List<VendaDetalheContato> ConsultarTodos(int id)
        {
            return repository.FindAll(id);
        }
    }
}
