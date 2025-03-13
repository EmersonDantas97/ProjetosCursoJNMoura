using System;

namespace Banco
{
    internal class Program
    {

        /*  
        * Controlar uma fila de um banco com no máximo 5 posições (Array - inteiros)  
        * 4 opções  
        * 1 - Pegar senha (sequencial - valor inicial da senha é 1)  
        * 2 - Chamar senha (chamar na sequência)  
        * 3 - Imprimir a fila  
        * 4 - Encerrar o programa (se a fila estiver vazia)  
        * Ex.:  
        * Opção -> Senha  
        * 1 -> 1  
        * 1 -> 2  
        * 1 -> 3  
        * 2 -> 3  
        * 1 -> 4  
        * 3 -> 2, 3, 4  
        * 1 -> 5  
        * 3 -> 3, 4, 5  
        */  

        static void Main(string[] args)
        {
            const int QTDMAXIMASENHAS = 5;

            const int PEGARSENHA = 1;
            const int CHAMARSENHA = 2;
            const int IMPRIMIRFILA = 3;
            const int ENCERRARPROGRAMA = 4;

            int senhasRetiradas = 0;
            int senhasChamadas = 0;

            uint opcaoSelecionadaPeloCliente = 0;

            bool inseridoValorValido = false;

            int ultimaSenhaChamada = 0;

           //int[] senhasRetiradas = new int[QTDMAXIMASENHAS];
           //int[] senhasPossiveis = new int[QTDMAXIMASENHAS];

            Console.WriteLine("\n--------- BANCO\n");
            Console.WriteLine("Verifique as opções abaixo e selecione o serviço pressionando o seu número de correspondência: \n");
            Console.WriteLine("\t1 - Pegar Senha ");
            Console.WriteLine("\t2 - Chamar Senha ");
            Console.WriteLine("\t3 - Imprimir fila ");
            Console.WriteLine("\t4 - Encerrar o programa ");

            // Fazendo validação para não permitir LETRAS e NÚMEROS
            do
            {
                Console.Write("\nDigite o serviço desejado: ");

                inseridoValorValido = uint.TryParse(Console.ReadLine(), out opcaoSelecionadaPeloCliente);

                if (!inseridoValorValido || opcaoSelecionadaPeloCliente < 1 || opcaoSelecionadaPeloCliente > 4)
                    Console.WriteLine("\n\tDigite um valor VÁLIDO!");

            } while (!inseridoValorValido || opcaoSelecionadaPeloCliente < 1 || opcaoSelecionadaPeloCliente > 4);
            
            // Processamento
            switch (opcaoSelecionadaPeloCliente)
            {
                case PEGARSENHA:
                    senhasRetiradas++;
                    break;
                case CHAMARSENHA:
                    senhasChamadas++;
                    break;
                case IMPRIMIRFILA:
                    break;
                case ENCERRARPROGRAMA:
                    break;
            }

            

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();

        }
    }
}
