using System;

namespace Nomes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*Faça um programa que receba 15 nomes do usuário e mostre eles na tela.*/
            
            Console.WriteLine("\n--------- NOMES\n");

            const int posicoes = 15;

            string[] nomeRecebido = new string[posicoes];

            // Ele não define o espaço. 

            for (int i = 0; i < posicoes; i++)
            {
                Console.Write($"Digite o NOME que será armazenado na posição {i + 1}: ");
                nomeRecebido[i] = Console.ReadLine();
            }

            Console.WriteLine();

            for (int i = 0; i < posicoes; i++)
                Console.WriteLine($"O {i + 1}º NOME digitado foi: {nomeRecebido[i]}");

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();

        }
    }
}
