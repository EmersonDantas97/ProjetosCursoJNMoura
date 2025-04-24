using System;

namespace web_api.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataAbertura { get; set; }

        public Empresa()
        {
        }
    }
}