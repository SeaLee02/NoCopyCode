using LiModular.Lib.Cache.Abstractions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.Cache.Redis
{
    public class RedisHelper : IDisposable
    {
        internal ConnectionMultiplexer _redis;
        internal string _prefix;
        internal readonly RedisConfig _config;
        public IDatabase Db;
        public RedisDatabase Database;

        public RedisHelper(CacheConfig config)
        {
            _config = config.Redis;
            CreateConnection();
        }


        /// <summary>
        /// 创建连接
        /// </summary>
        internal void CreateConnection()
        {
            _prefix = _config.Prefix;
            _redis = ConnectionMultiplexer.Connect(_config.ConnectionString);
            Db = GetDb();
        }

        /// <summary>
        /// 获取Redis原生的IDatabase
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public IDatabase GetDb(int db = -1)
        {
            if (db == -1)
                db = _config.DefaultDb;

            return _redis.GetDatabase(db);
        }

        /// <summary>
        /// 获取键(附加前缀)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetKey(string key)
        {
            return $"{_prefix}{key}";
        }


        #region ==String==

        /// <summary>
        /// 写入字符串类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public Task<bool> StringSetAsync<T>(string key, T obj, TimeSpan? expiry = null)
        {
            return Database.StringSetAsync(key, obj, expiry);
        }

        /// <summary>
        /// 获取字符串类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<T> StringGetAsync<T>(string key)
        {
            return Database.StringGetAsync<T>(key);
        }

        /// <summary>
        /// 字符串减去数值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> StringDecrementAsync(string key, long value = 1)
        {
            return Database.StringDecrementAsync(key, value);
        }

        /// <summary>
        /// 字符串增加数值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> StringIncrementAsync(string key, long value = 1)
        {
            return Database.StringIncrementAsync(key, value);
        }

        #endregion






        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
