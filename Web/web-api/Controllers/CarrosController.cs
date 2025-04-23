using System.Collections.Generic;
using System.Web.Http;

namespace web_api.Controllers
{
    public class CarrosController : ApiController
    {
        private static List<Models.Carro> listaCarros = new List<Models.Carro>();

        public CarrosController()
        {
        }

        // GET: api/Carros
        public List<Models.Carro> Get()
        {
            return listaCarros;
        }

        // GET: api/Carros/5
        public Models.Carro Get(int id)
        {
            foreach (var item in listaCarros)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        // POST: api/Carros
        public void Post([FromBody] Models.Carro carro)
        {
            listaCarros.Add(carro);
        }

        // POST: api/Carros
        public void Post([FromBody] Models.Carro[] carros)
        {

            foreach (var item in carros)
            {
                listaCarros.Add(item);
            }
        }

        // PUT: api/Carros/5
        public void Put(int id, [FromBody] Models.Carro carro)
        {
            foreach (var item in listaCarros)
            {
                if (item.Id == carro.Id)
                {
                    listaCarros.Remove(item);
                }
            }
        }

        // DELETE: api/Carros/5
        public void Delete(int id)
        {
            foreach (var item in listaCarros)
            {
                if (item.Id == id)
                {
                    listaCarros.Remove(item);
                }
            }
        }
    }
}
