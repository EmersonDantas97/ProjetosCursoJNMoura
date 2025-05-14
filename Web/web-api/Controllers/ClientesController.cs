using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web_api.Repository;

namespace web_api.Controllers
{
    public class ClientesController : ApiController
    {

        private readonly ClienteRepository repositorio;

        public ClientesController()
        {
            repositorio = new ClienteRepository();
        }


        // GET: api/Clientes
        public IHttpActionResult Get()
        {
            return Ok(repositorio.ListaTodos());
        }

        // GET: api/Clientes/5
        public IHttpActionResult Get(int id)
        {
            return Ok(repositorio.ListarPorId(id));
        }

        // POST: api/Clientes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
        }
    }
}
