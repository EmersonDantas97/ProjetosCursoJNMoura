using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDeDiversoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parque betoCarreiro = new Parque();
            
            Pessoa visitante1 = new Pessoa();

            betoCarreiro.Abrir();
            betoCarreiro.AdicionarVisitante(visitante1);

           // Pessoa pessoa1


        }
    }
}
