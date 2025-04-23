using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao02
{
    public abstract class Pessoa
    {
        protected string primeiroNome;
        protected string ultimoNome;

        private string sexo;
        public Pessoa(string pNome, string uNome)
        {
            this.primeiroNome = pNome;
            this.ultimoNome = uNome;
        }

        public virtual double valorCopiasXerox(int quantidade)
        {
            return quantidade * 2;
        }
    }
}
