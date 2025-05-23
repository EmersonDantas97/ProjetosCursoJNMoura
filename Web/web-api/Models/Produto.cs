using System;

namespace web_api.Models
{
    public enum StatusProduto
    {
        Ativo = 0, Inativo = 1
    }
    public class Produto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public StatusProduto StatusProduto { get; set; }

        public Produto()
        {
        }
    }
}