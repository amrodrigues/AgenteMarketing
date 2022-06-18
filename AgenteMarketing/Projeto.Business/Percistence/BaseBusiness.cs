using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Business;
using Projeto.Repository;

namespace Projeto.Business
{
    public abstract class BaseBusiness<T> : IBaseBusiness<T> where T : class
    {
        private IBaseRepository<T> repository;

        public BaseBusiness(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }
        public virtual void Atualizar(T obj)
        {
            repository.Update(obj);
        }

        public virtual void Cadastrar(T obj)
        {
            repository.Insert(obj);
        }

        public virtual T ConsultaPorId(int id)
        {
            return repository.FindById(id);
        }

        public virtual List<T> ConsultaTodos()
        {
            return repository.FindAll();
        }

        public virtual void Excluir(T obj)
        {
            repository.Delete(obj);
        }
    }
}
