using System;
using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class Veiculo
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a MARCA.")]
        [StringLength(50, ErrorMessage = "MARCA deve ter no máximo 50 caracteres.")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o NOME.")]
        [StringLength(100, ErrorMessage = "NOME deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o ANO DE MODELO.")]
        public int? AnoModelo { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a DATA DE FABRICAÇÃO.")]
        public DateTime? DataFabricacao { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o VALOR.")]
        public double? Valor { get; set; }

        [StringLength(500, ErrorMessage = "OPCIONAIS deve ter no máximo 500 caracteres.")]
        public string Opcionais { get; set; }

        public Veiculo()
        {
        }

        public void OpcionalToString() 
        {
            Opcionais = 
                Opcionais == null ? 
                "" : Opcionais;
        }
    }
}