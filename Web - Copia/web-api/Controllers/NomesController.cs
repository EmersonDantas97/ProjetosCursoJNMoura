using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.Http.Cors;

namespace web_api.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NomesController : ApiController
    {
        // GET: api/Nomes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Nomes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Nomes
        public Models.Nome Post([FromBody] Models.Nome nome)
        {


            return nome;
        }

        // PUT: api/Nomes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Nomes/5
        public void Delete(int id)
        {
        }
    }
}
