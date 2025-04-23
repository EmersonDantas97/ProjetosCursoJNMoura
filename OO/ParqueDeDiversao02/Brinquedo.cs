using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDeDiversao02
{
    internal abstract class Brinquedo
    {
        private bool fechado;

        public Brinquedo()
        {
            fechado = true;
        }

        public void Abrir()
        {
            this.fechado = false;
        }
        public void Fechar()
        {
            this.fechado = true;
        }

        public bool BrinquedoAberto()
        {
            return this.fechado;
        }

    }
}
