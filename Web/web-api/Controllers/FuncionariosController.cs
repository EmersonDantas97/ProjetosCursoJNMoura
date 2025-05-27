using web_api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace web_api.Controllers
{
    public class FuncionariosController : ApiController
    {
        private readonly string _conexao;
        private readonly string _diretorioLog;
        public FuncionariosController()
        {
            _conexao = Configurations.Config.GetConnectionString();
            _diretorioLog = Configurations.Config.GetLogPath();
        }

        // GET: api/Funcionarios
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                List<Funcionario> listaDeFuncionarios = new List<Funcionario>();

                string scriptSql =
                    "SELECT Codigo, CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario " +
                    "FROM Funcionario;";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = scriptSql;

                        SqlDataReader dr = await cmd.ExecuteReaderAsync();

                        while (await dr.ReadAsync())
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
                Utils.Logger.RegistraLog(_diretorioLog, ex);

                return InternalServerError();
            }
        }

        // GET: api/Funcionarios/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                string scriptSql =
                    "SELECT Codigo, CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario " +
                    "FROM Funcionario " +
                    "WHERE Codigo = @id;";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = scriptSql;

                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;

                        SqlDataReader dr = await cmd.ExecuteReaderAsync();

                        if (await dr.ReadAsync())
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
                Utils.Logger.RegistraLog(_diretorioLog, ex);
                
                return InternalServerError();
            }
        }

        // POST: api/Funcionarios
        public async Task<IHttpActionResult> Post([FromBody] Funcionario funcionario)
        {
            if (funcionario == null)
                return BadRequest("Os dados do funcionário não foram enviados corretamente!");

            try
            {
                string scriptSql =
                    "INSERT INTO Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) " +
                    "VALUES (@CodigoDepartamento, @PrimeiroNome, @SegundoNome, @UltimoNome, @DataNascimento, @CPF, @RG, @Endereco, @CEP, @Cidade, @Fone, @Funcao, @Salario); " +
                    "SELECT scope_identity();";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = scriptSql;

                        cmd.Parameters.Add(new SqlParameter("@CodigoDepartamento", SqlDbType.Int)).Value = funcionario.CodigoDepartamento;
                        cmd.Parameters.Add(new SqlParameter("@PrimeiroNome", SqlDbType.VarChar)).Value = funcionario.PrimeiroNome;
                        cmd.Parameters.Add(new SqlParameter("@SegundoNome", SqlDbType.VarChar)).Value = funcionario.SegundoNome;
                        cmd.Parameters.Add(new SqlParameter("@UltimoNome", SqlDbType.VarChar)).Value = funcionario.UltimoNome;
                        cmd.Parameters.Add(new SqlParameter("@DataNascimento", SqlDbType.Date)).Value = funcionario.DataNascimento;
                        cmd.Parameters.Add(new SqlParameter("@CPF", SqlDbType.VarChar)).Value = funcionario.CPF;
                        cmd.Parameters.Add(new SqlParameter("@RG", SqlDbType.VarChar)).Value = funcionario.RG;
                        cmd.Parameters.Add(new SqlParameter("@Endereco", SqlDbType.VarChar)).Value = funcionario.Endereco;
                        cmd.Parameters.Add(new SqlParameter("@CEP", SqlDbType.VarChar)).Value = funcionario.CEP;
                        cmd.Parameters.Add(new SqlParameter("@Cidade", SqlDbType.VarChar)).Value = funcionario.Cidade;
                        cmd.Parameters.Add(new SqlParameter("@Fone", SqlDbType.VarChar)).Value = funcionario.Fone;
                        cmd.Parameters.Add(new SqlParameter("@Funcao", SqlDbType.VarChar)).Value = funcionario.Funcao;
                        cmd.Parameters.Add(new SqlParameter("@Salario", SqlDbType.Decimal)).Value = funcionario.Salario;

                        funcionario.Codigo = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                    }
                }

                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                Utils.Logger.RegistraLog(_diretorioLog, ex);

                return InternalServerError();
            }
        }

        [Route("api/Funcionarios/batch")]
        // POST: api/Funcionarios
        public async Task<IHttpActionResult> Post([FromBody] List<Funcionario> listaFuncionarios)
        {
            if (listaFuncionarios == null)
                return BadRequest("Os dados do funcionário não foram enviados corretamente!");

            try
            {
                List<Funcionario> funcionariosAdicionados = new List<Funcionario>();

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    await conn.OpenAsync();


                    foreach (var funcionario in listaFuncionarios)
                    {
                        string scriptSql =
                            "INSERT INTO Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) " +
                            "VALUES (@CodigoDepartamento, @PrimeiroNome, @SegundoNome, @UltimoNome, @DataNascimento, @CPF, @RG, @Endereco, @CEP, @Cidade, @Fone, @Funcao, @Salario); " +
                            "SELECT scope_identity();";

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = scriptSql;

                            cmd.Parameters.Add(new SqlParameter("@CodigoDepartamento", SqlDbType.Int)).Value = funcionario.CodigoDepartamento;
                            cmd.Parameters.Add(new SqlParameter("@PrimeiroNome", SqlDbType.VarChar)).Value = funcionario.PrimeiroNome;
                            cmd.Parameters.Add(new SqlParameter("@SegundoNome", SqlDbType.VarChar)).Value = funcionario.SegundoNome;
                            cmd.Parameters.Add(new SqlParameter("@UltimoNome", SqlDbType.VarChar)).Value = funcionario.UltimoNome;
                            cmd.Parameters.Add(new SqlParameter("@DataNascimento", SqlDbType.Date)).Value = funcionario.DataNascimento;
                            cmd.Parameters.Add(new SqlParameter("@CPF", SqlDbType.VarChar)).Value = funcionario.CPF;
                            cmd.Parameters.Add(new SqlParameter("@RG", SqlDbType.VarChar)).Value = funcionario.RG;
                            cmd.Parameters.Add(new SqlParameter("@Endereco", SqlDbType.VarChar)).Value = funcionario.Endereco;
                            cmd.Parameters.Add(new SqlParameter("@CEP", SqlDbType.VarChar)).Value = funcionario.CEP;
                            cmd.Parameters.Add(new SqlParameter("@Cidade", SqlDbType.VarChar)).Value = funcionario.Cidade;
                            cmd.Parameters.Add(new SqlParameter("@Fone", SqlDbType.VarChar)).Value = funcionario.Fone;
                            cmd.Parameters.Add(new SqlParameter("@Funcao", SqlDbType.VarChar)).Value = funcionario.Funcao;
                            cmd.Parameters.Add(new SqlParameter("@Salario", SqlDbType.Decimal)).Value = funcionario.Salario;

                            funcionario.Codigo = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                            funcionariosAdicionados.Add(funcionario);
                        }
                    }
                }

                return Ok(funcionariosAdicionados);
            }
            catch (Exception ex)
            {
                Utils.Logger.RegistraLog(_diretorioLog, ex);

                return InternalServerError();
            }
        }

        // PUT: api/Funcionarios/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Funcionario funcionario)
        {
            if (funcionario == null)
                return BadRequest("Os dados do funcionário não foram enviados corretamente!");

            if (funcionario.Codigo != id)
                return BadRequest("O Id da rota não corresponde ao código do funcionário");

            try
            {
                int linhasAfetadas = 0;

                string scriptSql =
                    "UPDATE Funcionario " +
                    "Set PrimeiroNome = @PrimeiroNome, " +
                    "SegundoNome = @SegundoNome, " +
                    "UltimoNome = @UltimoNome, " +
                    "CodigoDepartamento = @CodigoDepartamento, " +
                    "DataNascimento = @DataNascimento, " +
                    "CPF = @CPF, " +
                    "RG = @RG, " +
                    "Endereco = @Endereco, " +
                    "CEP = @CEP, " +
                    "Cidade = @Cidade, " +
                    "Fone = @Fone, " +
                    "Funcao = @Funcao, " +
                    "Salario = @Salario " +
                    "WHERE Codigo = @Id;";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = scriptSql;

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = funcionario.Codigo;
                        cmd.Parameters.Add(new SqlParameter("@CodigoDepartamento", SqlDbType.Int)).Value = funcionario.CodigoDepartamento;
                        cmd.Parameters.Add(new SqlParameter("@PrimeiroNome", SqlDbType.VarChar)).Value = funcionario.PrimeiroNome;
                        cmd.Parameters.Add(new SqlParameter("@SegundoNome", SqlDbType.VarChar)).Value = funcionario.SegundoNome;
                        cmd.Parameters.Add(new SqlParameter("@UltimoNome", SqlDbType.VarChar)).Value = funcionario.UltimoNome;
                        cmd.Parameters.Add(new SqlParameter("@DataNascimento", SqlDbType.Date)).Value = funcionario.DataNascimento;
                        cmd.Parameters.Add(new SqlParameter("@CPF", SqlDbType.VarChar)).Value = funcionario.CPF;
                        cmd.Parameters.Add(new SqlParameter("@RG", SqlDbType.VarChar)).Value = funcionario.RG;
                        cmd.Parameters.Add(new SqlParameter("@Endereco", SqlDbType.VarChar)).Value = funcionario.Endereco;
                        cmd.Parameters.Add(new SqlParameter("@CEP", SqlDbType.VarChar)).Value = funcionario.CEP;
                        cmd.Parameters.Add(new SqlParameter("@Cidade", SqlDbType.VarChar)).Value = funcionario.Cidade;
                        cmd.Parameters.Add(new SqlParameter("@Fone", SqlDbType.VarChar)).Value = funcionario.Fone;
                        cmd.Parameters.Add(new SqlParameter("@Funcao", SqlDbType.VarChar)).Value = funcionario.Funcao;
                        cmd.Parameters.Add(new SqlParameter("@Salario", SqlDbType.Decimal)).Value = funcionario.Salario;

                        linhasAfetadas = await cmd.ExecuteNonQueryAsync();
                    }
                }

                if (linhasAfetadas > 0)
                    return Ok(funcionario);

                return NotFound();
            }
            catch (Exception ex)
            {
                Utils.Logger.RegistraLog(_diretorioLog, ex);

                return InternalServerError();
            }
        }

        // DELETE: api/Funcionarios/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                int linhasAfetadas = 0;

                string scriptSql =
                    "DELETE FROM Funcionario " +
                    "WHERE Codigo = @Id;";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = scriptSql;

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                        linhasAfetadas = await cmd.ExecuteNonQueryAsync();
                    }
                }

                if (linhasAfetadas > 0)
                    return Ok();

                return NotFound();
            }
            catch (Exception ex)
            {
                Utils.Logger.RegistraLog(_diretorioLog, ex);

                return InternalServerError();
            }
        }
    }
}


// 60% da memória o dotnet derruba a aplicação. Este número é configurável.