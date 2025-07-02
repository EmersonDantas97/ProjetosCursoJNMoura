using web_api.Models;
using System.Web.Http;
using System.Threading.Tasks;
using System;

namespace web_api.Controllers
{
    public class FuncionariosController : ApiController
    {
        private readonly string logPath;
        private readonly Repositories.Funcionario repository;
        public FuncionariosController()
        {
            logPath = Configurations.Config.GetLogPath();

        }

        // GET: api/Funcionarios
        //public async Task<IHttpActionResult> Get()
        //{
        //}

        // GET: api/Funcionarios/5
        //public async Task<IHttpActionResult> Get(int id)
        //{
        //}

        // POST: api/Funcionarios
        public async Task<IHttpActionResult> Post([FromBody] Funcionario funcionario)
        {
            try
            {
                await repository.Add(funcionario);

                return Ok();
            }
            catch (Exception ex)
            {
                //await Utils.Logger.RegistraLog(logPath, ex);

                return InternalServerError();
            }
        }

        // PUT: api/Funcionarios/5
        //public async Task<IHttpActionResult> Put(int id, [FromBody] Funcionario funcionario)
        //{
        //}

        // DELETE: api/Funcionarios/5
        //public async Task<IHttpActionResult> Delete(int id)
        //{
        //}
    }

}
// 60% da memória o dotnet derruba a aplicação. Este número é configurável.