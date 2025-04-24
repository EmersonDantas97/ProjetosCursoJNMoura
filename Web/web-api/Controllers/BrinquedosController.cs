using System.Collections.Generic;
using System.Web.Http;

namespace web_api.Controllers
{
    public class BrinquedosController : ApiController
    {
        static List<Models.Brinquedo> listaDeBrinquedos = new List<Models.Brinquedo>();

        public BrinquedosController()
        {
        }

        // GET: api/Brinquedos
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(listaDeBrinquedos);
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Brinquedos/5
        public IHttpActionResult Get(int id)
        {
            foreach (var item in listaDeBrinquedos)
            {
                if(item.Id == id)
                {
                    return Ok(item);
                }
            }
            return NotFound();
        }

        // POST: api/Brinquedos
        public IHttpActionResult Post([FromBody] Models.Brinquedo brinquedo)
        {
            if (brinquedo == null)
            {
                return BadRequest("Dados não foram enviados!");
            }

            listaDeBrinquedos.Add(brinquedo);
            return Ok();
        }

        // POST: api/Brinquedos
        [Route("api/Brinquedos/batch")]
        public IHttpActionResult Post([FromBody] List<Models.Brinquedo> listaBrinquedos)
        {
            if (listaBrinquedos == null)
            {
                return BadRequest("Dados não foram enviados!");
            }

            foreach (var item in listaBrinquedos)
            {
                listaDeBrinquedos.Add(item);
            }

            return Ok();
        }

        // PUT: api/Brinquedos/5
        public IHttpActionResult Put(int id, [FromBody] Models.Brinquedo brinquedo)
        {
            foreach (var item in listaDeBrinquedos)
            {
                if (item.Id == id)
                {
                    item.Nome = brinquedo.Nome;
                    item.IdadeMinima = brinquedo.IdadeMinima;
                    item.IdadeMaxima = brinquedo.IdadeMaxima;
                    item.Valor = brinquedo.Valor;
                    return Ok(item);
                }
            }
                return NotFound();
        }

        // DELETE: api/Brinquedos/5
        public IHttpActionResult Delete(int id)
        {
            foreach (var item in listaDeBrinquedos)
            {
                if (item.Id == id)
                {
                    listaDeBrinquedos.Remove(item);
                    return Ok();
                }
            }
                return NotFound();
        }
    }
}
