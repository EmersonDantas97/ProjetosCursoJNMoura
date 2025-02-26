using System;

/* Informe o numero da tabuada: 5
 * 5*0 = 0
 * ...
 */

namespace Tabuada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\nInforme o número da tabuada: ");
            int numeroTabuada = int.Parse(Console.ReadLine());

            Console.WriteLine($"\n{numeroTabuada} X 0 = {numeroTabuada * 0}");
            Console.WriteLine($"{numeroTabuada} X 1 = {numeroTabuada * 1}");
            Console.WriteLine($"{numeroTabuada} X 2 = {numeroTabuada * 2}");
            Console.WriteLine($"{numeroTabuada} X 3 = {numeroTabuada * 3}");
            Console.WriteLine($"{numeroTabuada} X 4 = {numeroTabuada * 4}");
            Console.WriteLine($"{numeroTabuada} X 5 = {numeroTabuada * 5}");
            Console.WriteLine($"{numeroTabuada} X 6 = {numeroTabuada * 6}");
            Console.WriteLine($"{numeroTabuada} X 7 = {numeroTabuada * 7}");
            Console.WriteLine($"{numeroTabuada} X 8 = {numeroTabuada * 8}");
            Console.WriteLine($"{numeroTabuada} X 9 = {numeroTabuada * 9}");
            Console.WriteLine($"{numeroTabuada} X 10 = {numeroTabuada * 10}");

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();
        }

    }
}
