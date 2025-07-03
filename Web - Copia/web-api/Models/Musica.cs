using System;

namespace web_api.Models
{
    public enum TomOriginal
    {
        Sim, Nao, AVerificar
    }
    public class Musica
    {
        public int? Id{ get; set; }
        public string Nome { get; set; }
        public string Versao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Observacao { get; set; }
        public string Tom { get; set; }
        public TomOriginal TomOriginal { get; set; }

        public Musica()
        {
        }
    }
}