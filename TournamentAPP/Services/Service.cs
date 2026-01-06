using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using TournamentAPP.Repositories.Interfaces;
using TournamentAPP.Services.Interfaces;

namespace TournamentAPP.Services.Implementations
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

