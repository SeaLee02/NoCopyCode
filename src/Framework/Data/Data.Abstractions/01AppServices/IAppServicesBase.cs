using Data.Abstractions.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstractions.AppServices
{
    public interface IAppServicesBase<TEntity, TPrimaryKey>
          where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="id">id值</param>
        /// <returns>实体对象</returns>
        Task<TEntity> GetAsync(TPrimaryKey id);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// 根据id删除实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>task</returns>
        Task<bool> DeleteAsync(TPrimaryKey id);


    }
}
