using System.Web.Http;
using System;
using System.Threading.Tasks;
using web_api.Utils;

namespace web_api.Controllers
{
    public class CarrosController : ApiController
    {
        readonly Logger logger;

        private readonly Repositories.SQLServer.Carro repository;

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
                return Ok(await repository.GetAll());
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
                return Ok(await repository.GetByName(nome));
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
                Models.Carro carro = await repository.GetById(id);

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
                await repository.Add(carro);

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
                bool resposta = await repository.Update(carro);

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
                bool resposta = await repository.Delete(id);

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

//É utilizado o using para dispensar a utilização de:
//conn.Close();
//conn.Dispose(); // Marca para garbdge colector excluir da memória. 
//Reader = Pega dados. 2 colunas x 2 linhas = 4 dados.
//NonQuery = Insert, Update e Delete.
//Scalar = Retorna somente 1 dado.

