using LiModular.Lib.Cache.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.Cache.Redis
{
    public class RedisCacheHandler : ICacheHandler
    {
        public bool Exists(string key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(string key)
        {
            throw new NotImplementedException();
        }

        public string Get(string key)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveByPrefixAsync(string prefix)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value, int expires)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAsync<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAsync<T>(string key, T value, int expires)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out string value)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue<T>(string key, out T value)
        {
            throw new NotImplementedException();
        }
    }
}
