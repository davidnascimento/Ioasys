using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Ioasys.Domain.Entities.Enterprise;
using Ioasys.Domain.Interfaces.Repository;
using Ioasys.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ioasys.Infra.Data.Repositories
{
    public abstract partial class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private BaseContext Db;
        private DbSet<TEntity> DbSet;

        public RepositoryBase(BaseContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> query;

            query = Db.Set<TEntity>().AsNoTracking();

            if (include != null)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }

            if (predicate != null)
                query = query.Where(predicate);

            return query.ToList();
        }

        public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] include)
        {
            return Find(null, include);
        }

        public virtual TEntity GetById(int id, params Expression<Func<TEntity, object>>[] include)
        {
            Expression<Func<TEntity, bool>> predicate = x => x.Id == id;
            return Find(predicate, include).FirstOrDefault();
        }

        public virtual void Add(TEntity entity)
        {
            CheckEntityIsNull(entity);

            DbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            CheckEntityIsNull(entity);

            DbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            CheckEntityIsNull(entity);

            var entry = Db.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        private void CheckEntityIsNull(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
