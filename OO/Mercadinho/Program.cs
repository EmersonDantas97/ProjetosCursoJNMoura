using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Todas classes herdam de produto
            PaoFrances produto1 = new PaoFrances();
            Vassoura produto2 = new Vassoura();
            BarraChocolate produto3 = new BarraChocolate();

            produto1.Vender(); // PaoFrances
            produto2.Vender(); // Vassoura
            produto3.Vender(); // BarraChocolate

            // Não sei qual vai ter devolução!!
            Produto ProdutoDevolvido = produto1;           
            
            
        }
    }
}
