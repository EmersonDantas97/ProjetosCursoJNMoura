using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDeDiversoes
{
    internal class Eletrico : Brinquedo
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
        public bool EstaLigado()
        {
            return this.ligado;
        }
    }
}
