using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDeDiversoes03
{
    internal class Eletrico : Brinquedo, IEletrico
    {
        private bool ligado;

        public Eletrico()
        {
        }

        public override void Abrir()
        {
            base.Abrir();
            this.Ligar();
        }

        public override void Fechar()
        {
            base.Fechar();
            this.Desligar();
        }

        public void Ligar()
        {
            this.ligado = true;

        }
        public void Desligar()
        {
            this.ligado = false;
        }
    }
}
