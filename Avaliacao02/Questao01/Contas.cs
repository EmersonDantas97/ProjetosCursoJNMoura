using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao01
{
    internal class Contas
    {
       private List<Conta> listaDeContas;

        public Contas()
        {
            listaDeContas = new List<Conta>();
        }

        public void Adicionar(Conta conta)
        {
            listaDeContas.Add(conta);
        }

        public double GetValorTotal()
        {
            double somaDosValores = 0;

            foreach (Conta conta in listaDeContas)
            {
                somaDosValores = conta.Valor + somaDosValores;
            }

            return somaDosValores;
        }

    }
}
