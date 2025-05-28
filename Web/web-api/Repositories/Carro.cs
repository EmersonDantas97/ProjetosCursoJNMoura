using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace web_api.Repositories
{
    public class Carro
    {
        readonly SqlConnection conn;
        readonly SqlCommand cmd;
        public Carro(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }
        public async Task<List<Models.Carro>> GetAll()
        {
            List<Models.Carro> listaCarros = new List<Models.Carro>();

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Select Id, Nome, Valor from Carro;";

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (dr.Read())
                    {
                        Models.Carro carro = new Models.Carro();

                        Mapper(carro, dr);

                        listaCarros.Add(carro);
                    }
                } // Dispose feito pelo using;
            } // Dispose e close feitos pelo using;

            return listaCarros;
        }
        public async Task<Models.Carro> GetById(int id)
        {
            Models.Carro carro = new Models.Carro();

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Select Id, Nome, Valor from Carro where Id = @Id;";

                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    if (await dr.ReadAsync())
                    {
                        Mapper(carro, dr);
                    }
                }
            }
            return carro;
        }
        public async Task<List<Models.Carro>> GetByName(string nome)
        {
            List<Models.Carro> listaCarros = new List<Models.Carro>();

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Select Id, Nome, Valor from Carro where nome like @nome;";

                    cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = $"%{nome}%";

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        Models.Carro carro = new Models.Carro();

                        Mapper(carro, dr);

                        listaCarros.Add(carro);
                    }
                } // Dispose feito pelo using;
            } // Dispose e close feitos pelo using;

            return listaCarros;
        }
        public async Task Add(Models.Carro carro)
        {
            string scriptSql =
                "Insert into Carro (Nome, Valor) values (@Nome,@Valor);Select scope_identity();";

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = scriptSql;

                    //Evitando sqlinjection. 
                    //cmd.Parameters.Add(new SqlParameter("@Nome",System.Data.SqlDbType.VarChar)).Value = carro.Nome;
                    //cmd.Parameters.Add(new SqlParameter("@Nome",System.Data.SqlDbType.VarChar,100)).Value = carro.Nome; -- Não colocar tamanho, pois vai truncar.
                    //cmd.Parameters.Add(new SqlParameter("@Valor",System.Data.SqlDbType.Decimal)).Value = carro.Valor;
                    //A instrução completa do sql, é montada pelo SGBD.

                    cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = carro.Nome;
                    cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Decimal)).Value = carro.Valor;

                    carro.Id = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
            }
        }
        public async Task<bool> Update(Models.Carro carro)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Update Carro Set Nome = @Nome, Valor = @Valor where Id = @Id;";

                    cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = carro.Nome;
                    cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Decimal)).Value = carro.Valor;
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = carro.Id;

                    linhasAfetadas = await cmd.ExecuteNonQueryAsync();
                }
            }
            return linhasAfetadas == 1;
        }
        public async Task<bool> Delete(int id)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Delete From Carro where Id = @Id;";

                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                    // Se inserir uma linha
                    linhasAfetadas = await cmd.ExecuteNonQueryAsync();
                }
            }
            return linhasAfetadas == 1;
        }
        private void Mapper(Models.Carro carro, SqlDataReader dr)
        {
            carro.Id = (int)dr["Id"];
            carro.Nome = (string)dr["Nome"];
            carro.Valor = Convert.ToDouble(dr["Valor"]);
        }
    }
}
