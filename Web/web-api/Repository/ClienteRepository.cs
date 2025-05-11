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

        public List<Cliente> ListaTodas()
        {
            List<Cliente> listaDeClientes = new List<Cliente>();

            string query = 
                "SELECT Id, Nome, DataCadastro, Observacao, Status FROM Cliente;";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {

                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand())
            }
        }


    }
}