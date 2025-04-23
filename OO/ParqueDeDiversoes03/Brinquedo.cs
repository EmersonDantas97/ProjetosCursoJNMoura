using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParqueDeDiversoes03
{
    public abstract class Brinquedo : IBrinquedo
    {
        private bool aberto;

        public Brinquedo()
        {
        }

        public virtual void Abrir()
        {
            this.aberto = true;
        }

        public virtual void Fechar()
        {
            this.aberto = false;
        }
    }
}