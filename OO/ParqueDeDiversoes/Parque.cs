using System;
using System.Collections.Generic;

namespace ParqueDeDiversoes
{
    internal class Parque
    {
        private List<Bilheteria> bilheteriasParque;
        private List<Pessoa> visitantes;
        private List<Brinquedo> brinquedosParque;

        public Parque()
        {
            bilheteriasParque = new List<Bilheteria>();
            visitantes = new List<Pessoa>();
            brinquedosParque = new List<Brinquedo>();
        }

        public void Abrir()
        {

        }

        public void AdicionarVisitante(Pessoa visitante)
        {
            visitantes.Add(visitante);
        }

        public void Fechar()
        {

        }

    }
}
