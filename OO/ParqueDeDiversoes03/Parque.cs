using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParqueDeDiversoes03
{
    public class Parque : IParque
    {
        List<Brinquedo> listaDeBrinquedos;
        List<Bilheteria> listaDeBilheterias;
        List<Pessoa> visitantes;

        public Parque()
        {
            listaDeBrinquedos = new List<Brinquedo>() 
            { 
                new MontanhaRussa(), 
                new TrombaTromba(), 
                new Carrossel(), 
                new RodaGigante(), 
                new TiroAoAlvo(), 
                new Pescaria() 
            };

            listaDeBilheterias = new List<Bilheteria>() 
            { 
                new Bilheteria(), 
                new Bilheteria() 
            };

            visitantes = new List<Pessoa>();
        }

        public void Abrir()
        {
            foreach (Brinquedo brinquedo in listaDeBrinquedos)
            {
                brinquedo.Abrir();
            }
        }

        public void Fechar()
        {
            foreach (var brinquedo in listaDeBrinquedos)
            {
                brinquedo.Fechar();
            }
        }

        public void AdicionaVisitante(Pessoa pessoa)
        {
            visitantes.Add(pessoa);
        }

    }
}