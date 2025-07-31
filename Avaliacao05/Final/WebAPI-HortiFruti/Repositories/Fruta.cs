using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebAPI_HortiFruti.Utils.Cache;
using System.Data;

namespace WebAPI_HortiFruti.Repositories.SQLServer
{
    public class Fruta : IRepository<Models.Fruta>
    {
        private readonly SqlConnection conn;
        private readonly SqlCommand cmd;

        private readonly string keyCache;
        private readonly ICacheService cacheService;
        public int CacheExpirationTime { get; set; }


        public Fruta(string connectionString)
        {

            conn = new SqlConnection(connectionString);

            cmd = new SqlCommand();
            cmd.Connection = conn;

            cacheService = new MemoryCacheService();
            keyCache = "frutas";

            CacheExpirationTime = 30;

        }


        public async Task AddAsync(Models.Fruta fruta)
        {
            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Insert into Frutas (Nome, DataVenc) Values (@nome, @datavenc);Select scope_identity();";

                    AdicionaParametrosPadrao(fruta);

                    fruta.Id = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                    cacheService.Remove(keyCache);
                }
            }
        }

        private void AdicionaParametrosPadrao(Models.Fruta fruta)
        {
            cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = fruta.Nome;
            cmd.Parameters.Add(new SqlParameter("@datavenc", SqlDbType.Date)).Value = fruta.DataVenc;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Delete from Frutas where Id = @id;";

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;

                    linhasAfetadas = await cmd.ExecuteNonQueryAsync();

                }
            }

            if (linhasAfetadas == 0)
                return false;

            cacheService.Remove(keyCache);

            return true;
        }

        public async Task<List<Models.Fruta>> GetAllAsync()
        {
            List<Models.Fruta> frutas;

            frutas = cacheService.Get<List<Models.Fruta>>(keyCache);

            if (frutas != null)
                return frutas;

            frutas = new List<Models.Fruta>();

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Select Id, Nome, DataVenc from Frutas;";

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while(await dr.ReadAsync())
                    {
                        Models.Fruta fruta = new Models.Fruta();

                        Mapper(fruta, dr);

                        frutas.Add(fruta);
                    }
                }
            }

            cacheService.Set(keyCache, frutas, CacheExpirationTime);

            return frutas;
        }

        private void Mapper(Models.Fruta fruta, SqlDataReader dr)
        {

            fruta.Id = (int)dr["Id"];
            fruta.Nome = (string)dr["Nome"];
            fruta.DataVenc = (DateTime)dr["DataVenc"];

        }

        public async Task<Models.Fruta> GetByIdAsync(int id)
        {
            Models.Fruta fruta = new Models.Fruta();

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Select Id, Nome, DataVenc from Frutas where Id = @id;";

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    if (await dr.ReadAsync())
                    {
                        Mapper(fruta, dr);
                    }
                }
            }

            return fruta;
        }

        public async Task<List<Models.Fruta>> GetByNameAsync(string nome)
        {
            List<Models.Fruta> frutas = new List<Models.Fruta>();

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Select Id, Nome, DataVenc from Frutas where Nome like @nome;";

                    cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = $"%{nome}%";

                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        Models.Fruta fruta = new Models.Fruta();

                        Mapper(fruta, dr);

                        frutas.Add(fruta);
                    }
                }
            }

            return frutas;
        }

        public async Task<bool> UpdateAsync(Models.Fruta fruta)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "Update Frutas Set Nome = @nome, DataVenc = @datavenc where Id = @id;";

                    AdicionaParametrosPadrao(fruta);

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = fruta.Id;

                    linhasAfetadas = await cmd.ExecuteNonQueryAsync();

                }
            }

            if (linhasAfetadas == 0)
                return false;

            cacheService.Remove(keyCache);

            return true;
        }
    }
}