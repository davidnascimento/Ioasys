using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Ioasys.Domain.Entities.Enterprise;

namespace Ioasys.Domain.Services
{
    public interface IServiceBase<TEntity> where TEntity : Entity
    {
        TEntity GetById(int id, params Expression<Func<TEntity, object>>[] include);
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] include);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        void Dispose();
    }
}
