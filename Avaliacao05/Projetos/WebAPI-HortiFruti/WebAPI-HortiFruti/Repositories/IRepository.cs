using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI_HortiFruti.Repositories
{
    internal interface IRepository<T> where T : class
    {
        int CacheExpirationTime { get; set; }

        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetByNameAsync(string nome);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(T value);
        Task AddAsync(T value);


    }
}
