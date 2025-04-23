using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDeDiversoes03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pessoa visitante1 = new Pessoa(nome: "Joao", idade: 25);
            Pessoa visitante2 = new Pessoa(nome: "Pedro", idade: 15);
            Pessoa visitante3 = new Pessoa(nome: "Lucia", idade: 39);
   
            Parque hopyHari = new Parque();
            
            hopyHari.Abrir();

            hopyHari.AdicionaVisitante(visitante1);
            hopyHari.AdicionaVisitante(visitante2);
            hopyHari.AdicionaVisitante(visitante3);

            hopyHari.Fechar();
        }
    }
}
