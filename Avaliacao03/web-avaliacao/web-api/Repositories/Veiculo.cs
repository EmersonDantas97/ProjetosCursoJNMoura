using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace web_api.Repositories
{
    public class Veiculo
    {
        private readonly SqlConnection conn;
        private readonly SqlCommand cmd;

        public Veiculo(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        public async Task<List<Models.Veiculo>> GetAll()
        {
            List<Models.Veiculo> veiculos = new List<Models.Veiculo>();

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "SELECT Id, Marca, Nome, AnoModelo, DataFabricacao, Valor, Opcionais FROM Veiculos;";

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while(await dr.ReadAsync())
                    {
                        Models.Veiculo veiculo = new Models.Veiculo();

                        Mapper(dr, veiculo);

                        veiculos.Add(veiculo);
                    }
                }
            }

            return veiculos;
        }

        public async Task<Models.Veiculo> GetById(int id)
        {
            Models.Veiculo veiculo = new Models.Veiculo();

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "SELECT Id, Marca, Nome, AnoModelo, DataFabricacao, Valor, Opcionais FROM Veiculos WHERE Id = @Id;";

                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    if(await dr.ReadAsync())
                    {
                        Mapper(dr, veiculo);
                    }
                }
            }

            return veiculo;
        }

        public async Task<List<Models.Veiculo>> GetByName(string nome)
        {
            List<Models.Veiculo> veiculos = new List<Models.Veiculo>();

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "SELECT Id, Marca, Nome, AnoModelo, DataFabricacao, Valor, Opcionais FROM Veiculos WHERE Nome like @Nome;";

                    cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = $"%{nome}%";

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        Models.Veiculo veiculo = new Models.Veiculo();

                        Mapper(dr, veiculo);

                        veiculos.Add(veiculo);
                    }
                }
            }

            return veiculos;
        }

        public async Task Add(Models.Veiculo veiculo)
        {
            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "INSERT INTO Veiculos (Marca, Nome, AnoModelo, DataFabricacao, Valor, Opcionais) VALUES (@Marca, @Nome, @AnoModelo, @DataFabricacao, @Valor, @Opcionais);SELECT scope_identity();";

                    AdicionaParametrosPadroes(veiculo);

                    veiculo.Id = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
            }
        }

        public async Task<bool> Update(Models.Veiculo veiculo)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "UPDATE Veiculos SET Marca = @Marca, Nome = @Nome, AnoModelo = @AnoModelo, DataFabricacao = @DataFabricacao, Valor = @Valor, Opcionais = @Opcionais WHERE Id = @Id;";

                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = veiculo.Id;

                    AdicionaParametrosPadroes(veiculo);

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
                    cmd.CommandText = "DELETE FROM Veiculos WHERE Id = @Id;";

                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                    linhasAfetadas = await cmd.ExecuteNonQueryAsync();
                }
            }

            return linhasAfetadas == 1;
        }

        private void AdicionaParametrosPadroes(Models.Veiculo veiculo)
        {
            cmd.Parameters.Add(new SqlParameter("@Marca", SqlDbType.VarChar)).Value = veiculo.Marca;
            cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = veiculo.Nome;
            cmd.Parameters.Add(new SqlParameter("@AnoModelo", SqlDbType.Int)).Value = veiculo.AnoModelo;
            cmd.Parameters.Add(new SqlParameter("@DataFabricacao", SqlDbType.Date)).Value = veiculo.DataFabricacao;
            cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Decimal)).Value = veiculo.Valor;

            cmd.Parameters.Add(new SqlParameter("@Opcionais", SqlDbType.VarChar)).Value = 
                veiculo.Opcionais == null ? (object)DBNull.Value : veiculo.Opcionais;
        }

        private void Mapper(SqlDataReader dr, Models.Veiculo veiculo)
        {
            veiculo.Id = (int)dr["Id"];
            veiculo.Marca = (string)dr["Marca"];
            veiculo.Nome = (string)dr["Nome"];
            veiculo.AnoModelo = (int)dr["AnoModelo"];
            veiculo.DataFabricacao = (DateTime)dr["DataFabricacao"];
            veiculo.Valor = Convert.ToDouble(dr["Valor"]);
            veiculo.Opcionais = dr["Opcionais"].ToString();
        }
    }
}