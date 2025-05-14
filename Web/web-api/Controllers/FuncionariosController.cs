using web_api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using web_api.Repository;

namespace web_api.Controllers
{
    public class FuncionariosController : ApiController
    {
        private readonly FuncionarioRepository funcionarioRepository;

        public FuncionariosController()
        {
            funcionarioRepository = new FuncionarioRepository();
        }


        // GET: api/Funcionarios
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(funcionarioRepository.ListarTodos());
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
                foreach (var item in listaDeFuncionarios)
                {
                    if (item.Codigo == id)
                        return Ok(item);
                }
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

                listaDeFuncionarios.Add(funcionario);
                return Ok();

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

                foreach (var item in listaFuncionarios)
                    listaDeFuncionarios.Add(item);

                return Ok();

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

                    // Automapper. Utiliza recurso da máquina, pode utilizar, mas tome cuidado.

                    return Ok(item); // Tenho que retornar o item, para saber como ficou no bd.
                }

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
            catch (Exception)
            {
                // Logar Ex
                return InternalServerError();
            }
        }
    }
}
