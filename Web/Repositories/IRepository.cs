using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<T> where T : class
    {
        int CacheExpirationTime { get; set; }

        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetByNameAsync(string nome);
        Task AddAsync(T value);
        Task<bool> UpdateAsync(T value);
        Task<bool> DeleteAsync(int id);

    }
}

