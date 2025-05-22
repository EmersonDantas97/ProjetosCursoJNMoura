using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web_api.Models;

namespace web_api.Controllers
{
    public class PessoasController : ApiController
    {
        private readonly string connectionString;
        private readonly string diretorioArqLogs;

        public PessoasController()
        {
            this.connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["web_api"].ConnectionString; // Utilizar o nome, para evitar erro de alguém inserir alguma conexao e mudar o indice;
            this.diretorioArqLogs = System.Configuration.ConfigurationManager.AppSettings["DiretorioLogs"];
        }

        // GET: api/Pessoas
        public IHttpActionResult Get()
        {
            List<Models.Pessoa> listaPessoas = new List<Pessoa>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Select Id, Nome, Idade from Pessoa;";

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Models.Pessoa pessoa = new Models.Pessoa();

                            pessoa.Id = (int)dr["Id"];
                            pessoa.Nome = (string)dr["Nome"];
                            pessoa.Idade = Convert.ToInt32(dr["Idade"]);

                            listaPessoas.Add(pessoa);
                        }
                    } // Dispose feito pelo using;
                } // Dispose e close feitos pelo using;

                return Ok(listaPessoas);
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(diretorioArqLogs, true))
                {
                    sw.Write("Data:");
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.Write("Erro:");
                    sw.WriteLine(ex.Message);
                    sw.Write("StackTrace:");
                    sw.WriteLine(ex.StackTrace);
                    sw.WriteLine();
                }

                return InternalServerError();
            }
        }

        // GET: api/Pessoas/5
        public IHttpActionResult Get(int id)
        {
            Pessoa pessoa = new Pessoa();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Select Id, Nome, Idade from Pessoa where Id = @Id;";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            pessoa.Id = (int)dr["Id"];
                            pessoa.Nome = dr["Nome"].ToString();
                            pessoa.Idade = Convert.ToInt32(dr["Idade"]);
                        }
                    }

                    if (pessoa.Id == 0)
                        return NotFound();

                    return Ok(pessoa);
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(diretorioArqLogs, true))
                {
                    sw.Write("Data:");
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.Write("Erro:");
                    sw.WriteLine(ex.Message);
                    sw.Write("StackTrace:");
                    sw.WriteLine(ex.StackTrace);
                    sw.WriteLine();
                }

                return InternalServerError();
            }
        }

        // GET: api/Pessoas/5
        public IHttpActionResult Get(string nome)
        {
            Pessoa pessoa = new Pessoa();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Select Id, Nome, Idade from Pessoa where Nome = @Nome;";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = $"%{nome}%";

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            pessoa.Id = (int)dr["Id"];
                            pessoa.Nome = dr["Nome"].ToString();
                            pessoa.Idade = Convert.ToInt32(dr["Idade"]);
                        }
                    }

                    if (pessoa.Id == 0)
                        return NotFound();

                    return Ok(pessoa);
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(diretorioArqLogs, true))
                {
                    sw.Write("Data:");
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.Write("Erro:");
                    sw.WriteLine(ex.Message);
                    sw.Write("StackTrace:");
                    sw.WriteLine(ex.StackTrace);
                    sw.WriteLine();
                }

                return InternalServerError();
            }
        }

        // POST: api/Pessoas
        public IHttpActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
                return BadRequest("Os dados da pessoa não foram enviados corretamente!");

            try
            {
                string scriptSql =
                    "Insert into Pessoa (Nome, Idade) values (@Nome,@Idade);Select scope_identity();";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = scriptSql;

                        //Evitando sqlinjection. 
                        //cmd.Parameters.Add(new SqlParameter("@Nome",System.Data.SqlDbType.VarChar)).Value = carro.Nome;
                        //cmd.Parameters.Add(new SqlParameter("@Nome",System.Data.SqlDbType.VarChar,100)).Value = carro.Nome; -- Não colocar tamanho, pois vai truncar.
                        //cmd.Parameters.Add(new SqlParameter("@Valor",System.Data.SqlDbType.Decimal)).Value = carro.Valor;
                        //A instrução completa do sql, é montada pelo SGBD.

                        cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = pessoa.Nome;
                        cmd.Parameters.Add(new SqlParameter("@Idade", SqlDbType.Int)).Value = pessoa.Idade;

                        pessoa.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(diretorioArqLogs, true))
                {
                    sw.Write("Data:");
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.Write("Erro:");
                    sw.WriteLine(ex.Message);
                    sw.Write("StackTrace:");
                    sw.WriteLine(ex.StackTrace);
                    sw.WriteLine();
                }

                return InternalServerError();
            }
        }

        // PUT: api/Pessoas/5
        public IHttpActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
                return BadRequest("Os dados da pessoa não foram enviados corretamente!");

            if (pessoa.Id != id)
                return BadRequest("O Id da rota não corresponde ao Id da pessoa!");

            try
            {
                int linhasAfetadas = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Update Pessoa Set Nome = @Nome, Idade = @Idade where Id = @Id;";

                        cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = pessoa.Nome;
                        cmd.Parameters.Add(new SqlParameter("@Idade", SqlDbType.Int)).Value = pessoa.Idade;
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                        linhasAfetadas = cmd.ExecuteNonQuery();
                    }
                }

                if (linhasAfetadas == 1)
                    return Ok(pessoa);

                return NotFound();
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(diretorioArqLogs, true))
                {
                    sw.Write("Data:");
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.Write("Erro:");
                    sw.WriteLine(ex.Message);
                    sw.Write("StackTrace:");
                    sw.WriteLine(ex.StackTrace);
                    sw.WriteLine();
                }

                return InternalServerError();
            }
        }

        // DELETE: api/Pessoas/5
        public IHttpActionResult Delete(int id)
        {
            int linhasAfetadas = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Delete From Pessoa where Id = @Id;";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                        // Se inserir uma linha
                        linhasAfetadas = cmd.ExecuteNonQuery();
                    }
                }

                if (linhasAfetadas != 0)
                    return Ok();

                return NotFound();
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(diretorioArqLogs, true))
                {
                    sw.Write("Data:");
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.Write("Erro:");
                    sw.WriteLine(ex.Message);
                    sw.Write("StackTrace:");
                    sw.WriteLine(ex.StackTrace);
                    sw.WriteLine();
                }

                return InternalServerError();
            }
        }
    }
}