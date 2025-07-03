using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using web_api.Models;

namespace web_api.Repositories
{
    public class Pessoa
    {
        private readonly SqlCommand cmd;
        private readonly SqlConnection conn;
        public Pessoa(string connectionString)
        {
            cmd = new SqlCommand();
            conn = new SqlConnection(connectionString);
            cmd.Connection = conn;
        }
        public async Task<List<Models.Pessoa>> GetAll()
        {
            List<Models.Pessoa> listaPessoas = new List<Models.Pessoa>();

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Select Id, Nome, Idade from Pessoa;";

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        Models.Pessoa pessoa = new Models.Pessoa();

                        Mapper(dr, pessoa);

                        listaPessoas.Add(pessoa);
                    }
                } // Dispose feito pelo using;
            } // Dispose e close feitos pelo using;

            return listaPessoas;
        }
        public async Task<Models.Pessoa> GetById(int id)
        {
            Models.Pessoa pessoa = new Models.Pessoa();

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Select Id, Nome, Idade from Pessoa where Id = @Id;";

                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    if (await dr.ReadAsync())
                    {
                        Mapper(dr, pessoa);
                    }
                }
                return pessoa;
            }
        }
        public async Task<List<Models.Pessoa>> GetByName(string nome)
        {
            List<Models.Pessoa> listaDePessoas = new List<Models.Pessoa>();

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "SELECT Id, Nome, Idade FROM Pessoa WHERE Nome like @Nome;";

                    cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = $"%{nome}%";

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while(await dr.ReadAsync())
                    {
                        Models.Pessoa pessoa = new Models.Pessoa();

                        Mapper(dr, pessoa);

                        listaDePessoas.Add(pessoa);
                    }
                }
            }
            return listaDePessoas;
        }
        public async Task Add(Models.Pessoa pessoa)
        {
            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "INSERT INTO Pessoa (Nome, Idade) VALUES (@Nome, @Idade);SELECT scope_identity();";

                    cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = pessoa.Nome;
                    cmd.Parameters.Add(new SqlParameter("@Idade", SqlDbType.Int)).Value = pessoa.Idade;

                    pessoa.Id = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
            }
        }
        public async Task<bool> Update(Models.Pessoa pessoa)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "UPDATE Pessoa SET Nome = @Nome, Idade = @Idade WHERE Id = @Id;";

                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = pessoa.Id;
                    cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = pessoa.Nome;
                    cmd.Parameters.Add(new SqlParameter("@Idade", SqlDbType.Int)).Value = pessoa.Idade;

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
                    cmd.CommandText = "DELETE FROM Pessoa WHERE Id = @Id;";

                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                    linhasAfetadas = await cmd.ExecuteNonQueryAsync();
                }
            }
            return linhasAfetadas == 1;
        }
        private void Mapper(SqlDataReader dr, Models.Pessoa pessoa)
        {
            pessoa.Id = (int)dr["Id"];
            pessoa.Nome = (string)dr["Nome"];
            pessoa.Idade = Convert.ToInt32(dr["Idade"]);
        }

    }
}