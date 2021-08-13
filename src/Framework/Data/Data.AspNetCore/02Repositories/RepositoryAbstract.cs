using Data.Abstractions.Entity;
using Data.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.AspNetCore.Repositories
{
    public abstract class RepositoryAbstract<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected virtual TDbContext DbContext { get; set; }

        public virtual DbSet<TEntity> DbEntity => DbContext.Set<TEntity>();

        public RepositoryAbstract(TDbContext context)
        {
            this.DbContext = context;
        }

        public virtual IQueryable Queryable() 
        {
            return DbEntity.AsQueryable();
        
        }


        public virtual List<TEntity> GetAll()
        {
            return DbEntity.ToList();
        }

        public virtual TEntity Add(TEntity entity)
        {
            return DbEntity.Add(entity).Entity;
        }

        public virtual Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Add(entity));
        }

        public virtual TEntity Update(TEntity entity)
        {
            return DbEntity.Update(entity).Entity;
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Update(entity));
        }

        public virtual bool Remove(TEntity entity)
        {
            DbEntity.Remove(entity);
            return true;
        }

        public virtual Task<bool> RemoveAsync(TEntity entity)
        {
            return Task.FromResult(Remove(entity));
        }
    }


    public abstract class RepositoryAbstract<TEntity, TKey, TDbContext> : RepositoryAbstract<TEntity, TDbContext>, IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TDbContext : DbContext
    {
        public RepositoryAbstract(TDbContext context) : base(context)
        {
        }

        public virtual bool Delete(TKey id)
        {
            var entity = DbContext.Find<TEntity>(id);
            if (entity == null)
            {
                return false;
            }
            DbContext.Remove(entity);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await DbContext.FindAsync<TEntity>(id, cancellationToken);
            if (entity == null)
            {
                return false;
            }
            DbContext.Remove(entity);
            return true;
        }

        public virtual TEntity Get(TKey id)
        {
            return DbContext.Find<TEntity>(id);
        }

        public virtual async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await DbContext.FindAsync<TEntity>(id, cancellationToken);
        }


        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await DbContext.Set<TEntity>().ToListAsync();
        }
    }

}