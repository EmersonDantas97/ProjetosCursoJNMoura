using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Excel
{
    public class Carro : IRepository<Models.Carro>
    {
        public int CacheExpirationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Carro()
        {
        }

        public Task AddAsync(Models.Carro value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.Carro>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Models.Carro> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.Carro>> GetByNameAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Models.Carro value)
        {
            throw new NotImplementedException();
        }
    }
}