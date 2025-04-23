using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDeDiversao02
{
    internal class Pessoa
    {
        public string Nome { get; }
        public int Idade { get;}

        public Pessoa()
        {
        }

        public Pessoa(string nome, int idade)
        {
            this.Nome = nome;
            this.Idade = idade;
        }

    }
}
