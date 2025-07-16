using System.Web.Http;
using System;
using System.Threading.Tasks;
using Utils;
using Repositories;

namespace web_api.Controllers
{
    public class CarrosController : ApiController
    {
        readonly Logger logger;

        private readonly IRepository<Models.Carro> repository;

        public CarrosController()
        {
            logger = new Logger(Configurations.Config.GetLogPath());

            repository = new Repositories.SQLServer.Carro(Configurations.Config.GetConnectionStringSQLServer());
            repository.CacheExpirationTime = Configurations.Config.GetCacheExpirationTime("cacheExpirationTimeInSeconds");
        }

        // GET: api/Carros
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok(await repository.GetAllAsync());
            }
            catch (Exception ex)
            {
                await logger.RegistraLog(ex);

                return InternalServerError();
            }
        }

        // GET: api/Carros
        [Route("api/Carros/{nome:alpha}")]
        public async Task<IHttpActionResult> Get(string nome)
        {
            try
            { 
                return Ok(await repository.GetByNameAsync(nome));
            }
            catch (Exception ex)
            {
                await logger.RegistraLog(ex);

                return InternalServerError();
            }
        }

        // GET: api/Carros/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            { 
                Models.Carro carro = await repository.GetByIdAsync(id);

                if (carro.Id == 0)
                    return NotFound();

                return Ok(carro);
            }
            catch (Exception ex)
            {
                await logger.RegistraLog(ex);

                return InternalServerError();
            }
        }

        // POST: api/Carros
        public async Task<IHttpActionResult> Post([FromBody] Models.Carro carro)
        {
            if(carro is null || !ModelState.IsValid)
                return BadRequest("Os dados do carro não foram enviados corretamente!");

            try
            {
                await repository.AddAsync(carro);

                return Ok(carro);
            }
            catch (Exception ex)
            {
                await logger.RegistraLog(ex);

                return InternalServerError();
            }
        }

        // PUT: api/Carros/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Models.Carro carro)
        {
            if (carro == null)
                return BadRequest("Os dados do carro não foram enviados corretamente!");

            if (carro.Id != id)
                return BadRequest("O Id da rota não corresponde ao Id do carro!");

            try
            {
                bool resposta = await repository.UpdateAsync(carro);

                if (!resposta)
                    return NotFound();
                    
                return Ok(carro);

            }
            catch (Exception ex)
            {
                await logger.RegistraLog(ex);

                return InternalServerError();
            }
        }

        // DELETE: api/Carros/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                bool resposta = await repository.DeleteAsync(id);

                if (!resposta)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                await logger.RegistraLog(ex);

                return InternalServerError();
            }

        }

    }

}

