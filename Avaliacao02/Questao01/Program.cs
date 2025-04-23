using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conta cnt01 = new Conta(DateTime.Now, 15.00);
            Conta cnt02 = new Conta(DateTime.Now, 85.00);

            Contas listaContas = new Contas();

            listaContas.Adicionar(cnt01);
            listaContas.Adicionar(cnt02);

            Console.WriteLine(listaContas.GetValorTotal());

            

        }
    }
}
