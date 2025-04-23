using System;

namespace web_api.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        public Carro()
        {
        }
    }
}