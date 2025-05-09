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

                        carro.Id = (int) dr["Id"];
                        carro.Nome = (string) dr["Nome"];
                        carro.Valor = Convert.ToDouble(dr["Valor"]);

                        listaCarros.Add(carro);
                    }
                }
            }
                //conn.Close();
                //conn.Dispose(); // Marca para garbdge colector excluir da memória. 

            /*
                Reader = Pega dados. 2 colunas x 2 linhas = 4 dados.
                NonQuery = Insert, Update e Delete.
                Scalar = Retorna somente 1 dado.
             */

            return Ok(listaCarros);
        }

        // POST: api/Carros/Lote
        [HttpPost]
        [Route("api/Carros/Lote")]
        public IHttpActionResult PostLote([FromBody] List<Models.Carro> carros)
        {
            bool insertRealizado = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    foreach(var carro in carros)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = $"Insert into Carro (Nome, Valor) values ('{carro.Nome}',{carro.Valor})";

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            if (insertRealizado)
                return Ok();
            else
                return BadRequest();
        }

        // GET: api/Carros/5
        public IHttpActionResult Get(int id)
        {
            Carro carro = new Carro();

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
                        carro.Id = (int) dr["Id"];
                        carro.Nome = (string) dr["Nome"];
                        carro.Valor = Convert.ToDouble(dr["Valor"]);
                    }
                }

                if (carro.Id != null)
                    return Ok(carro);
                else
                    return BadRequest("Dados não encontrados para o ID informado!");
            }
        }

        // POST: api/Carros
        public IHttpActionResult Post([FromBody] Models.Carro carro)
        {
            bool insertRealizado = false;

            using 
            (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using 
                (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"Insert into Carro (Nome, Valor) values ('{carro.Nome}',{carro.Valor})";

                    // Se inserir uma linha
                    insertRealizado = cmd.ExecuteNonQuery() > 0 ? true : false ;
                }
            }

            if (insertRealizado)
                return Ok(Get());
            else
                return BadRequest();
        }

        // PUT: api/Carros/5
        public IHttpActionResult Put(int id, [FromBody] Models.Carro carro)
        {
            bool updateRealizado = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"Update Carro Set Nome = '{carro.Nome}', Valor = {carro.Valor} where Id = {id};";

                    // Se inserir uma linha
                    updateRealizado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }

            if (updateRealizado)
                return Ok();
            else
                return BadRequest();
        }

        // DELETE: api/Carros/5
        public IHttpActionResult Delete(int id)
        {
            bool deleteRealizado = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"Delete From Carro where Id = {id};";

                    // Se inserir uma linha
                    deleteRealizado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }

            if (deleteRealizado)
                return Ok();
            else
                return BadRequest();
        }
    }
}
