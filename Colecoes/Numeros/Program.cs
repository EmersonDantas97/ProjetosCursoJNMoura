using System;

namespace Numeros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n--------- NUMEROS\n");

            /* Faça um programa que receba 15 números do usuário e mostre eles na tela. */

            const int posicoes = 15;

            int[] numeroRecebido = new int[posicoes];

            for (int i = 0; i < posicoes; i++)
            {
                Console.Write($"Digite o número que será armazenado na posição {i + 1}: ");
                numeroRecebido[i] = int.Parse(Console.ReadLine());
            }

            Console.Clear();

            Console.WriteLine("\n--------- NUMEROS\n");

            Console.WriteLine();

            for (int i = 0; i < posicoes; i++)
                Console.WriteLine($"O {i+1}º numero digitado foi: {numeroRecebido[i]}");

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();
        }
    }
}
