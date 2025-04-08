using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEletrodomesticos
{
    internal class Eletrodomestico
    {
        public string Nome { get; set; }
        public bool Defeito { get; set; }

        public Eletrodomestico()
        {
            this.Nome = "";
            this.Defeito = true;
        }

    }
}
