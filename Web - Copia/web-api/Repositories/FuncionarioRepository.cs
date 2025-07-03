using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace web_api.Repository
{
    public class FuncionarioRepository
    {
        private readonly string _conexao;
        public FuncionarioRepository()
        {
            _conexao = ConfigurationManager.ConnectionStrings["ConexaoFuncionario"].ConnectionString;
        }
        public List<Models.Funcionario> ListarTodos()
        {
            string scriptSql =
                "SELECT Codigo, CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario " +
                "FROM Funcionario; ";

            List<Models.Funcionario> listaDeFuncionarios = new List<Models.Funcionario>();

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(scriptSql, conn))
                {

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Funcionario funcionario = new Models.Funcionario();

                        funcionario.Codigo = (int) dr["Codigo"];
                        funcionario.CodigoDepartamento = (int) dr["CodigoDepartamento"];
                        funcionario.PrimeiroNome = dr["PrimeiroNome"] as string;
                        //funcionario.SegundoNome = Convert.ToString(dr["SegundoNome"]); Retorna ""
                        funcionario.SegundoNome = dr["SegundoNome"] as string; // Retorna valor nulo
                        funcionario.UltimoNome = dr["UltimoNome"] as string;
                        funcionario.DataNascimento = (DateTime) dr["DataNascimento"];
                        funcionario.CPF = (string) dr["CPF"];
                        funcionario.RG = (string) dr["RG"];
                        funcionario.Endereco = (string) dr["Endereco"];
                        funcionario.CEP = (string) dr["CEP"];
                        funcionario.Cidade = (string) dr["Cidade"];
                        funcionario.Fone = (string) dr["Fone"];
                        funcionario.Funcao = (string) dr["Funcao"];
                        funcionario.Salario = Convert.ToDouble(dr["Salario"]);

                        listaDeFuncionarios.Add(funcionario);
                    }
                }
            }

            return listaDeFuncionarios;
        }
        public Models.Funcionario ListarPorId(int id)
        {
            Models.Funcionario funcionario = null;

            string scriptSql =
                "SELECT Codigo, CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario " +
                "FROM Funcionario " +
                "WHERE Codigo = @Id;";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {

                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(scriptSql, conn)) 
                {

                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        funcionario = new Models.Funcionario();

                        funcionario.Codigo = (int)dr["Codigo"];
                        funcionario.CodigoDepartamento = (int)dr["CodigoDepartamento"];
                        funcionario.PrimeiroNome = dr["PrimeiroNome"] as string;
                        funcionario.SegundoNome = dr["SegundoNome"] as string;
                        funcionario.UltimoNome = dr["UltimoNome"] as string;
                        funcionario.DataNascimento = (DateTime)dr["DataNascimento"];
                        funcionario.CPF = (string)dr["CPF"];
                        funcionario.RG = (string)dr["RG"];
                        funcionario.Endereco = (string)dr["Endereco"];
                        funcionario.CEP = (string)dr["CEP"];
                        funcionario.Cidade = (string)dr["Cidade"];
                        funcionario.Fone = (string)dr["Fone"];
                        funcionario.Funcao = (string)dr["Funcao"];
                        funcionario.Salario = Convert.ToDouble(dr["Salario"]);
                    }
                }
            }
            return funcionario;
        }
        public Models.Funcionario Excluir(int id)
        {
            Models.Funcionario funcionarioDeletado = ListarPorId(id);

            if (funcionarioDeletado == null)
                return null;

            string scriptSql =
                "DELETE FROM Funcionario WHERE Codigo  = @Id;";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(scriptSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }
            return funcionarioDeletado;
        }
        public Models.Funcionario Adicionar(Models.Funcionario funcionario)
        {
            int idGerado = 0;

            string scriptSql =
                "INSERT INTO Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) " +
                "VALUES (@CodigoDepartamento, @PrimeiroNome, @SegundoNome, @UltimoNome, @DataNascimento, @CPF, @RG, @Endereco, @CEP, @Cidade, @Fone, @Funcao, @Salario); " +
                "SELECT SCOPE_IDENTITY(); ";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(scriptSql, conn))
                {

                    cmd.Parameters.AddWithValue("@CodigoDepartamento", funcionario.CodigoDepartamento);
                    cmd.Parameters.AddWithValue("@PrimeiroNome", funcionario.PrimeiroNome);
                    cmd.Parameters.AddWithValue("@SegundoNome", funcionario.SegundoNome);
                    cmd.Parameters.AddWithValue("@UltimoNome", funcionario.UltimoNome);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);
                    cmd.Parameters.AddWithValue("@CPF", funcionario.CPF);
                    cmd.Parameters.AddWithValue("@RG", funcionario.RG);
                    cmd.Parameters.AddWithValue("@Endereco", funcionario.Endereco);
                    cmd.Parameters.AddWithValue("@CEP", funcionario.CEP);
                    cmd.Parameters.AddWithValue("@Cidade", funcionario.Cidade);
                    cmd.Parameters.AddWithValue("@Fone", funcionario.Fone);
                    cmd.Parameters.AddWithValue("@Funcao", funcionario.Funcao);
                    cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);

                    idGerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return ListarPorId(idGerado);
        }
        public Models.Funcionario Alterar(int id, Models.Funcionario funcionario)
        {
            Models.Funcionario funcionarioAlterado = ListarPorId(id);

            if (funcionarioAlterado == null)
                return null;

            string scriptSql =
                "UPDATE Funcionario " +
                "SET CodigoDepartamento = @CodigoDepartamento, PrimeiroNome = @PrimeiroNome, SegundoNome = @SegundoNome, UltimoNome = @UltimoNome, DataNascimento = @DataNascimento, CPF = @CPF, RG = @RG, Endereco = @Endereco, CEP = @CEP, Cidade = @Cidade, Fone = @Fone, Funcao = @Funcao, Salario = @Salario " +
                "WHERE Codigo = @Id;";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(scriptSql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoDepartamento", funcionario.CodigoDepartamento);
                    cmd.Parameters.AddWithValue("@PrimeiroNome", funcionario.PrimeiroNome);
                    cmd.Parameters.AddWithValue("@SegundoNome", funcionario.SegundoNome);
                    cmd.Parameters.AddWithValue("@UltimoNome", funcionario.UltimoNome);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);
                    cmd.Parameters.AddWithValue("@CPF", funcionario.CPF);
                    cmd.Parameters.AddWithValue("@RG", funcionario.RG);
                    cmd.Parameters.AddWithValue("@Endereco", funcionario.Endereco);
                    cmd.Parameters.AddWithValue("@CEP", funcionario.CEP);
                    cmd.Parameters.AddWithValue("@Cidade", funcionario.Cidade);
                    cmd.Parameters.AddWithValue("@Fone", funcionario.Fone);
                    cmd.Parameters.AddWithValue("@Funcao", funcionario.Funcao);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);

                    cmd.ExecuteNonQuery();
                }
            }

            return ListarPorId(id);
        }
        public List<Models.Funcionario> AdicionarEmLote(List<Models.Funcionario> funcionarios)
        {
            int idGerado = 0;

            List<Models.Funcionario> listaDeFuncionariosAdicionados = new List<Models.Funcionario>();

            string scriptSql =
                "INSERT INTO Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) " +
                "VALUES (@CodigoDepartamento, @PrimeiroNome, @SegundoNome, @UltimoNome, @DataNascimento, @CPF, @RG, @Endereco, @CEP, @Cidade, @Fone, @Funcao, @Salario); " +
                "SELECT SCOPE_IDENTITY(); ";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();


                foreach(var funcionario in funcionarios)
                {

                    using
                    (SqlCommand cmd = new SqlCommand(scriptSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoDepartamento", funcionario.CodigoDepartamento);
                        cmd.Parameters.AddWithValue("@PrimeiroNome", funcionario.PrimeiroNome);
                        cmd.Parameters.AddWithValue("@SegundoNome", funcionario.SegundoNome);
                        cmd.Parameters.AddWithValue("@UltimoNome", funcionario.UltimoNome);
                        cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);
                        cmd.Parameters.AddWithValue("@CPF", funcionario.CPF);
                        cmd.Parameters.AddWithValue("@RG", funcionario.RG);
                        cmd.Parameters.AddWithValue("@Endereco", funcionario.Endereco);
                        cmd.Parameters.AddWithValue("@CEP", funcionario.CEP);
                        cmd.Parameters.AddWithValue("@Cidade", funcionario.Cidade);
                        cmd.Parameters.AddWithValue("@Fone", funcionario.Fone);
                        cmd.Parameters.AddWithValue("@Funcao", funcionario.Funcao);
                        cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);

                        idGerado = Convert.ToInt32(cmd.ExecuteScalar());

                        listaDeFuncionariosAdicionados.Add(ListarPorId(idGerado));
                    }
                }
            }

            return listaDeFuncionariosAdicionados;
        }
    }
}