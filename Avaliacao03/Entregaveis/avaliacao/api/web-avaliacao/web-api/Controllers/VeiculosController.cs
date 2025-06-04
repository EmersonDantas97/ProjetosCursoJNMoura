using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace web_api.Controllers
{
    public class VeiculosController : ApiController
    {
        private readonly Repositories.Veiculo repository;
        private readonly string logPath;

        public VeiculosController()
        {
            repository = new Repositories.Veiculo(Configurations.Config.GetConnectionString("loja"));
            logPath = Configurations.Config.GetLogPath();
        }

        // GET: api/Veiculos
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok(await repository.GetAll());
            }
            catch (Exception ex)
            {
                await Utils.Logger.Log(logPath, ex);
                
                return InternalServerError();
            }
        }

        // GET: api/Veiculos/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Models.Veiculo veiculo = await repository.GetById(id);

                if (veiculo.Id == null)
                    return NotFound();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                await Utils.Logger.Log(logPath, ex);

                return InternalServerError();
            }
        }

        // GET: api/Veiculos/5
        [Route("api/Veiculos/{nome:alpha}")]
        public async Task<IHttpActionResult> Get(string nome)
        {
            try
            {
                return Ok(await repository.GetByName(nome));
            }
            catch (Exception ex)
            {
                await Utils.Logger.Log(logPath, ex);

                return InternalServerError();
            }
        }

        // POST: api/Veiculos
        public async Task<IHttpActionResult> Post([FromBody] Models.Veiculo veiculo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await repository.Add(veiculo);

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                await Utils.Logger.Log(logPath, ex);

                return InternalServerError();
            }
        }

        // PUT: api/Veiculos/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Models.Veiculo veiculo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (veiculo.Id != id)
                return BadRequest("O Id da rota não corresponde ao id do veículo.");

            try
            {
                bool resposta = await repository.Update(veiculo);

                if (!resposta)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                await Utils.Logger.Log(logPath, ex);

                return InternalServerError();
            }
        }

        // DELETE: api/Veiculos/5
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
                await Utils.Logger.Log(logPath, ex);

                return InternalServerError();
            }
        }
    }
}
