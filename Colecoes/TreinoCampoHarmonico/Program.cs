using System;
using System.Collections.Generic;

namespace TreinoCampoHarmonico
{
    internal class Program
    {
        static void Main(string[] args)
        {


            bool repetePerguntaOpcao = false;

            uint opcaoSelecionadaNoMenu = 0;
            uint qtdExerciciosQueVaiFazer = 0;

            const int CAMPOHARMONICOALEATORIO = 1;
            const int RECONHECENDOGRAUCAMPOHARMONICO = 2;

            const int NUMEROACORDESCAMPOHARMONICO = 7;

            List<string> CampoHarmonicoC = new List<string>() { "C", "Dm", "Em", "F", "G", "Am", "Bº" };
            List<string> CampoHarmonicoD = new List<string>() { "D", "Em", "F#m", "G", "A", "Bm", "C#º" };


            while (true)
            {
                // Apresentando o menu
                Console.WriteLine("\n--------- TREINO CAMPO HARMONICO\n");
                Console.WriteLine("Verifique as opções abaixo e selecione a modalidade de treino, pressionando o seu número de correspondência: \n");
                Console.WriteLine("\t1 - Campo harmonico aleatório");
                Console.WriteLine("\t2 - Reconhecimento de grau");
                Console.WriteLine("\t3 - Opção_3 ");
                Console.WriteLine("\t4 - Opção_4 ");

                // Fazendo validação para não permitir LETRAS e NÚMEROS
                do
                {
                    Console.Write("\nDigite a opção desejada: ");

                    repetePerguntaOpcao = !(uint.TryParse(Console.ReadLine(), out opcaoSelecionadaNoMenu)) || opcaoSelecionadaNoMenu < 1 || opcaoSelecionadaNoMenu > 4;

                    if (repetePerguntaOpcao)
                        Console.WriteLine("\n\tDigite um valor VÁLIDO!");

                } while (repetePerguntaOpcao);

                // Perguntando quantos exercicios quer fazer e fazer uma validacao
                do
                {
                    Console.Write("\nDigite a QUANTIDADE DE EXERCICIOS que deseja fazer: ");

                    repetePerguntaOpcao = !(uint.TryParse(Console.ReadLine(), out qtdExerciciosQueVaiFazer));

                    if (repetePerguntaOpcao)
                        Console.WriteLine("\n\tDigite um valor VÁLIDO!");

                } while (repetePerguntaOpcao);


                switch (opcaoSelecionadaNoMenu)
                {
                    case CAMPOHARMONICOALEATORIO:

                        break;

                    case RECONHECENDOGRAUCAMPOHARMONICO:
                        break;

                    case 3:
                        break;

                    default:
                        break;
                }


                Console.Write("Campo Harmonico: ");

                for (int i = 0; i < NUMEROACORDESCAMPOHARMONICO; i++)
                {
                    Console.Write($"{CampoHarmonicoC[i]} ");
                }

                // Mensagem padrão para retornar para tela anterior
                Console.Write("\nPressione ENTER retornar para tela anterior!");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine();
            }
        }
    }
}
