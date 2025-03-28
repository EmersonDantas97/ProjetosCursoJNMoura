using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumEstudo
{
    internal class Program
    {
        enum statusPedido {emAtendimento = 1, fazendo, emEntrega, finalizado};

        static void Main(string[] args)
        {
            Random numeroAleatorio = new Random();

            int pedido = numeroAleatorio.Next(1,4);

            Console.WriteLine($"O status do pedido é: {Enum.GetName(typeof(statusPedido), pedido)}");

            Console.Write($"Os valores do Enum são: ");

            foreach (var item in Enum.GetValues(typeof(statusPedido)))
                Console.Write($"{item} ");

        }
    }
}
