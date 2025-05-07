using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models
{
    public class Funcionario
    {
        public int Codigo { get; set; }
        public int CodigoDepartamento { get; set; }
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public string UltimoNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Fone { get; set; }
        public string Funcao { get; set; }
        public double Salario { get; set; }

        public Funcionario()
        {
        }

    }
}