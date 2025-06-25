using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace web_api.Controllers
{
    public class MotosController : ApiController
    {
        private readonly Repositories.Moto repository;
        private readonly string logPath;
        

        public MotosController()
        {
            repository = new Repositories.Moto(Configurations.Config.GetConnectionString("web_api"));
            logPath = Configurations.Config.GetLogPath();
        }

        // GET: api/Motos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Motos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Motos
        public async Task<IHttpActionResult> Post([FromBody] Models.Moto moto)
        {
            if (moto is null || !ModelState.IsValid)
            {
                return BadRequest("Os dados da moto não foram enviados corretamente!");
            }

            try
            {
                await repository.Add(moto);

                return Ok();
            }
            catch (Exception ex)
            {
                await Utils.Logger.RegistraLog(logPath, ex);

                return InternalServerError();
            }
        }

        // PUT: api/Motos/5
        //public async Task<IHttpActionResult> Put(int id, [FromBody] Models.Moto moto)
        //{
        //    if (moto is null || !ModelState.IsValid)
        //        return BadRequest("Os dados da moto não foram enviados corretamente!");

        //    if (moto.Id != id)
        //        return BadRequest("O id da rota não corresponde com o id da moto!");

        //    try
        //    {
        //        var resposta = await repository.Update(moto);



        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        // DELETE: api/Motos/5
        public void Delete(int id)
        {
        }
    }
}
