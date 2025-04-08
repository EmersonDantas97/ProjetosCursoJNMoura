using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Loja de manutenção de eletrodoméstico

    eletrodoméstico - nome, defeito
    loja - receber os eletrodomésticos
    eletrodoméstico - nome, defeito
    loja - receber os eletrodomésticos
    loja - consertar eletrodomestico
    loja - entregar o eletrodomestico pelo nome
 */

namespace LojaEletrodomesticos
{
    internal class Program
    {
        enum OpcoesSistema
        {
            Entregar = 1,
            Consertar = 2,
            Receber = 3,
            Sair = 4,
            Nenhuma = 0
        }

        public static Eletrodomestico ColetaDadosEletrodomestico()
        {
            Eletrodomestico novoEletroDomesticoParaConserto = new Eletrodomestico();

            Console.Write("\n\tDigite o NOME do eletrodoméstico: ");
            novoEletroDomesticoParaConserto.Nome = Console.ReadLine();

            return novoEletroDomesticoParaConserto;
        }

        static void Main(string[] args)
        {

            uint opcaoDigitada = 0;
            bool opcaoInvalida = false;

            Loja loja = new Loja();

            while (true)
            {
                Console.WriteLine($"\n--------- CONSERTO ELETRODOMESTICO\n");

                Console.WriteLine($"Verifique as opções abaixo e selecione o serviço, pressionando o seu número de correspondência: \n");
                Console.WriteLine($"\t[1] - Entregar eletrodoméstico para conserto");
                Console.WriteLine($"\t[2] - Consertar eletrodoméstico");
                Console.WriteLine($"\t[3] - Receber eletrodoméstico");
                Console.WriteLine($"\t[4] - Fechar sistema");

                do
                {
                    Console.Write("\nDigite a opção desejada: ");
                    opcaoInvalida = !uint.TryParse(Console.ReadLine(), out opcaoDigitada) || !(opcaoDigitada > 0 && opcaoDigitada < 5);

                    if (opcaoInvalida)
                        Console.WriteLine("\tResposta INVÁLIDA! Verifique as opções acima e tente novamente.");

                } while (opcaoInvalida);

                switch ((OpcoesSistema) opcaoDigitada)
                {
                    case OpcoesSistema.Entregar:
                        loja.EntregueParaConsertar(ColetaDadosEletrodomestico());
                        Console.WriteLine("\n\t>> Eletrodomestico adicionado à fila para conserto!");
                        break;

                    case OpcoesSistema.Consertar:
                        break;
                    case OpcoesSistema.Receber:
                        break;
                    case OpcoesSistema.Sair:
                        break;
                }

                Console.Write("\nPressione ENTER para retornar a seleção de opções!");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
