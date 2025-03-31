using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumEstudo
{
    public enum Genero {Comedia, Terror, Acao, Suspense, FiccaoCientifica }

    internal class Filme
    {
        public string Nome;
        public Genero Genero;

        public Filme()
        {
        }
        public Filme(string Nome, Genero Genero) 
        {
            this.Nome = Nome;
            this.Genero = Genero;
        }
    }
}
