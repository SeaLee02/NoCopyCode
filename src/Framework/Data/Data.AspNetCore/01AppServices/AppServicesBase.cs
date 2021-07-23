using Data.Abstractions.AppServices;
using Data.Abstractions.Entity;
using Data.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AspNetCore.AppServices
{
    /// <summary>
    /// 服务基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class AppServicesBase<TEntity, TKey> : IAppServicesBase<TEntity, TKey>
             where TEntity : class, IEntity<TKey>
    {

        private readonly IRepository<TEntity, TKey> _repository;

        public AppServicesBase(IRepository<TEntity, TKey> repository)
        {
            this._repository = repository;
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return await _repository.AddAsync(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(TKey id)
        {
            return await _repository.DeleteAsync(id);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(TKey id)
        {
            return await _repository.GetAsync(id);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
