using web_api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using web_api.Repository;
using System.Data.SqlClient;
using System.Configuration;

namespace web_api.Controllers
{
    public class FuncionariosController : ApiController
    {
        private readonly FuncionarioRepository funcionarioRepositorio;
        private readonly string _conexao;
        public FuncionariosController()
        {
            _conexao = ConfigurationManager.ConnectionStrings["ConexaoFuncionario"].ConnectionString;
            // _conexao = @"Server=DESKTOP-7TLUK34;Database=web-api;Trusted_Connection=True;";

            funcionarioRepositorio = new FuncionarioRepository();
        }

        // GET: api/Funcionarios
        public IHttpActionResult Get()
        {
            try
            {
                List<Funcionario> listaDeFuncionarios = new List<Funcionario>();

                string scriptSql =
                    "SELECT Codigo, CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario " +
                    "FROM Funcionario;";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = scriptSql;

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            var funcionario = new Funcionario();
                            
                            funcionario.Codigo = (int)dr["Id"];
                            funcionario.CodigoDepartamento = (int)dr["CodigoDepartamento"];
                            funcionario.PrimeiroNome = (string)dr["PrimeiroNome"];
                            funcionario.SegundoNome = (string)dr["SegundoNome"];
                            funcionario.UltimoNome = (string)dr["UltimoNome"];
                            funcionario.DataNascimento = (DateTime)dr["DataNascimento"];
                            funcionario.CPF = (string)dr["CPF"];
                            funcionario.RG = (string)dr["RG"];
                            funcionario.Endereco = (string)dr["Endereco"];
                            funcionario.CEP = (string)dr["CEP"];
                            funcionario.Cidade = (string)dr["Cidade"];
                            funcionario.Fone = (string)dr["Fone"];
                            funcionario.Funcao = (string)dr["Funcao"];
                            funcionario.Salario = Convert.ToDouble(dr["Funcao"]);

                            listaDeFuncionarios.Add(funcionario);
                        }
                    }
                }

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
            try
            {
                string scriptSql =
                    "SELECT Codigo, CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario " +
                    "FROM Funcionario " +
                    $"WHERE Id = {id};";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = scriptSql;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            var funcionario = new Funcionario();

                            funcionario.Codigo = (int)dr["Id"];
                            funcionario.CodigoDepartamento = (int)dr["CodigoDepartamento"];
                            funcionario.PrimeiroNome = (string)dr["PrimeiroNome"];
                            funcionario.SegundoNome = (string)dr["SegundoNome"];
                            funcionario.UltimoNome = (string)dr["UltimoNome"];
                            funcionario.DataNascimento = (DateTime)dr["DataNascimento"];
                            funcionario.CPF = (string)dr["CPF"];
                            funcionario.RG = (string)dr["RG"];
                            funcionario.Endereco = (string)dr["Endereco"];
                            funcionario.CEP = (string)dr["CEP"];
                            funcionario.Cidade = (string)dr["Cidade"];
                            funcionario.Fone = (string)dr["Fone"];
                            funcionario.Funcao = (string)dr["Funcao"];
                            funcionario.Salario = Convert.ToDouble(dr["Funcao"]);

                            if (funcionario.Codigo != 0)
                                return Ok(funcionario);
                        }
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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
                Funcionario funcionarioDeletado = funcionarioRepositorio.Excluir(id);

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
