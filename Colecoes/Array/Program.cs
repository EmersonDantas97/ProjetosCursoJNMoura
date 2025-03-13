using System;

namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n--------- ARRAY\n");

            string nome = "Joca"; // Variável tipo String, na verdade é um conjunto de Char 

            Console.WriteLine(nome); // Todos os char concatenados
            Console.WriteLine(nome[0]); // Exibindo o 1º caracter (primeiro elemento do array nome)

            Console.WriteLine("\n-- SOLETRANDO\n");

            for (int i = 0; i < nome.Length; i++) // Soletrando
                Console.WriteLine(nome[i]);

            Console.WriteLine("\n-- REALOCANDO ENDEREÇO DA STRING\n");

            nome = "Emerson Bispo Dantas Filho";

            Console.WriteLine(nome); // É criado um novo endereço, contendo mais blocos

            int[] numeros = new int[10]; // Vai criar um array com 10 posições, e preenche com 0. "new" é a palavra reservada do construtor do array na memória
            //A linha acima faz a mesma coisa que int[] numeros = new int[10] {0,0,0,0,0,0,0,0,0,0,0}

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();

            // Array = Conjunto de dados alocados de forma estática. 

        }
    }
}
