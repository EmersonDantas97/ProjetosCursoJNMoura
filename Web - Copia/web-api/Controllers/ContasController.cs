using System.Collections.Generic;
using System.Web.Http;
using web_api.Models;

namespace web_api.Controllers
{
    public class ContasController : ApiController
    {
        private static List<Conta> listaDeContas = new List<Conta>();

        public ContasController()
        {
        }

        // GET: api/Contas
        public IHttpActionResult Get()
        {
            return Ok(listaDeContas);
        }

        // GET: api/Contas/5
        public IHttpActionResult Get(int id)
        {
            foreach (var item in listaDeContas)
            {
                if (item.Codigo == id)
                {
                    return Ok(item);
                }
            }
            return BadRequest("Nenhum dado encontrado com este CÓDIGO!");
        }

        // POST: api/Contas
        public IHttpActionResult Post([FromBody] Conta conta)
        {
            if (conta == null)
                return BadRequest("Inclusão NÃO REALIZADA! Verifique as informações e tente novamente...");

            listaDeContas.Add(conta);
            return Ok();
        }

        [Route("api/Contas/batch")]
        // POST: api/Contas
        public IHttpActionResult Post([FromBody] List<Conta> listaContas)
        {
            if (listaContas == null)
                return BadRequest("Inclusão NÃO REALIZADA! Confirme as informações e tente novamente...");

            foreach (var item in listaContas)
                listaDeContas.Add(item);

            return Ok();
        }

        // PUT: api/Contas/5
        public IHttpActionResult Put(int id, [FromBody] Conta conta)
        {
            foreach(var item in listaDeContas)
            {
                if (item.Codigo == id)
                {
                    item.DataCadastro = conta.DataCadastro;
                    item.Nome = conta.Nome;
                    item.Observacao = conta.Observacao;
                    item.ParcelaAtual = conta.ParcelaAtual;
                    item.Parcelada = conta.Parcelada;
                    item.QtdTotalParcelas = conta.QtdTotalParcelas;
                    item.Valor = conta.Valor;

                    return Ok(item);
                }
            }
            return NotFound();
        }

        // DELETE: api/Contas/5
        public IHttpActionResult Delete(int id)
        {
            foreach(var item in listaDeContas)
            {
                if (id == item.Codigo)
                {
                    listaDeContas.Remove(item);
                    return Ok();
                }
            }
            return BadRequest("Não foi possível realizar a EXCLUSÃO!");
        }
    }
}
