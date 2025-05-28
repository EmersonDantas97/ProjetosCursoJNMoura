using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Threading.Tasks;
using System.Web.Http;

namespace web_api.Controllers
{
    public class EmpresasController : ApiController
    {
        private readonly string _diretorioLog;

        public EmpresasController()
        {
            _diretorioLog = Configurations.Config.GetLogPath();
        }

        // GET: api/Empresas
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                List<Models.Empresa> listaDeEmpresas = new List<Models.Empresa>();

                string scriptSql =
                    "SELECT Id, Nome, DataAbertura FROM Empresa;";

                using (SqlConnection conn = new SqlConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand(scriptSql, conn))
                    {
                        SqlDataReader dr = await cmd.ExecuteReaderAsync();

                        while (await dr.ReadAsync())
                        {
                            Models.Empresa emp = new Models.Empresa();

                            emp.Id = (int)dr["Id"];
                            emp.Nome = (string)dr["Nome"];
                            emp.DataAbertura = (DateTime)dr["DataAbertura"];

                            listaDeEmpresas.Add(emp);
                        }
                    }
                }
                return Ok(listaDeEmpresas);
            }
            catch (Exception ex)
            {
                Utils.Logger.RegistraLog(_diretorioLog, ex);

                return InternalServerError();
            }
        }

        //// GET: api/Empresas/5
        //public async Task<IHttpActionResult> Get(int id)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.Logger.RegistraLog(_diretorioLog, ex);

        //        return InternalServerError();
        //    }




        //    return "value";
        //}

        //// POST: api/Empresas
        //public async Task<IHttpActionResult> Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Empresas/5
        //public async Task<IHttpActionResult> Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Empresas/5
        //public async Task<IHttpActionResult> Delete(int id)
        //{
        //}
    }
}
