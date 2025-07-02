using System;
using System.Runtime.Caching; // Perguntar por que tivemos que seleciona-lo.

namespace web_api.Utils
{
    public  class CacheService : ICacheService
    {
        private readonly ObjectCache cache;

        public CacheService()
        {
            cache = MemoryCache.Default;
        }

        public T Get<T>(string key)
        { 
            return (T) cache.Get(key);
        }

        public void Set<T>(string key, T value, int cacheSeconds)
        {
            cache.Set(key, value, new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheSeconds) });
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}