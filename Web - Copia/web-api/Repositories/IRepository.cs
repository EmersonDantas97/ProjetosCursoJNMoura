using System.Collections.Generic;
using System.Threading.Tasks;

namespace web_api.Repositories
{
    internal interface IRepository<T> where T : class
    {
        int CacheExpirationTime { get; set; }

        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<List<T>> GetByName(string nome);
        Task Add(T value);
        Task<bool> Update(T value);
        Task<bool> Delete(int id);
    }
}
