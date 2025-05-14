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
                        funcionario.PrimeiroNome = (string) dr["PrimeiroNome"];
                        funcionario.SegundoNome = (string) dr["SegundoNome"];
                        funcionario.UltimoNome = (string) dr["UltimoNome"];
                        funcionario.DataNascimento = (DateTime) dr["DataNascimento"];
                        funcionario.CPF = (string) dr["CPF"];
                        funcionario.RG = (string) dr["RG"];
                        funcionario.Endereco = (string) dr["Endereco"];
                        funcionario.CEP = (string) dr["CEP"];
                        funcionario.Cidade = (string) dr["Cidade"];
                        funcionario.Fone = (string) dr["Fone"];
                        funcionario.Funcao = (string) dr["Funcao"];
                        funcionario.Salario = (double) dr["Falario"];

                        listaDeFuncionarios.Add(funcionario);
                    }
                }
            }

            return listaDeFuncionarios;
        }
        public Models.Funcionario ListarPorId(int id)
        {
            Models.Funcionario funcionario = new Models.Funcionario();

            string scriptSql =
                "SELECT Codigo, CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario " +
                "FROM Funcionario" +
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
                        funcionario.Codigo = (int)dr["Codigo"];
                        funcionario.CodigoDepartamento = (int)dr["CodigoDepartamento"];
                        funcionario.PrimeiroNome = (string)dr["PrimeiroNome"];
                        funcionario.SegundoNome = (string)dr["SegundoNome"];
                        funcionario.UltimoNome = (string)dr["UltimoNome"];
                        funcionario.DataNascimento = (DateTime)dr["DataNascimento"];
                        funcionario.CPF = (string)dr["CPF"];
                        funcionario.RG = (string)dr["RG"];
                        funcionario.Endereco = (string)dr["Endereco"];
                        funcionario.CEP = (string)dr["CEP"];
                        funcionario.Cidade = (string)dr["Cidade"];
                        funcionario.Fone = (string)dr["Fone"];
                        funcionario.Funcao = (string)dr["Funcao"];
                        funcionario.Salario = (double)dr["Falario"];
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

    }
}