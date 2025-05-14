using web_api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using web_api.Repository;

namespace web_api.Controllers
{
    public class FuncionariosController : ApiController
    {
        private readonly FuncionarioRepository funcionarioRepositorio;
        public FuncionariosController()
        {
            funcionarioRepositorio = new FuncionarioRepository();
        }

        // GET: api/Funcionarios
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(funcionarioRepositorio.ListarTodos());
            }
            catch (Exception)
            {
                // Logar Ex
                return InternalServerError();
            }
        }

        // GET: api/Funcionarios/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Models.Funcionario funcionario = funcionarioRepositorio.ListarPorId(id);

                if (funcionario != null)
                    return Ok(funcionario);
                else
                    return NotFound();

            }
            catch (Exception)
            {
                // Logar Ex
                return InternalServerError();
            }
        }

        // POST: api/Funcionarios
        public IHttpActionResult Post([FromBody] Funcionario funcionario)
        {
            try
            {
                if (funcionario == null)
                    return BadRequest("Dados não foram enviados!");

                var funcionarioAdicionado = funcionarioRepositorio.Adicionar(funcionario);

                return Ok(funcionarioAdicionado);
            }
            catch (Exception)
            {
                // Logar Ex
                return InternalServerError();
            }
        }

        [Route("api/Funcionarios/batch")]
        // POST: api/Funcionarios
        public IHttpActionResult Post([FromBody] List<Funcionario> listaFuncionarios)
        {
            try
            {
                if (listaFuncionarios == null)
                    return BadRequest("Dados não foram enviados!");

                var listaDeFuncionariosAdicionados = funcionarioRepositorio.AdicionarEmLote(listaFuncionarios);

                return Ok(listaDeFuncionariosAdicionados);

            }
            catch (Exception)
            {
                // Logar Ex
                return InternalServerError();
            }
        }

        // PUT: api/Funcionarios/5
        public IHttpActionResult Put(int id, [FromBody] Funcionario funcionario)
        {
            try
            {
                Models.Funcionario funcionarioAlterado = funcionarioRepositorio.Alterar(id, funcionario);

                if (funcionarioAlterado != null)
                    return Ok(funcionarioAlterado);
                else
                    return NotFound();
            }
            catch (Exception)
            {
                // Logar Ex
                return InternalServerError();
            }
        }

        // DELETE: api/Funcionarios/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Models.Funcionario funcionarioDeletado = funcionarioRepositorio.Excluir(id);

                if (funcionarioDeletado != null)
                    return Ok(funcionarioDeletado);
                else
                    return NotFound();

            }
            catch (Exception)
            {
                // Logar Ex
                return InternalServerError();
            }
        }
    }
}
