using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace web_api.Controllers
{
    public class PessoasController : ApiController
    {
        private static List<Models.Pessoa> pessoas = new List<Models.Pessoa>();

        public PessoasController()
        {
        }

        // GET: api/Pessoas
        public IEnumerable<Models.Pessoa> Get()
        {
            return pessoas;
        }

        // GET: api/Pessoas/5
        public Models.Pessoa Get(int id)
        {
            foreach (var item in pessoas)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        // POST: api/Pessoas
        public void Post([FromBody] Models.Pessoa pessoa)
        {
            pessoas.Add(pessoa);
        }

        // PUT: api/Pessoas/5
        public void Put(int id, [FromBody] Models.Pessoa pessoa)
        {
            foreach (var item in pessoas)
            {
                if (item.Id == id)
                {
                    item.Nome = pessoa.Nome;
                    item.Idade = pessoa.Idade;
                    break;
                }
            }
        }

        // DELETE: api/Pessoas/5
        public void Delete(int id)
        {
            foreach (var item in pessoas)
            {
                if (item.Id == id)
                {
                    pessoas.Remove(item);
                    break;
                }
            }
        }
    }
}
