using System;

namespace Calculadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------ CALCULADORA");
            Console.WriteLine();

            // Obter dois números do usuário
            Console.Write("Digite o numero 1: ");
            int numero1 = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero 2: ");
            int numero2 = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("------------ CALCULOS GERADOS");

            //Calcular e apresentar. Operações: Soma, subração, multiplicação, divisão, resto da divisão
            Console.WriteLine();

            Console.WriteLine($"SOMA entre {numero1} e {numero2}: {numero1 + numero2}.");
            Console.WriteLine($"SUBTRACAO entre {numero1} e {numero2}: {numero1 - numero2}.");
            Console.WriteLine($"MULTIPLICACAO entre {numero1} e {numero2}: {numero1 * numero2}.");
            Console.WriteLine($"DIVISÃO entre {numero1} e {numero2}: {(double) numero1 / numero2:0.00}."); // Realizando Cast, que significa conversao. Realizando formatacao também. .
            Console.WriteLine($"O RESTO da divisão entre {numero1} e {numero2}: {numero1 % numero2}.");

            Console.WriteLine();
            Console.WriteLine("------------ FINAL");

            Console.ReadLine();
        }
    }
}


// Estudar sobre breakpoint e modo de debug ou depuracao.