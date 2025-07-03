using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using web_api.Models;

namespace web_api.Repository
{
    public class MusicaRepository
    {
        private readonly string _conexao;
        public MusicaRepository()
        {
            _conexao = ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString;
        }
        public List<Musica> ListarTodas()
        {
            List<Musica> musicas = new List<Musica>();

            string consulta = 
                "SELECT Id, Nome, Versao, DataCadastro, Observacao, Tom, TomOriginal FROM Musica;";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(consulta, conn))
                {

                    using
                    (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            musicas.Add(new Musica
                            {
                                Id = (int) dr["Id"],
                                Nome = (string) dr["Nome"],
                                Versao = Convert.ToString(dr["Versao"]),
                                Observacao = (string) dr["Observacao"],
                                Tom = (string) dr["Tom"],
                                DataCadastro = (DateTime) dr["DataCadastro"],
                                TomOriginal = (TomOriginal) dr["TomOriginal"]
                                
                            });
                        }
                    }
                }
            }

            return musicas;
        }
        public Musica ObterPorId(int id)
        {
            Musica musica = null;

            string query = 
                "SELECT Id, Nome, Versao, DataCadastro, Observacao, Tom, TomOriginal FROM Musica WHERE Id = @Id;";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using
                    (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            musica = new Musica
                            {
                                Id = (int)dr["Id"],
                                Nome = (string)dr["Nome"],
                                Versao = Convert.ToString(dr["Versao"]),
                                Observacao = (string)dr["Observacao"],
                                Tom = (string)dr["Tom"],
                                DataCadastro = (DateTime)dr["DataCadastro"],
                                TomOriginal = (TomOriginal)dr["TomOriginal"]
                            };
                        }
                    }
                }
            }

            if (musica != null)
                return musica;
            else
                return null;
        }
        public Musica Excluir(int id)
        {
            Musica musica = ObterPorId(id);

            if (musica == null)
                return null;

            string query = "DELETE FROM Musica WHERE Id = @Id;";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {

                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            return musica;
        }
        public Musica Adicionar(Musica musica)
        {
            int IdGerado = 0;

            string query =
                "INSERT INTO Musica (Nome, Versao, DataCadastro, Observacao, Tom, TomOriginal) " +
                "VALUES (@Nome, @Versao, @DataCadastro, @Observacao, @Tom, @TomOriginal); " +
                "SELECT SCOPE_IDENTITY();";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", musica.Nome);
                    cmd.Parameters.AddWithValue("@Versao", musica.Versao);
                    cmd.Parameters.AddWithValue("@DataCadastro", musica.DataCadastro);
                    cmd.Parameters.AddWithValue("@Observacao", musica.Observacao);
                    cmd.Parameters.AddWithValue("@Tom", musica.Tom);
                    cmd.Parameters.AddWithValue("@TomOriginal", musica.TomOriginal);

                    IdGerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return ObterPorId(IdGerado);
        }
        public List<Musica> AdicionarEmLote(List<Musica> musicas)
        {
            List<Musica> musicasInseridas = new List<Musica>();

            if (musicas.Count > 0)
                return musicasInseridas;

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                foreach (var musica in musicas)
                {
                    string comando =
                        "INSERT INTO Musica (Nome, Versao, DataCadastro, Observacao, Tom, TomOriginal) " +
                        "VALUES (@Nome, @Versao, @DataCadastro, @Observacao, @Tom, @TomOriginal); " +
                        "SELECT SCOPE_IDENTITY();";

                    using
                    (SqlCommand cmd = new SqlCommand(comando, conn))
                    {

                        cmd.Parameters.AddWithValue("@Nome", musica.Nome);
                        cmd.Parameters.AddWithValue("@Versao", musica.Versao);
                        cmd.Parameters.AddWithValue("@DataCadastro", musica.DataCadastro);
                        cmd.Parameters.AddWithValue("@Observacao", musica.Observacao);
                        cmd.Parameters.AddWithValue("@Tom", musica.Tom);
                        cmd.Parameters.AddWithValue("@TomOriginal", musica.TomOriginal);

                        int novoId = Convert.ToInt32(cmd.ExecuteScalar());

                        musicasInseridas.Add(ObterPorId(novoId));
                    }
                }
            }

            return musicasInseridas;
        }
        public Musica Alterar(int id, Musica musica)
        {
            Musica musicaBD = ObterPorId(id);

            if (musicaBD == null)
                return null;

            string query =
                "UPDATE Musica SET Nome = @Nome, Versao = @Versao, DataCadastro = @DataCadastro, Observacao = @Observacao, Tom = @Tom, TomOriginal = @TomOriginal " +
                "WHERE Id = @Id;";

            using
            (SqlConnection conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using
                (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", musica.Id);
                    cmd.Parameters.AddWithValue("@Nome", musica.Nome);
                    cmd.Parameters.AddWithValue("@Versao", musica.Versao);
                    cmd.Parameters.AddWithValue("@DataCadastro", musica.DataCadastro);
                    cmd.Parameters.AddWithValue("@Observacao", musica.Observacao);
                    cmd.Parameters.AddWithValue("@Tom", musica.Tom);
                    cmd.Parameters.AddWithValue("@TomOriginal", musica.TomOriginal);

                    cmd.ExecuteReader();
                }
            }

            return ObterPorId(id);
        }
    }
}