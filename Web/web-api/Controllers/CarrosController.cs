using System.Collections.Generic;
using System.Web.Http;
using System.Data.SqlClient;
using web_api.Models;
using System.Data;
using System;
using System.IO;


namespace web_api.Controllers
{
    public class CarrosController : ApiController
    {
        private readonly string connectionString;
        private readonly string diretorioArqLogs;

        public CarrosController()
        {
            this.connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["web_api"].ConnectionString; // Utilizar o nome, para evitar erro de alguém inserir alguma conexao e mudar o indice;
            this.diretorioArqLogs = System.Configuration.ConfigurationManager.AppSettings["DiretorioLogs"];
        }

        // GET: api/Carros
        public IHttpActionResult Get()
        {
            List<Models.Carro> listaCarros = new List<Models.Carro>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Select Id, Nome, Valor from Carro;";

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Carro carro = new Carro();

                            carro.Id = (int)dr["Id"];
                            carro.Nome = (string)dr["Nome"];
                            carro.Valor = Convert.ToDouble(dr["Valor"]);

                            listaCarros.Add(carro);
                        }
                    } // Dispose feito pelo using;
                } // Dispose e close feitos pelo using;

                return Ok(listaCarros);
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

        // GET: api/Carros
        [Route("api/Carros/{nome}")]
        public IHttpActionResult Get(string nome)
        {
            if (nome.Length < 3)
                return BadRequest("Informe no mínimo 3 caracteres para pesquisar um carro!");
            
            try
            {
                List<Models.Carro> listaCarros = new List<Models.Carro>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Select Id, Nome, Valor from Carro where nome like @nome;";

                        cmd.Parameters.Add(new SqlParameter("@nome",SqlDbType.VarChar)).Value = $"%{nome}%";

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Carro carro = new Carro();

                            carro.Id = (int)dr["Id"];
                            carro.Nome = (string)dr["Nome"];
                            carro.Valor = Convert.ToDouble(dr["Valor"]);

                            listaCarros.Add(carro);
                        }
                    } // Dispose feito pelo using;
                } // Dispose e close feitos pelo using;

                return Ok(listaCarros);
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

        // GET: api/Carros/5
        public IHttpActionResult Get(int id)
        {
            Carro carro = new Carro();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Select Id, Nome, Valor from Carro where Id = @Id;";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            carro.Id = (int)dr["Id"];
                            carro.Nome = dr["Nome"].ToString();
                            carro.Valor = Convert.ToDouble(dr["Valor"]);
                        }
                    }

                    if (carro.Id == 0)
                        return NotFound();

                    return Ok(carro);
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

        // POST: api/Carros
        public IHttpActionResult Post([FromBody] Models.Carro carro)
        {
            if (carro == null)
                return BadRequest("Os dados do carro não foram enviados corretamente!");

            try
            {
                string scriptSql =
                    "Insert into Carro (Nome, Valor) values (@Nome,@Valor);Select scope_identity();";
                
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = scriptSql;

                        //Evitando sqlinjection. 
                        //cmd.Parameters.Add(new SqlParameter("@Nome",System.Data.SqlDbType.VarChar)).Value = carro.Nome;
                        //cmd.Parameters.Add(new SqlParameter("@Nome",System.Data.SqlDbType.VarChar,100)).Value = carro.Nome; -- Não colocar tamanho, pois vai truncar.
                        //cmd.Parameters.Add(new SqlParameter("@Valor",System.Data.SqlDbType.Decimal)).Value = carro.Valor;
                        //A instrução completa do sql, é montada pelo SGBD.

                        cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = carro.Nome;
                        cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Decimal)).Value = carro.Valor;

                        carro.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                return Ok(carro);
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

        // POST: api/Carros/Lote
        [HttpPost]
        [Route("api/Carros/Lote")]
        public IHttpActionResult PostLote([FromBody] List<Models.Carro> carros)
        {
            List<Carro> listaDeCarrosAdicionados = new List<Carro>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        foreach (var carro in carros)
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = "Insert into Carro (Nome, Valor) values (@Nome,@Valor);select scope_identity();";

                            cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = carro.Nome;
                            cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Decimal)).Value = carro.Valor;

                            carro.Id = Convert.ToInt32(cmd.ExecuteScalar());

                            listaDeCarrosAdicionados.Add(carro);
                        }
                    }
                }
                return Ok(listaDeCarrosAdicionados);
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

        // PUT: api/Carros/5
        public IHttpActionResult Put(int id, [FromBody] Models.Carro carro)
        {
            if (carro == null)
                return BadRequest("Os dados do carro não foram enviados corretamente!");

            if (carro.Id != id)
                return BadRequest("O Id da rota não corresponde ao Id do carro!");

            try
            {
                int linhasAfetadas = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Update Carro Set Nome = @Nome, Valor = @Valor where Id = @Id;";

                        cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = carro.Nome;
                        cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Decimal)).Value = carro.Valor;
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                        linhasAfetadas = cmd.ExecuteNonQuery();
                    }
                }

                if (linhasAfetadas == 1)
                    return Ok(carro);

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

        // DELETE: api/Carros/5
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
                        cmd.CommandText = "Delete From Carro where Id = @Id;";

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

//É utilizado o using para dispensar a utilização de:
//conn.Close();
//conn.Dispose(); // Marca para garbdge colector excluir da memória. 
//Reader = Pega dados. 2 colunas x 2 linhas = 4 dados.
//NonQuery = Insert, Update e Delete.
//Scalar = Retorna somente 1 dado.

