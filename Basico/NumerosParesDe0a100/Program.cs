using System;

namespace NumerosParesDe0a100
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n--------- NUMEROS PARES 0 A 100\n");

            // Exercicio rapido passado pelo professor.
            // Escrever os numeros pares de 0 a 100.

            Console.WriteLine($"Inicio: \t{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:fff")}\n"); 

            for (int i = 0; i <= 100; i+= 2)
                Console.Write($"{i} - ");

            Console.WriteLine($"\n\nFim: \t{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:fff")}\n");

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();
        }
    }
}
