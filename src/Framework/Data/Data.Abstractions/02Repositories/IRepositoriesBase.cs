//using Data.Abstractions.Entity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace Data.Abstractions.Repositories
//{
//    /// <summary>
//    /// 仓储基类接口定义一些实体仓储公用方法
//    /// </summary>
//    /// <typeparam name="TEntity">实体</typeparam>
//    /// <typeparam name="TPrimaryKey">主键</typeparam>
//    public interface IRepositoriesBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> //应该继承一个接口  里面  有一些扩展方法  IRepositories
//        where TEntity : class, IEntity<TPrimaryKey>
//    {
//        /// <summary>
//        /// 获取单个的viewdto对象
//        /// </summary>
//        /// <param name="primaryKey">获取对象转成dto</param>
//        /// <returns>dto对象</returns>
//        Task<TEntity> GetEntityById(TPrimaryKey primaryKey);

//        /// <summary>
//        /// 获取所有的实体数据
//        /// </summary>
//        /// <returns></returns>
//        Task<List<TEntity>> GetAllList();


//        /// <summary>
//        /// 实体创建异步
//        /// </summary>
//        /// <param name="input">输入对象</param>
//        /// <returns>返回输出对象</returns>
//        Task<TEntity> CreateByDtoAsync(TEntity input);

//        /// <summary>
//        /// 更新
//        /// </summary>
//        /// <param name="input">更新输入对象</param>
//        /// <returns>主键值</returns>
//        Task<TEntity> UpdateByDtoAsync(TEntity input);

//        /// <summary>
//        /// 批量删除
//        /// </summary>
//        /// <param name="ids">更新输入对象</param>
//        /// <returns>r任务</returns>
//        Task BatchDeleteAsync(TPrimaryKey[] ids);

//        /// <summary>
//        /// 查询内存数据
//        /// </summary>
//        /// <param name="expression"></param>
//        /// <returns></returns>
//        IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> expression);

//        /// <summary>
//        /// 查询内存数据
//        /// </summary>
//        /// <returns></returns>
//        IQueryable<TEntity> Queryable();
//    }
//}

