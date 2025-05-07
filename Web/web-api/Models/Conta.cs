using System;

namespace web_api.Models
{
    public enum Parcelada
    {
        Sim, Nao
    }
    public class Conta
    {

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public double Valor { get; set; }
        public string Observacao { get; set; }
        public Parcelada Parcelada { get; set; }
        public int ParcelaAtual { get; set; }
        public int QtdTotalParcelas { get; set; }

        public Conta()
        {
        }
    }
}