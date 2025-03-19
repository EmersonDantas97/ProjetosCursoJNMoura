using System;
using System.Collections.Generic;

// Projeto feito pelo professor, onde implementamos o Queue

namespace Banco_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Fila de Banco com Vetor--");

            const int QTDEPOSICOES = 5;

            Queue<int> fila = new Queue<int>(QTDEPOSICOES);
            int senhaAtual = 1;

            while (true)
            {
                Console.WriteLine("\nOpções:\n");
                Console.WriteLine("\t1 - Pegar senha");
                Console.WriteLine("\t2 - Chamar senha");
                Console.WriteLine("\t3 - Imprimir fila");
                Console.WriteLine("\t4 - Encerrar programa");
                Console.Write("\nEscolha uma opção: ");

                int opcao;
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        if (fila.Count < QTDEPOSICOES)
                        {
                            fila.Enqueue(senhaAtual++); ///--------------- 
                            Console.WriteLine("Senha adicionada à fila.");
                        }
                        else
                        {
                            Console.WriteLine("Fila cheia! Aguarde para ser chamado.");
                        }
                        break;

                    case 2:
                        if (fila.Count > 0)
                        {
                            int senhaChamada = fila.Dequeue();
                            Console.WriteLine($"Senha chamada: {senhaChamada}"); ///--------------- 
                        }
                        else
                        {
                            Console.WriteLine("Fila vazia! Ninguém para chamar.");
                        }
                        break;

                    case 3:
                        if (fila.Count > 0)
                        {
                            Console.Write("Fila atual: ");

                            foreach (int item in fila)
                                Console.Write($"{item} ");

                            //for (int i = 0; i < fila.Count; i++) // Dá pra fazer desta maneira também. 
                            //    Console.Write($"{fila.ElementAt(i)} ");

                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Fila vazia!");
                        }
                        break;

                    case 4:
                        if (fila.Count == 0)
                        {
                            Console.WriteLine("Encerrando o programa...");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Ainda há senhas na fila! Aguarde o atendimento.");
                        }
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Escolha entre 1 e 4.");
                        break;
                }

                Console.WriteLine("\n--Pressione ENTER para continuar--");
                Console.ReadLine();

            }
        }
    }
}

