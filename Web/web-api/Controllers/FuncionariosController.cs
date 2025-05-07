using web_api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace web_api.Controllers
{
    public class FuncionariosController : ApiController
    {

        private static List<Funcionario> listaDeFuncionarios = new List<Funcionario>();

        // GET: api/Funcionarios
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(listaDeFuncionarios);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Funcionarios/5
        public IHttpActionResult Get(int id)
        {
            foreach (var item in listaDeFuncionarios)
            {
                if (item.Codigo == id)
                {
                    return Ok(item);
                }
            }

            return NotFound();
        }

        // POST: api/Funcionarios
        public IHttpActionResult Post([FromBody] Funcionario funcionario)
        {
            if (funcionario == null)
            {
                return BadRequest("Dados não foram enviados!");
            }

            listaDeFuncionarios.Add(funcionario);
            return Ok();
        }

        [Route("api/Funcionarios/batch")]
        // POST: api/Funcionarios
        public IHttpActionResult Post([FromBody] List<Funcionario> listaFuncionarios)
        {
            if (listaFuncionarios == null)
            {
                return BadRequest("Dados não foram enviados!");
            }

            foreach (var item in listaFuncionarios)
            {
                listaDeFuncionarios.Add(item);
            }

            return Ok();
        }

        // PUT: api/Funcionarios/5
        public IHttpActionResult Put(int id, [FromBody] Funcionario funcionario)
        {
            foreach (var item in listaDeFuncionarios)
            {
                item.CEP = funcionario.CEP;
                item.RG = funcionario.RG;
                item.Salario = funcionario.Salario;
                item.Cidade = funcionario.Cidade;
                item.CodigoDepartamento = funcionario.CodigoDepartamento;
                item.CPF = funcionario.CPF;
                item.DataNascimento = funcionario.DataNascimento;
                item.Endereco = funcionario.Endereco;
                item.SegundoNome = funcionario.SegundoNome;
                item.UltimoNome = funcionario.UltimoNome;
                item.PrimeiroNome = funcionario.PrimeiroNome;
                item.Fone = funcionario.Fone;
                item.Funcao = funcionario.Funcao;

                return Ok(item);
            }

            return NotFound();
        }

        // DELETE: api/Funcionarios/5
        public IHttpActionResult Delete(int id)
        {
            foreach (var item in listaDeFuncionarios)
            {
                if (item.Codigo == id)
                {
                    listaDeFuncionarios.Remove(item);
                    return Ok();
                }
            }

            return NotFound();
        }
    }
}
