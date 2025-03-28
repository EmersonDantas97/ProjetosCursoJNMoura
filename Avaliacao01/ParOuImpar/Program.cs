using System;

namespace ParOuImpar
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random roleta = new Random();

            int partidasGanhasPeloComputador = 0;
            int partidasGanhasPeloJogador = 0;

            string opcaoJogador = "";

            bool repetePergunta = false;

            string desejaSairDoJogo;

            int numeroComputador = 0;
            int numeroJogador = 0;
            int somaDosNumeros = 0;

            string somaDosNumeroParOuImpar = "";

            while (true)
            {
                numeroComputador = roleta.Next(100);

                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("------Bem vindo ao jogo do Par ou Ímpar------");
                Console.WriteLine("---------------------------------------------\n");

                do
                {
                    Console.Write("Você quer par (p) ou ímpar (i)? ");
                    opcaoJogador = Console.ReadLine();

                    repetePergunta = !(opcaoJogador == "p" || opcaoJogador == "i");

                    if (repetePergunta)
                        Console.WriteLine("\tOpção selecionada inválida! Verifique as opções disponíveis e tente novamente.\n");

                } while (repetePergunta);

                do
                {
                    Console.Write("\nInforme um número inteiro: ");

                    repetePergunta = !int.TryParse(Console.ReadLine(),out numeroJogador);

                    if (repetePergunta)
                        Console.WriteLine("\tValor fornecido incorreto! Digite um número inteiro.");

                } while (repetePergunta);

                somaDosNumeros = numeroComputador + numeroJogador;

                somaDosNumeroParOuImpar = (somaDosNumeros % 2 == 0) ? "PAR" : "IMPAR";

                if (opcaoJogador == "i" && somaDosNumeroParOuImpar == "IMPAR")
                {
                    partidasGanhasPeloJogador++;
                    Console.WriteLine("\n------ RESULTADO DA RODADA\n\nO JOGADOR ganhou esta rodada!\n");
                }
                else if (opcaoJogador == "p" && somaDosNumeroParOuImpar == "PAR")
                {
                    partidasGanhasPeloJogador++;
                    Console.WriteLine("\n------ RESULTADO DA RODADA\n\nO JOGADOR ganhou esta rodada!\n");
                }
                else
                {
                    partidasGanhasPeloComputador++;
                    Console.WriteLine("\n------ RESULTADO DA RODADA\n\nO COMPUTADOR ganhou esta rodada!\n");
                }

                Console.WriteLine($"Número do computador: {numeroComputador}");
                Console.WriteLine($"Número do jogador: {numeroJogador}");
                Console.WriteLine($"O resultado da soma dos números é <{somaDosNumeros}> e este número é <{somaDosNumeroParOuImpar}>.\n");

                Console.Write("------ JOGAR NOVAMENTE\n\n");
                do
                {
                    Console.Write("Deseja jogar novamente? Digite (s) para 'Sim' e (n) para 'Não': ");
                    desejaSairDoJogo = Console.ReadLine();

                    repetePergunta = !(desejaSairDoJogo == "s" || desejaSairDoJogo == "n");

                    if (repetePergunta)
                        Console.WriteLine("\tOpção selecionada inválida! Verifique as opções disponíveis e tente novamente.\n");

                } while (repetePergunta);

                Console.Clear();

                if (desejaSairDoJogo == "n")
                {
                    string mensagem;

                    if (partidasGanhasPeloJogador > partidasGanhasPeloComputador)
                        mensagem = "Jogador ganhou";
                    else if (partidasGanhasPeloJogador < partidasGanhasPeloComputador)
                        mensagem = "Computador ganhou";
                    else
                        mensagem = "Empate";

                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("------Bem vindo ao jogo do Par ou Ímpar------");
                    Console.WriteLine("---------------------------------------------");

                    Console.WriteLine("\nRESUMO DAS PARTIDAS:");
                    Console.WriteLine($"\nJogador: {partidasGanhasPeloJogador} x Computador: {partidasGanhasPeloComputador} ({mensagem}).");
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("-----Pressione ENTER para fechar a tela------");
            Console.WriteLine("---------------------------------------------");
            Console.ReadLine();
        }
    }
}
