using System;

/*
Faça um programa que mostre se um elevador pode entrar em funcionamento ou não.

Primeiro, o programa deve solicitar o peso máximo, em Kg, suportado pelo elevador e o número de pessoas que desejam utilizá-lo. 

Depois, solicitar o peso de cada pessoa e, no final, exibir se o elevador poderá entrar em funcionamento ou não. 

Caso a soma dos pesos das pessoas for maior que o peso máximo suportado pelo elevador, ele não poderá entrar em funcionamento.
 */

namespace Elevador
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double pesoSuportadoPeloElevador;
            int numeroPessoas;
            double pesoDasPessoas;

            int i;
            bool deuCerto;

            Console.WriteLine("\n--------- ELEVADOR");

            Console.Write("\nDigite o peso MÁXIMO SUPORTADO pelo elevador em Kg: ");
            pesoSuportadoPeloElevador = double.Parse(Console.ReadLine());

            do
            {
                Console.Write("\nNúmero de pessoas que desejam utilizá-lo: ");
                deuCerto = int.TryParse(Console.ReadLine(), out numeroPessoas);
            } while (!deuCerto || numeroPessoas < 0);

            //numeroPessoas = int.Parse(Console.ReadLine()); 
            //Não ve se a pessoa está digitando valores errados. Ex: letras e etc. 

            i = 1;
            pesoDasPessoas = 0;

            while (i <= numeroPessoas)
            {
                Console.Write($"\nDigite o peso da pessoa {i}: ");
                pesoDasPessoas += double.Parse(Console.ReadLine());
                i++;
            }

            if (pesoDasPessoas > pesoSuportadoPeloElevador)
                Console.WriteLine("\n\tO elevador não pode operar! PESO MÁXIMO EXCEDIDO!");
            else
                Console.WriteLine("\n\tO elevador pode operar!");

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();
        }
    }
}
