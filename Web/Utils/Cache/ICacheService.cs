using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Cache
{
    public interface ICacheService
    {
        T Get<T>(string key);

        /// <summary>
        /// Deve ser passado o tempo de expiração em segundos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="durationInSeconds">tempo em segundos</param>
        void Set<T>(string key, T value, int durationInSeconds);

        void Remove(string key);
    }
}
