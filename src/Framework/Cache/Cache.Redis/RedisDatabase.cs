using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LiModular.Lib.Cache.Redis
{
    public class RedisDatabase
    {
        private readonly IDatabase _db;
        private readonly RedisHelper _redisHelper;
        private readonly ConnectionMultiplexer _redis;
        private readonly int _dbIndex;

        public RedisDatabase(int dbIndex, RedisHelper redisHelper)
        {
            _dbIndex = dbIndex < 0 ? 0 : dbIndex;
            _redisHelper = redisHelper;
            _redis = redisHelper._redis;
            _db = _redis.GetDatabase(_dbIndex);
        }


        private string GetKey(string key)
        {
            return _redisHelper.GetKey(key);
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
            return _db.StringSetAsync(GetKey(key), JsonSerializer.Serialize(obj), expiry);
        }

        /// <summary>
        /// 获取字符串类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> StringGetAsync<T>(string key)
        {
            var cache = await _db.StringGetAsync(GetKey(key));
            return cache.HasValue ? JsonSerializer.Deserialize<T>(cache) : default;
        }

        /// <summary>
        /// 字符串减去数值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> StringDecrementAsync(string key, long value = 1)
        {
            return _db.StringDecrementAsync(GetKey(key), value);
        }

        /// <summary>
        /// 字符串增加数值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> StringIncrementAsync(string key, long value = 1)
        {
            return _db.StringIncrementAsync(GetKey(key), value);
        }
        #endregion

        #region ==Hash==

        /// <summary>
        /// 设置值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Task<bool> HashSetAsync<T>(string key, string field, T obj)
        {
            return _db.HashSetAsync(GetKey(key), field, JsonSerializer.Serialize(obj));
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public async Task<T> HashGetAsync<T>(string key, string field)
        {
            var cache = await _db.HashGetAsync(GetKey(key), field);
            return cache.HasValue ? JsonSerializer.Deserialize<T>(cache) : default;
        }

        ///// <summary>
        ///// 获取所有值
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //public async Task<IList<T>> HashValuesAsync<T>(string key)
        //{
        //    var cache = await _db.HashValuesAsync(GetKey(key));
        //    return cache.Any() ? cache.Select(JsonSerializer.Deserialize<T>.ToList()) : default;
        //}

        /// <summary>
        /// 删除值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public Task<bool> HashDeleteAsync(string key, string field)
        {
            return _db.HashDeleteAsync(GetKey(key), field);
        }

        /// <summary>
        /// 获取所有键值集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<IList<KeyValuePair<string, T>>> HashGetAllAsync<T>(string key)
        {
            var cache = await _db.HashGetAllAsync(GetKey(key));
            return cache.Select(m => new KeyValuePair<string, T>(m.Name.ToString(), JsonSerializer.Deserialize<T>(m.Value))).ToList();
        }

        /// <summary>
        /// 数值减
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> HashDecrementAsync(string key, string field, long value = 1)
        {
            return _db.HashDecrementAsync(GetKey(key), field, value);
        }

        /// <summary>
        /// 数值加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<long> HashIncrementAsync(string key, string field, long value = 1)
        {
            return _db.HashIncrementAsync(GetKey(key), field, value);
        }

        /// <summary>
        /// 判断字段是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public Task<bool> HashExistsAsync(string key, string field)
        {
            return _db.HashExistsAsync(GetKey(key), field);
        }

        #endregion


    }
}
