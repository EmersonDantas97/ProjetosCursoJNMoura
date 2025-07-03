using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Entity
{
    public class Carro : IRepository<Models.Carro>
    {
        public int CacheExpirationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Carro()
        {
        }

        public Task Add(Models.Carro value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.Carro>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Models.Carro> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.Carro>> GetByName(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Models.Carro value)
        {
            throw new NotImplementedException();
        }
    }
}