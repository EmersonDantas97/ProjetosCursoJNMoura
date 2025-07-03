using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class Moto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public double Valor { get; set; }

        public Moto()
        {
        }
    }
}