using System;
using System.Collections.Generic;

namespace QueueEstudo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n--------- QUEUE ESTUDO\n");

            // Criando uma fila de strings
            Queue<string> fila = new Queue<string>();

            // Adicionando elementos
            fila.Enqueue("Primeiro");
            fila.Enqueue("Segundo");
            fila.Enqueue("Terceiro");

            Console.WriteLine($"\tElemento na frente: {fila.Peek()}\n"); // Retorna "Primeiro"

            Console.WriteLine($"\tRemovendo: {fila.Dequeue()}\n"); // Retorna "Primeiro"
            
            Console.WriteLine($"\tNovo primeiro elemento: {fila.Peek()}\n"); // Retorna "Segundo"

            // Contando elementos restantes
            Console.WriteLine($"\tA fila tem {fila.Count} elementos."); // Retorna 2

            Console.Write("\nPressione ENTER retornar para finalizar o programa!");
            Console.ReadLine();

        }
    }
}
