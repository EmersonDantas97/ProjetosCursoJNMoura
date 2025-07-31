using System;
using System.Runtime.Caching;

namespace WebAPI_HortiFruti.Utils.Cache
{
    public class MemoryCacheService : ICacheService
    {
        private readonly ObjectCache cache;

        public MemoryCacheService()
        {
            cache = MemoryCache.Default;
        }

        public T Get<T>(string key)
        {
            return (T)cache.Get(key);
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }

        public void Set<T>(string key, T value, int cacheSeconds)
        {
            cache.Set(key, value, new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(cacheSeconds) });
        }
    }
}