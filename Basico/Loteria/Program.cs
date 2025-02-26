using System;

/*
 * 3 Amigos => Fazem apostas.
 * Ganharam o premio.
 * Quanto cada um recebe?
 *  
 *  Entradas
 *      Valor que cada um apostou.
 *      Valor do Premio. 
 *  
 *  Processamento
 *      Calcular o valor que cada amigo vai receber. 
 *      
 *  Saída
 *      Exibir o valor que cada um vai receber. 
 */

namespace Loteria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n-------------- LOTERIA\n");

            // Habilitando as entradas
            Console.Write("Digite o valor que o AMIGO_1 apostou: R$ ");
            double valorApostaAmigo1 = double.Parse(Console.ReadLine());

            Console.Write("Digite o valor que o AMIGO_2 apostou: R$ ");
            double valorApostaAmigo2 = double.Parse(Console.ReadLine());

            Console.Write("Digite o valor que o AMIGO_3 apostou: R$ ");
            double valorApostaAmigo3 = double.Parse(Console.ReadLine());

            Console.Write("\nDigite o valor do prêmio: R$ ");
            double premio = double.Parse(Console.ReadLine());

            // Processamento
            double valorTotalAposta = valorApostaAmigo1 + valorApostaAmigo2 + valorApostaAmigo3;

            double premioAmigo1 = (valorApostaAmigo1 / valorTotalAposta) * premio;
            double premioAmigo2 = (valorApostaAmigo2 / valorTotalAposta) * premio;
            double premioAmigo3 = (valorApostaAmigo3 / valorTotalAposta) * premio;

            // Exibicao dos resultados
            Console.WriteLine("\n-------------- RESULTADOS\n");
            Console.WriteLine($"O AMIGO_1 receberá: R$ {premioAmigo1:0.00}.");
            Console.WriteLine($"O AMIGO_2 receberá: R$ {premioAmigo2:0.00}.");
            Console.WriteLine($"O AMIGO_3 receberá: R$ {premioAmigo3:0.00}.");

            Console.Write("\nPressione ENTER para finalizar o sistema!");
            Console.ReadLine();
        }
    }
}

