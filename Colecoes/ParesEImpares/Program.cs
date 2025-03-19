using System;
using System.Collections.Generic;

/*
 * Solicite para o usuário digitar 10 números
 * No final (após ele digitar os 10 números), mostre:
 * Números pares: ........
 * Números ímpares: ......
 */

namespace ParesEImpares
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Programa dos Pares e Ímpares--\n");

            const int QTDENUMEROS = 10;

            Console.WriteLine($"Digite {QTDENUMEROS} números inteiros por favor...");

            List<int> pares = new List<int>();
            List<int> impares = new List<int>();

            HashSet<int> paresSemRepetir = new HashSet<int>();
            HashSet<int> imparesSemRepetir = new HashSet<int>();

            for (int i = 0; i < QTDENUMEROS; i++)
            {
                Console.Write($"Número {i + 1}: ");

                int numero = int.Parse(Console.ReadLine());

                if (numero % 2 == 0)
                {
                    pares.Add(numero);
                    paresSemRepetir.Add(numero);
                }
                else
                {
                    impares.Add(numero);
                    imparesSemRepetir.Add(numero);
                }
            }

            Console.Write("\nNúmeros pares: ");
            foreach (int item in pares)
                Console.Write($" {item}");

            Console.Write("\nNúmeros ímpares: ");
            foreach (int item in impares)
                Console.Write($" {item}");

            Console.WriteLine("\n\n------------\n");
            Console.Write("\nNúmeros pares sem repetir: ");
            foreach (int item in paresSemRepetir)
                Console.Write($" {item}");

            Console.Write("\nNúmeros ímpares sem repetir: ");
            foreach (int item in imparesSemRepetir)
                Console.Write($" {item}");

            Console.WriteLine("\n\n--Pressione ENTER para encerrar--");
            Console.ReadLine();

            }
        }
}
