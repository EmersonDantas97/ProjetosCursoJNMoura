using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDeDiversao02
{
    internal class Eletrico : Brinquedo, IEletrico
    {
        private bool ligado;

        public void Ligar()
        {
            this.ligado = true;
        }
        public void Desligar()
        {
            this.ligado = false;
        }
        public bool estaLigado()
        {
            return this.ligado;
        }

    }
}
