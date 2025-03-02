using System;

/*
Analise a seguinte informação:

Em um jogo, existe um posto que está vendendo combustíveis com a seguinte tabela de descontos:

Álcool
até 20 litros (inclusive 20 litros), desconto de 2% por litro
acima de 20 litros, desconto de 5% por litro

Gasolina
até 20 litros (inclusive 20 litros), desconto de 3% por litro
acima de 20 litros, desconto de 6% por litro

Após à análise, faça um programa que leia o número de litros vendidos 
e o tipo de combustível (codificado da seguinte forma: 1-álcool, 2-gasolina).
calcule e imprima o valor a ser pago pelo jogador, sabendo-se que 
o preço do litro da gasolina é R$ 6.10 e o preço do litro do álcool é R$ 4.20
 */

namespace Posto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double precoLitroGasolina = 6.10;
            const double precoLitroEtanol = 4.20;

            double descontoRecebido;
            double totalAPagarSemDesconto;

            double descontoPromocionalEtanol1 = 0.02;
            double descontoPromocionalEtanol2 = 0.05;

            double descontoPromocionalGasolina1 = 0.03;
            double descontoPromocionalGasolina2 = 0.06;

            double qtdDeLtsEtanolParaReceberDescontoMaior = 20.00;
            double qtdDeLtsGasolinaParaReceberDescontoMaior = 20.00;

            
            Console.WriteLine("\n--------- JOGO DE POSTO");

            Console.WriteLine("\nDigite a opção correspondente a qual combustível deseja abastecer: ");

            Console.WriteLine("\n 1 - Etanol");
            Console.WriteLine(" 2 - Gasolina");
            
            Console.Write("\nDigite a opção desejada: ");
            int opcaoEscolhidaDeCombustivel = int.Parse(Console.ReadLine());

            Console.Write("\nDigite quantos litros deseja abastecer: ");
            double qtdLitrosVaiAbastecer = double.Parse(Console.ReadLine());

            switch (opcaoEscolhidaDeCombustivel)
            {
                case 1:
                    totalAPagarSemDesconto = precoLitroEtanol * qtdLitrosVaiAbastecer;

                    if (qtdLitrosVaiAbastecer < qtdDeLtsEtanolParaReceberDescontoMaior)
                        descontoRecebido = qtdLitrosVaiAbastecer * descontoPromocionalEtanol1;
                    else
                        descontoRecebido = qtdLitrosVaiAbastecer * descontoPromocionalEtanol2;

                    break;
                
                case 2:
                    totalAPagarSemDesconto = precoLitroGasolina * qtdLitrosVaiAbastecer;

                    if (qtdLitrosVaiAbastecer < qtdDeLtsGasolinaParaReceberDescontoMaior)
                        descontoRecebido = qtdLitrosVaiAbastecer * descontoPromocionalGasolina1;
                    else
                        descontoRecebido = qtdLitrosVaiAbastecer * descontoPromocionalGasolina2;

                    break;

                default:
                    Console.WriteLine("\nOpção digitada INVÁLIDA! Verifique as opções acima e TENTE NOVAMENTE!");
                    Console.Write("\nPressione ENTER para finalizar o programa!");
                    Console.ReadLine();
                    return;

            }

            Console.WriteLine("\n--------- RESUMO FATURA:");

            Console.WriteLine($"\n  - TOTAL: R$ {totalAPagarSemDesconto:0.00}.");
            Console.WriteLine($"  - DESCONTO: R$ {descontoRecebido:0.00}.");
            Console.WriteLine($"  - TOTAL A SER PAGO: R$ {totalAPagarSemDesconto - descontoRecebido:0.00}.");

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();
        }
    }
}
