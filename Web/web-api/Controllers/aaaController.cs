using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace web_api.Controllers
{
    public class aaaController : ApiController
    {
        // GET: api/aaa
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/aaa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/aaa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/aaa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/aaa/5
        public void Delete(int id)
        {
        }
    }
}
