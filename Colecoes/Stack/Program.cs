using System;
using System.Collections.Generic;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> pilha = new Stack<int>(); // Utiliza algorítmo LIFO. Ultimo a entrar é o primeiro a sair. Ex: Pilha de pratos a lavar.

            Console.WriteLine("\n--------- QUEUE ESTUDO\n");

            pilha.Push(11);
            pilha.Push(22);
            pilha.Push(33);
            pilha.Push(44);

            Console.Write("A pilha é composta por: ");

            foreach (int item in pilha)
                Console.Write($"{item} ");

            // O índice "0" é o ultimo numero inserido.

            Console.WriteLine();

            Console.Write("\nPressione ENTER retornar para finalizar o programa!");
            Console.ReadLine();
        }
    }
}
