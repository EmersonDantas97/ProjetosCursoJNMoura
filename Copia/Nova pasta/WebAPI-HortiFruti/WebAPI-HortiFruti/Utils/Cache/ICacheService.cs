using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_HortiFruti.Utils.Cache
{
    internal interface ICacheService
    {
        T Get<T>(string key);

        void Set<T>(string key, T value, int cacheSeconds);

        void Remove(string key);
    }
}
