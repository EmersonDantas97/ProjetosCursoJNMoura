namespace web_api.Models
{
    public class Brinquedo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int IdadeMinima { get; set; }
        public int IdadeMaxima { get; set; }

        public Brinquedo()
        {
        }

    }
}