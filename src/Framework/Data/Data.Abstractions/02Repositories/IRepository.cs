using Data.Abstractions.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Abstractions.Repositories
{

    public interface IRepository<TEntity> where TEntity : class
    {
        #region 新增
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        #endregion

        #region 更新
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        #endregion

        #region 删除
        bool Remove(TEntity entity);
        Task<bool> RemoveAsync(TEntity entity);
        #endregion


    }



    public interface IRepository<TEntity, TKey> : IRepository<TEntity> where TEntity : class, IEntity<TKey>
    {
        #region 删除
        bool Delete(TKey id);
        Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default);
        #endregion

        #region 查询单个
        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default);
        #endregion



    }



}
