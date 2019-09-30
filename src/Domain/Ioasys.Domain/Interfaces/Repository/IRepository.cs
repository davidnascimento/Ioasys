using Ioasys.Domain.Entities.Enterprise;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ioasys.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity GetById(int id, params Expression<Func<TEntity, object>>[] include);
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] include);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include);

        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
