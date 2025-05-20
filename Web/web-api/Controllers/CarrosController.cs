using System.Collections.Generic;
using System.Web.Http;
using System.Data.SqlClient;
using web_api.Models;
using System;

namespace web_api.Controllers
{
    public class CarrosController : ApiController
    {
        private readonly string connectionString;

        public CarrosController()
        {
            this.connectionString = "Server=DESKTOP-7TLUK34;Database=web-api;Trusted_Connection=True;";
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
                return InternalServerError(ex);
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
                        cmd.CommandText = $"Select Id, Nome, Valor from Carro where Id = {id};";

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
                return InternalServerError(ex);
            }
        }
        // POST: api/Carros
        public IHttpActionResult Post([FromBody] Models.Carro carro)
        {
            try
            {
                if (carro == null)
                    return BadRequest("Os dados do carro não foram enviados corretamente!");
                
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = $"Insert into Carro (Nome, Valor) values ('{carro.Nome}',{carro.Valor});Select scope_identity();";

                        carro.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                return Ok(carro);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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
                            cmd.CommandText = $"Insert into Carro (Nome, Valor) values ('{carro.Nome}',{carro.Valor});select scope_identity();";

                            carro.Id = Convert.ToInt32(cmd.ExecuteScalar());

                            listaDeCarrosAdicionados.Add(carro);
                        }
                    }
                }
                return Ok(listaDeCarrosAdicionados);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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
                        cmd.CommandText = $"Update Carro Set Nome = '{carro.Nome}', Valor = {carro.Valor} where Id = {id};";

                        linhasAfetadas = cmd.ExecuteNonQuery();
                    }
                }

                if (linhasAfetadas == 1)
                    return Ok(carro);

                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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
                        cmd.CommandText = $"Delete From Carro where Id = {id};";

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
                return InternalServerError(ex);
            }
        }
    }
}

//É utilizado o using para dispensar a utilização de:
//conn.Close();
//conn.Dispose(); // Marca para garbdge colector excluir da memória. 

/*
    Reader = Pega dados. 2 colunas x 2 linhas = 4 dados.
    NonQuery = Insert, Update e Delete.
    Scalar = Retorna somente 1 dado.
 */

