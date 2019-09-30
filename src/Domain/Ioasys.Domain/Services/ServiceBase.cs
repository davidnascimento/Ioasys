using Ioasys.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Ioasys.Domain.Entities.Enterprise;
using System.Linq.Expressions;

namespace Ioasys.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : Entity
    {
        private readonly IRepository<TEntity> _repository;

        public ServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity GetById(int id, params Expression<Func<TEntity, object>>[] include)
        {
            return _repository.GetById(id, include);
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] include)
        {
            return _repository.GetAll(include);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include)
        {
            return _repository.Find(predicate, include);
        }

        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
