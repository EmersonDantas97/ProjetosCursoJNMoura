using web_api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;

namespace web_api.Controllers
{
    public class FuncionariosController : ApiController
    {
        private readonly string _conexao;
        public FuncionariosController()
        {
            _conexao = ConfigurationManager.ConnectionStrings["ConexaoFuncionario"].ConnectionString;
            // _conexao = @"Server=DESKTOP-7TLUK34;Database=web-api;Trusted_Connection=True;";
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
                            
                            funcionario.Codigo = (int)dr["Codigo"];
                            funcionario.CodigoDepartamento = (int)dr["CodigoDepartamento"];
                            funcionario.PrimeiroNome = (string)dr["PrimeiroNome"];
                            funcionario.SegundoNome = dr["SegundoNome"].ToString();
                            funcionario.UltimoNome = (string)dr["UltimoNome"];
                            funcionario.DataNascimento = (DateTime)dr["DataNascimento"];
                            funcionario.CPF = (string)dr["CPF"];
                            funcionario.RG = (string)dr["RG"];
                            funcionario.Endereco = (string)dr["Endereco"];
                            funcionario.CEP = (string)dr["CEP"];
                            funcionario.Cidade = (string)dr["Cidade"];
                            funcionario.Fone = (string)dr["Fone"];
                            funcionario.Funcao = (string)dr["Funcao"];
                            funcionario.Salario = Convert.ToDouble(dr["Salario"]);

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
                    $"WHERE Codigo = {id};";

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

                            funcionario.Codigo = (int)dr["Codigo"];
                            funcionario.CodigoDepartamento = (int)dr["CodigoDepartamento"];
                            funcionario.PrimeiroNome = (string)dr["PrimeiroNome"];
                            funcionario.SegundoNome = dr["SegundoNome"].ToString();
                            funcionario.UltimoNome = (string)dr["UltimoNome"];
                            funcionario.DataNascimento = (DateTime)dr["DataNascimento"];
                            funcionario.CPF = (string)dr["CPF"];
                            funcionario.RG = (string)dr["RG"];
                            funcionario.Endereco = (string)dr["Endereco"];
                            funcionario.CEP = (string)dr["CEP"];
                            funcionario.Cidade = (string)dr["Cidade"];
                            funcionario.Fone = (string)dr["Fone"];
                            funcionario.Funcao = (string)dr["Funcao"];
                            funcionario.Salario = Convert.ToDouble(dr["Salario"]);

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
                    return BadRequest("Os dados do funcionário não foram enviados corretamente!");

                string scriptSql =
                    "INSERT INTO Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) " +
                    $"VALUES ({funcionario.CodigoDepartamento}, '{funcionario.PrimeiroNome}', '{funcionario.SegundoNome}', '{funcionario.UltimoNome}', '{funcionario.DataNascimento}', '{funcionario.CPF}', '{funcionario.RG}', '{funcionario.Endereco}', '{funcionario.CEP}', '{funcionario.Cidade}', '{funcionario.Fone}', '{funcionario.Funcao}', {funcionario.Salario}); " +
                    $"SELECT scope_identity();";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = scriptSql;


                        funcionario.Codigo = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("api/Funcionarios/batch")]
        // POST: api/Funcionarios
        public IHttpActionResult Post([FromBody] List<Funcionario> listaFuncionarios)
        {
            try
            {
                List<Funcionario> funcionariosAdicionados = new List<Funcionario>();


                if (listaFuncionarios == null)
                    return BadRequest("Os dados do funcionário não foram enviados corretamente!");

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    conn.Open();


                    foreach (var funcionario in listaFuncionarios)
                    {
                        string scriptSql =
                            "INSERT INTO Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) " +
                            $"VALUES ({funcionario.CodigoDepartamento}, '{funcionario.PrimeiroNome}', '{funcionario.SegundoNome}', '{funcionario.UltimoNome}', '{funcionario.DataNascimento}', '{funcionario.CPF}', '{funcionario.RG}', '{funcionario.Endereco}', '{funcionario.CEP}', '{funcionario.Cidade}', '{funcionario.Fone}', '{funcionario.Funcao}', {funcionario.Salario}); " +
                            $"SELECT scope_identity();";

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = scriptSql;

                            funcionario.Codigo = Convert.ToInt32(cmd.ExecuteScalar());

                            funcionariosAdicionados.Add(funcionario);
                        } 
                    }
                }

                return Ok(funcionariosAdicionados);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Funcionarios/5
        public IHttpActionResult Put(int id, [FromBody] Funcionario funcionario)
        {
            try
            {
                if (funcionario == null)
                    return BadRequest("Os dados do funcionário não foram enviados corretamente!");

                if (funcionario.Codigo != id)
                    return BadRequest("O Id da rota não corresponde ao código do funcionário");

                int linhasAfetadas = 0;

                string scriptSql =
                    "UPDATE Funcionario " +
                    $"Set PrimeiroNome = '{funcionario.PrimeiroNome}', " +
                    $"SegundoNome = '{funcionario.SegundoNome}', " +
                    $"UltimoNome = '{funcionario.UltimoNome}', " +
                    $"CodigoDepartamento = {funcionario.CodigoDepartamento}, " +
                    $"DataNascimento = '{funcionario.DataNascimento}', " +
                    $"CPF = '{funcionario.CPF}', " +
                    $"RG = '{funcionario.RG}', " +
                    $"Endereco = '{funcionario.Endereco}', " +
                    $"CEP = '{funcionario.CEP}', " +
                    $"Cidade = '{funcionario.Cidade}', " +
                    $"Fone = '{funcionario.Fone}', " +
                    $"Funcao = '{funcionario.Funcao}', " +
                    $"Salario = {funcionario.Salario} " +
                    $"WHERE Codigo = {id};";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = scriptSql;

                        linhasAfetadas = cmd.ExecuteNonQuery();
                    }
                }

                if (linhasAfetadas > 0)
                    return Ok(funcionario);

                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Funcionarios/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int linhasAfetadas = 0;

                string scriptSql =
                    "DELETE FROM Funcionario " +
                    $"WHERE Codigo = {id};";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = scriptSql;

                        linhasAfetadas = cmd.ExecuteNonQuery();
                    }
                }

                if (linhasAfetadas > 0)
                    return Ok();

                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
