using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace web_api.Controllers
{
    public class ProdutosController : ApiController
    {
        private readonly string _conexao;
        private readonly string _diretorioLogs;

        public ProdutosController()
        {
            _conexao = System.Configuration.ConfigurationManager.ConnectionStrings["web_api"].ConnectionString;
            _diretorioLogs = System.Configuration.ConfigurationManager.AppSettings["DiretorioLogs"];
        }

        // GET: api/Produtos
        public IHttpActionResult Get()
        {
            try
            {
                string scriptSql =
                    "Select Id, Nome, Valor, DataCadastro From Produto Where StatusProduto = 0;";
                
                List<Models.Produto> listaDeProdutos = new List<Models.Produto>();

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(scriptSql, conn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Models.Produto produto = new Models.Produto();

                            produto.Id = (int)dr["Id"];
                            produto.Nome = (string)dr["Nome"]; // Não pode ser nulo.
                            produto.Valor = Convert.ToDouble(dr["Valor"]);
                            produto.DataCadastro = (DateTime)dr["DataCadastro"];
                            produto.StatusProduto = 0;

                            listaDeProdutos.Add(produto);

                        }
                    }
                }

                return Ok(listaDeProdutos);
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(_diretorioLogs, true))
                {
                    sw.Write("Data e Hora: ");
                    sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.Write("Erro: ");
                    sw.Write(ex.Message);
                    sw.Write("StackTrace: ");
                    sw.Write(ex.StackTrace);
                    sw.WriteLine();
                }

                return InternalServerError();
            }
        }

        // GET: api/Produtos/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                string scriptSql =
                    "Select Id, Nome, Valor, DataCadastro From Produto Where Id = @Id and StatusProduto = 0;";

                Models.Produto produto = new Models.Produto();

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(scriptSql, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            produto.Id = (int)dr["Id"];
                            produto.Nome = (string)dr["Nome"];
                            produto.Valor = Convert.ToDouble(dr["Valor"]);
                            produto.DataCadastro = (DateTime)dr["DataCadastro"];
                            produto.StatusProduto = (Models.StatusProduto)0;
                        }
                    }
                }
                if (produto.Id != 0)
                    return Ok(produto);

                return NotFound();
            }
            catch (Exception ex)
            {
                using (StreamWriter sw  = new StreamWriter(_diretorioLogs, true))
                {
                    sw.Write("Data e Hora: ");
                    sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.Write("Erro: ");
                    sw.Write(ex.Message);
                    sw.Write("StackTrace: ");
                    sw.Write(ex.StackTrace);
                    sw.WriteLine();
                }

                return InternalServerError();
            }
        }

        // POST: api/Produtos
        public IHttpActionResult Post([FromBody] Models.Produto produto)
        {
            if (produto == null)
                return BadRequest("Os dados do produto não foram encaminhados corretamente!");

            if (produto.Nome.Length < 4)
                return BadRequest("O nome do produto precisa ter NO MÍNIMO 4 LETRAS.");

            if (produto.Valor <= 0)
                return BadRequest("O valor do produto não pode ser NEGATIVO ou MENOR QUE ZERO.");

            try
            {
                string scriptSql =
                    "Insert into Produto (Nome, Valor, DataCadastro, StatusProduto) Values (@Nome, @Valor, @DataCadastro, @StatusProduto);" +
                    "Select scope_identity();";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(scriptSql, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = produto.Nome;
                        cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Decimal)).Value = produto.Valor;
                        cmd.Parameters.Add(new SqlParameter("@DataCadastro", SqlDbType.DateTime)).Value = DateTime.Now;
                        cmd.Parameters.Add(new SqlParameter("@StatusProduto", SqlDbType.Int)).Value = 0;

                        produto.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(_diretorioLogs, true))
                {
                    sw.Write("Data e Hora: ");
                    sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.Write("Erro: ");
                    sw.Write(ex.Message);
                    sw.Write("StackTrace: ");
                    sw.Write(ex.StackTrace);
                    sw.WriteLine();
                }

                return InternalServerError();
            }
        }

        // PUT: api/Produtos/5
        public IHttpActionResult Put(int id, [FromBody] Models.Produto produto)
        {
            if (produto.Id != id)
                return BadRequest("O id do produto não corresponde com o id da rota!");

            if(produto == null)
                return BadRequest("Os dados do produto não foram encaminhados corretamente!");

            if (produto.Nome.Length < 4)
                return BadRequest("O nome do produto precisa ter NO MÍNIMO 4 LETRAS.");

            if (produto.Valor <= 0)
                return BadRequest("O valor do produto não pode ser NEGATIVO ou MENOR QUE ZERO."); 

            try
            {
                int linhasAfetadas = 0;

                string scriptSql =
                    "Update Produto Set Nome = @Nome, Valor = @Valor, DataCadastro = @DataCadastro, StatusProduto = @StatusProduto Where Id = @Id;";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    conn.Open();

                    using (SqlCommand cmd =new SqlCommand(scriptSql, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;
                        cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = produto.Nome;
                        cmd.Parameters.Add(new SqlParameter("@DataCadastro", SqlDbType.DateTime)).Value = DateTime.Now;
                        cmd.Parameters.Add(new SqlParameter("@StatusProduto", SqlDbType.Int)).Value = produto.StatusProduto;

                        linhasAfetadas = cmd.ExecuteNonQuery();
                    }
                }

                if (linhasAfetadas != 0)
                    return Ok();

                return NotFound();
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(_diretorioLogs, true))
                {
                    sw.Write("Data e Hora: ");
                    sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.Write("Erro: ");
                    sw.Write(ex.Message);
                    sw.Write("StackTrace: ");
                    sw.Write(ex.StackTrace);
                    sw.WriteLine();
                }

                return InternalServerError();
            }
        }

        // DELETE: api/Produtos/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int linhasAfetadas = 0;

                string scriptSql =
                    "Delete from Produto Where Id = @Id";

                using (SqlConnection conn = new SqlConnection(_conexao))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(scriptSql, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                        linhasAfetadas = cmd.ExecuteNonQuery();
                    }
                }

                if (linhasAfetadas != 0)
                    return Ok();

                return NotFound();
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(_diretorioLogs, true))
                {
                    sw.Write("Data e Hora: ");
                    sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.Write("Erro: ");
                    sw.Write(ex.Message);
                    sw.Write("StackTrace: ");
                    sw.Write(ex.StackTrace);
                    sw.WriteLine();
                }

                return InternalServerError();
            }
        }
    }
}
