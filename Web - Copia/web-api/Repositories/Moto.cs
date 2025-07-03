using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace web_api.Repositories
{
    public class Moto
    {
        readonly SqlConnection conn;
        readonly SqlCommand cmd;

        public Moto(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        public async Task Add(Models.Moto moto)
        {
            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "INSERT INTO Moto (Nome, Valor) VALUES (@nome, @valor);Select scope_identity();";

                    AdicionarParametrosPadrao(moto);

                    moto.Id = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
            }
        }

        public async Task<bool> Update(Models.Moto moto)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = "UPDATE ";

                    AdicionarParametrosPadrao(moto);

                    cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.Int)).Value = moto.Id;
                }
            }




                throw new NotImplementedException();
        }

        private void AdicionarParametrosPadrao(Models.Moto moto)
        {
            cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = moto.Nome;
            cmd.Parameters.Add(new SqlParameter("@valor", SqlDbType.Decimal)).Value = moto.Valor;
        }
    }
}