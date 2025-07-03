using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace web_api.Repositories
{
    public class Funcionario
    {
        readonly SqlConnection conn;
        readonly SqlCommand cmd;

        public Funcionario(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        public async Task Add(Models.Funcionario funcionario)
        {
            string scriptSql = 
                "INSERT INTO Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) " +
                "VALUES (@CodigoDepartamento, @PrimeiroNome, @SegundoNome, @UltimoNome, @DataNascimento, @CPF, @RG, @Endereco, @CEP, @Cidade, @Fone, @Funcao, @Salario); " +
                "SELECT SCOPE_IDENTITY();";
            
            using (conn)
            {
                await conn.OpenAsync();

                using (cmd)
                {
                    cmd.CommandText = scriptSql;

                    AdicionaParametrosPadroes(funcionario);

                    funcionario.Codigo = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
            }
        }

        private void AdicionaParametrosPadroes(Models.Funcionario funcionario)
        {
            cmd.Parameters.Add(new SqlParameter("@CodigoDepartamento", SqlDbType.Int)).Value = funcionario.CodigoDepartamento;
            cmd.Parameters.Add(new SqlParameter("@PrimeiroNome", SqlDbType.VarChar)).Value = funcionario.PrimeiroNome;
            cmd.Parameters.Add(new SqlParameter("@SegundoNome", SqlDbType.VarChar)).Value = funcionario.SegundoNome;
            cmd.Parameters.Add(new SqlParameter("@UltimoNome", SqlDbType.VarChar)).Value = funcionario.UltimoNome;
            cmd.Parameters.Add(new SqlParameter("@DataNascimento", SqlDbType.Date)).Value = funcionario.DataNascimento;
            cmd.Parameters.Add(new SqlParameter("@CPF", SqlDbType.VarChar)).Value = funcionario.CPF;
            cmd.Parameters.Add(new SqlParameter("@RG", SqlDbType.VarChar)).Value = funcionario.RG;
            cmd.Parameters.Add(new SqlParameter("@Endereco", SqlDbType.VarChar)).Value = funcionario.Endereco;
            cmd.Parameters.Add(new SqlParameter("@CEP", SqlDbType.VarChar)).Value = funcionario.CEP;
            cmd.Parameters.Add(new SqlParameter("@Cidade", SqlDbType.VarChar)).Value = funcionario.Cidade;
            cmd.Parameters.Add(new SqlParameter("@Fone", SqlDbType.VarChar)).Value = funcionario.Fone;
            cmd.Parameters.Add(new SqlParameter("@Funcao", SqlDbType.VarChar)).Value = funcionario.Funcao;
            cmd.Parameters.Add(new SqlParameter("@Salario", SqlDbType.Decimal)).Value = funcionario.Salario;
        }
    }
}