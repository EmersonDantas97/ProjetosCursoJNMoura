using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_HortiFruti.Repositories
{
    internal interface IRepository<T> where T : class
    {
        int CacheExpirationTime { get; set; }

        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetByNameAsync(string nome);
        Task<bool> DeleteAsync();
        Task<bool> UpdateAsync();
        Task AddAsync(T value);


    }
}
