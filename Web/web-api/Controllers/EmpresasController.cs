using System.Collections.Generic;
using System.Web.Http;

namespace web_api.Controllers
{
    public class EmpresasController : ApiController
    {
        private static List<Models.Empresa> listaEmpresas = new List<Models.Empresa>();

        // GET: api/Empresas
        public IEnumerable<Models.Empresa> Get()
        {
            return listaEmpresas;
        }

        // GET: api/Empresas/5
        public Models.Empresa Get(int id)
        {
            foreach(var item in listaEmpresas)
            {
                if (item.Id == id) 
                {
                    return item;
                }
            }
            return null;
        }

        // POST: api/Empresas
        public void Post([FromBody] Models.Empresa empresa)
        {
            listaEmpresas.Add(empresa);
        }

        // PUT: api/Empresas/5
        public void Put(int id, [FromBody] Models.Empresa empresa)
        {
            foreach(var item in listaEmpresas)
            {
                if (item.Id == id)
                {
                    item.Nome = empresa.Nome;
                    item.Cnpj = empresa.Cnpj;
                    item.DataAbertura = empresa.DataAbertura;
                    break;
                }
            }
        }

        // DELETE: api/Empresas/5
        public void Delete(int id)
        {
            foreach(var item in listaEmpresas)
            {
                if (item.Id == id)
                {
                    listaEmpresas.Remove(item);
                    break;
                }
            }
        }
    }
}
