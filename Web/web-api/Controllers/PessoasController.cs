using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace web_api.Controllers
{
    public class PessoasController : ApiController
    {
        private readonly string diretorioArqLogs;
        private readonly Repositories.Pessoa repository;

        public PessoasController()
        {
            this.diretorioArqLogs = Configurations.Config.GetLogPath();
            this.repository = new Repositories.Pessoa(Configurations.Config.GetConnectionString("web_api"));
        }

        // GET: api/Pessoas
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok(await repository.GetAll());
            }
            catch (Exception ex)
            {
                await Utils.Logger.RegistraLog(diretorioArqLogs, ex);

                return InternalServerError();
            }
        }

        // GET: api/Pessoas/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Models.Pessoa pessoa = await repository.GetById(id);

                if (pessoa.Id == 0)
                    return NotFound();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                await Utils.Logger.RegistraLog(diretorioArqLogs, ex);

                return InternalServerError();
            }
        }

        // GET: api/Pessoas/5
        [Route("api/Pessoas/{nome:alpha}")]
        public async Task<IHttpActionResult> Get(string nome)
        {
            try
            {
                return Ok(await repository.GetByName(nome));
            }
            catch (Exception ex)
            {
                await Utils.Logger.RegistraLog(diretorioArqLogs, ex);

                return InternalServerError();
            }
        }

        // POST: api/Pessoas
        public async Task<IHttpActionResult> Post([FromBody] Models.Pessoa pessoa)
        {
            if (pessoa == null)
                return BadRequest("Os dados da pessoa não foram enviados corretamente!");

            try
            {
                await repository.Add(pessoa);

                return Ok();
            }
            catch (Exception ex)
            {
                await Utils.Logger.RegistraLog(diretorioArqLogs, ex);

                return InternalServerError();
            }
        }

        // PUT: api/Pessoas/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Models.Pessoa pessoa)
        {
            if (pessoa == null)
                return BadRequest("Os dados da pessoa não foram enviados corretamente!");

            if (pessoa.Id != id)
                return BadRequest("O Id da rota não corresponde ao Id da pessoa!");

            try
            {
                bool resposta = await repository.Update(pessoa);

                if (!resposta)
                    return NotFound();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                await Utils.Logger.RegistraLog(diretorioArqLogs, ex);

                return InternalServerError();
            }
        }

        // DELETE: api/Pessoas/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var resposta = await repository.Delete(id);

                if (!resposta)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                await Utils.Logger.RegistraLog(diretorioArqLogs, ex);

                return InternalServerError();
            }
        }
    }
}