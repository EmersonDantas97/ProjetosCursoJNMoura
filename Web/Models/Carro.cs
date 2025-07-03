using System;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class Carro : ICarro
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public double Valor { get; set; }

        public Carro()
        {
        }
    }
}