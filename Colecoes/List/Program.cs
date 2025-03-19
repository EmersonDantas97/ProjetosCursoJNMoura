using System;
using System.Collections.Generic;

namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n--------- LIST PROFESSOR\n");


            List<int> listaInteiros = new List<int>();

            int qtd = 100;

            for (int i = 0; i < qtd; i++)
            {
                listaInteiros.Add(i);
                Console.WriteLine($"Adicionado o valor {listaInteiros[i]}");
            }

            int x = listaInteiros[10];

            /*
            Caso queira criar uma List heterogenea, tenho que colocar o tipo Object. 
            Ex:
                List<object> listaInteiros = new List<object>();

             */

            Console.Write("\nPressione ENTER retornar para finalizar o programa!");
            Console.ReadLine();

        }
    }
}
