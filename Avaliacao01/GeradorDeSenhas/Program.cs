using System;
using System.Collections.Generic;

// FIFO
// Exibir fila de atendimento

// Sem comentário

namespace GeradorDeSenhas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int novaSenha = 0;
            string senhaGerada = "000000";

            int qtdSenhasAtivas = 0;

            bool repetePergunta = false;

            const int GERARSENHACOMUM = 1;
            const int GERARSENHAPREFERENCIAL = 2;
            const int CHAMARSENHA = 3;
            const int ENCERRARATENDIMENTO = 4;
            const int EXIBIRFILA = 5;

            uint opcaoSelecionadaPeloCliente = 0;

            Queue<string> filaComum = new Queue<string>();
            Queue<string> filaPreferencial = new Queue<string>();

            while (true)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("------------Bem vindo ao Banco---------------");
                Console.WriteLine("---------------------------------------------\n");
                Console.WriteLine("Verifique as opções abaixo e selecione o serviço, pressionando o seu número de correspondência: \n");
                Console.WriteLine("\t1 - Gerar senha para atendimento comum");
                Console.WriteLine("\t2 - Gerar senha para atendimento prioritário");
                Console.WriteLine("\t3 - Chamada da senha para atendimento");
                Console.WriteLine("\t4 - Encerramento do atendimento");
                Console.WriteLine("\t5 - Exibir fila de atendimento");

                do
                {
                    Console.Write("\nDigite o serviço desejado: ");

                    repetePergunta = !uint.TryParse(Console.ReadLine(), out opcaoSelecionadaPeloCliente) || opcaoSelecionadaPeloCliente < 1 || opcaoSelecionadaPeloCliente > 5;

                    if (repetePergunta)
                        Console.WriteLine("\tOpção inválida! Verifique as opções acima e tente novamente.");

                } while (repetePergunta);

                if (opcaoSelecionadaPeloCliente == GERARSENHACOMUM || opcaoSelecionadaPeloCliente == GERARSENHAPREFERENCIAL)
                {
                    novaSenha++;
                    qtdSenhasAtivas++;
                }

                switch (opcaoSelecionadaPeloCliente)
                {
                    case GERARSENHACOMUM:
                        senhaGerada = $"{novaSenha:000000}";
                        filaComum.Enqueue(senhaGerada);
                        Console.WriteLine($"\n\tSUA SENHA É: {senhaGerada}");
                        break;

                    case CHAMARSENHA:
                        
                        if (qtdSenhasAtivas == 0)
                        {
                            Console.WriteLine("\n\tNão há senhas pendentes de serem chamadas");
                            break;
                        }

                        qtdSenhasAtivas--;

                        if (filaPreferencial.Count > 0)
                        { 
                            foreach (string senha in filaPreferencial)
                            {
                                Console.WriteLine($"\n\tSENHA: {filaPreferencial.Dequeue()}");
                                Console.WriteLine($"\tCompareça ao guichê!");
                                break;
                            }
                        }
                        else
                        { 
                            foreach (string senha in filaComum)
                            {
                                Console.WriteLine($"\n\tSENHA: {filaComum.Dequeue()}");
                                Console.WriteLine($"\tCompareça ao guichê!");
                                break;
                            }
                        }

                        break;

                    case GERARSENHAPREFERENCIAL:
                        senhaGerada = $"{novaSenha:000000}";
                        filaPreferencial.Enqueue(senhaGerada);
                        Console.WriteLine($"\n\tSUA SENHA É: {senhaGerada}");
                        break;

                    case EXIBIRFILA:
                        Console.Write("\nSENHAS EM ESPERA: ");

                        if (filaComum.Count == 0 && filaPreferencial.Count == 0)
                        {
                            Console.Write("0. Não há senhas em espera!");
                        }
                        else
                        {
                            foreach (string senha in filaPreferencial)
                                Console.Write($"{senha} ");
                            foreach (string senha in filaComum)
                                Console.Write($"{senha} ");
                        }

                        Console.WriteLine();

                        break;

                    case ENCERRARATENDIMENTO:
                        if (qtdSenhasAtivas == 0)
                        {
                            Console.Write("\n\tAtendimento encerrado.\n");
                            Console.Write("\nPressione ENTER para fechar o programa!");
                            Console.ReadLine();
                            return;
                        }
                        else
                        {
                            Console.Write("\n\tAtendimento não pode ser encerrado. \n\n\tExistem senhas pendentes de serem atendidas!\n");
                        }
                        break;
                }

                Console.Write("\nSolicitação concluída! Pressione ENTER para selecionar outro serviço!");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine();
            }
        }
    }
}
