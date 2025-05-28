using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using web_api.Models;

namespace web_api.Repository
{
    public class ClienteRepository
    {
        public readonly string _conexao;
        public ClienteRepository()
        {
            _conexao = ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString;
        }
        public List<Cliente> ListaTodos()
        {
            List<Cliente> listaDeClientes = new List<Cliente>();

            string query = 
                "SELECT Id, Nome, DataCadastro, Observacao, Status " +
                "FROM Cliente;";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {

                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        listaDeClientes.Add(new Cliente
                        {
                            DataCadastro = (DateTime) dr["DataCadastro"],
                            Id = (int) dr["Id"],
                            Nome = (string) dr["Nome"],
                            Observacao = (string) dr["Observacao"],
                            Status = (Status) dr["Status"]
                        });
                    }
                }
            }

            return listaDeClientes;
        }
        public Cliente ListarPorId(int id)
        {
            Cliente cliente = null;

            string query =
                "SELECT Id, Nome, DataCadastro, Observacao, Status FROM Cliente WHERE Id = @Id;";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        cliente = new Cliente
                        {
                            Id = (int)dr["Id"],
                            Nome = (string)dr["Nome"],
                            DataCadastro = (DateTime)dr["DataCadastro"],
                            Observacao = (string)dr["Observacao"],
                            Status = (Status)dr["Status"]
                        };
                    }
                }
            }
            return cliente;
        }
        public Cliente Excluir(int Id)
        {
            Cliente cliente = ListarPorId(Id);

            if (cliente == null)
                return null;

            string delete = 
                "DELETE FROM Cliente WHERE Id = @Id";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(delete, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    cmd.ExecuteNonQuery();
                }
            }
            return cliente;
        }
        public Cliente Adicionar(Cliente cliente)
        {
            int novoId = 0;

            string insert =
                "INSERT INTO Cliente (Nome, DataCadastro, Observacao, Status) " +
                "VALUES (@Nome, @DataCadastro, @Observacao, @Status); " +
                "SELECT SCOPE_IDENTITY(); ";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@DataCadastro", cliente.DataCadastro);
                    cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao);
                    cmd.Parameters.AddWithValue("@Status", cliente.Status);

                    novoId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return ListarPorId(novoId);
        }
        public Cliente Alterar(int id, Cliente cliente)
        {
            Cliente clienteAlterado = null;

            if (ListarPorId(id) == null)
                return clienteAlterado;

            string update =
                "UPDATE Cliente " +
                "SET Nome = @Nome, DataCadastro = @DataCadastro, Observacao = @Observacao, Status = @Status " +
                "WHERE Id = @Id;";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(update, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@DataCadastro", cliente.DataCadastro);
                    cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao);
                    cmd.Parameters.AddWithValue("@Status", cliente.Status);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }

            }

            clienteAlterado = ListarPorId(id);

            return clienteAlterado;
        }
    }
}