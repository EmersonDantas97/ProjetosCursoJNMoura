using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_HortiFruti.Controllers
{
    public class FrutasController : ApiController
    {

        public FrutasController()
        {
            
        }

        // GET: api/Frutas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Frutas/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/Frutas/{nome:alpha}")]
        // GET: api/Frutas/nome
        public string Get(string nome)
        {
            return "value";
        }

        // POST: api/Frutas
        public void Post([FromBody]string value)
        {
            // Validacao
        }

        // PUT: api/Frutas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Frutas/5
        public void Delete(int id)
        {
        }
    }
}
