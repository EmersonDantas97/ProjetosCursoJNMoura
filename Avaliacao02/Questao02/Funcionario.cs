using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao02
{
    public class Funcionario : Pessoa
    {
        
        public double Salario { get; set; }

        public Funcionario(string pNome, string uNome, double salario) :
            base(pNome, uNome)
        {
            this.Salario = salario;
        }
    }
}
