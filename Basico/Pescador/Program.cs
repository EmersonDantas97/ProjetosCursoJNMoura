using System;

/*

Pescador comprou um microcomputador para controlar o rendimento diário de seu trabalho. 

Toda vez que ele traz um peso de peixes maior que o estabelecido pelo regulamento de pesca do estado de São Paulo (50 quilos) deve pagar uma multa de R$ 4,00 por quilo excedente. 

Assim, faça um programa que leia o peso de peixes e verifique se há excesso. 

Se houver, o programa também deve calcular o valor da multa que o pescador deverá pagar.

No final, o programa deve imprimir o excesso e a multa paga pelo pescador.

*/

namespace Pescador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------- PESCADOR");

            Console.Write("\n Informe o peso do peixe em Kg: ");
            double pesoPeixe = double.Parse(Console.ReadLine());

            double pesoExcedente = pesoPeixe - 50;
            double valorMulta = 4.00;

            if (pesoPeixe > 50)
            {
                Console.WriteLine($"\n → O peso do peixe passou do limite permitido!");
                Console.WriteLine($" → Terá que ser pago uma multa no valor de R$ {pesoExcedente * valorMulta:0.00}.");
                Console.WriteLine($" → O valor excedido de peso foi {pesoExcedente:0.00} Kg.");
            }
            else
            {
                Console.WriteLine("\n → O peso do peixe está dentro da lei!");
            }

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();
        }
    }
}
