using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web_api.Models;

namespace web_api.Controllers
{
    public class PessoasController : ApiController
    {
        private static List<Models.Pessoa> pessoas = new List<Models.Pessoa>();

        public PessoasController() 
        {
        }

        // GET: api/Pessoas
        [HttpGet]
        public IEnumerable<Models.Pessoa> Get()
        {
            return pessoas;
        }

        // GET: api/Pessoas/5
        [HttpGet]
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
        [HttpPost]
        public void Post([FromBody] Models.Pessoa pessoa)
        {
            pessoas.Add(pessoa);
        }

        // POST: api/Pessoas
        [HttpPost]
        [Route("api/Pessoas/Lote")]
        public void Post([FromBody] List<Models.Pessoa> pessoasLista)
        {
            foreach(var item in pessoasLista)
            {
                pessoas.Add(item);
            }
        }

        // PUT: api/Pessoas/5
        [HttpPut]
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
        [HttpDelete]
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
