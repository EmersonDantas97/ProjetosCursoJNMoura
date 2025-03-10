using System;

namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n--------- ARRAY");

            #region "Forma 1 de declarar/Inicializar Array"

            //int[] numeros = new int[5]; // Criando um vetor com 5 posicoes/elementos. 

            //numeros[0] = 111; // O primeiro elemento é para o índice 0. 
            //numeros[1] = 222; // O primeiro elemento é para o índice 1. 
            //numeros[2] = 333; // O primeiro elemento é para o índice 2. 
            //numeros[3] = 444;  
            //numeros[4] = 555;

            ////numeros[5] = 666; // Essa linha de código não funciona, tendo em visa que excede o número de elementos do Array. 

            #endregion

            #region "Forma 2 de declarar/Inicializar Array"

            //int[] numeros = new int[5]{ 111, 222, 333 , 444, 555};

            #endregion

            #region "Forma 3 de declarar/Inicializar Array"

            int[] numeros = { 111, 222, 333, 444, 555 }; // Automaticamente, não declara o numero de elementos e usa como base quantos elementos estou informando.

            #endregion

            #region "Exibindo valores declarados no Array de inteiros"

            Console.WriteLine();

            for (int i = 0; i <= 4; i++)
                Console.WriteLine($"O valor constante no índice {i} é: {numeros[i]}");

            #endregion

            Console.WriteLine("");

            #region "Array de strings"

            Console.WriteLine();

            string[] veiculos = new string[3]{ "Carro", "Avião", "Barco" };

            for (int i = 0; i <= 2; i++)
                Console.WriteLine($"O valor constante no índice {i} do array de string é: {veiculos[i]}");

            #endregion

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();

        }
    }
}
