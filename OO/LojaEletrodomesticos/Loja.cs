using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEletrodomesticos
{
    internal class Loja
    {
        private List<Eletrodomestico> listaParaConserto = new List<Eletrodomestico>();

        public void EntregueParaConsertar(Eletrodomestico eletrodomestico)
        {
            listaParaConserto.Add(eletrodomestico);
        }
        
        public void ConsertarEletrodomestico(int id)
        {

        }

    }

}
