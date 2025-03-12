using System;

namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nome = "Joca";

            Console.WriteLine(nome); // Todos os char. 
            Console.WriteLine(nome[0]); // Exibindo o 1º caracter. 

            // Soletrando
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(nome[i]);
            }

            Console.ReadLine();
        }
    }
}
