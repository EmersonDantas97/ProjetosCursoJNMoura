using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDeDiversoes
{
    internal abstract class Brinquedo
    {
        private bool aberto;

        public void Abrir()
        {
            this.aberto = true;
        }
        public void Fechar()
        {
            this.aberto = false;
        }

        public bool EstaAberto()
        {
            return this.aberto;
        }

    }
}
