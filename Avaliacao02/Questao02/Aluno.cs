using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao02
{
    public sealed class Aluno : Pessoa
    {
        private string registro;

        
        public Aluno(string pNome, string uNome, string registro) :
            base(pNome, uNome)
        {
            this.registro = registro;
        }

        public override double valorCopiasXerox(int quantidade)
        {
            return quantidade * 1;
        }
    }
}
