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
            const int PRIMEIRASENHA = 1;

            int novaSenha = 0;                          // Armazena nova senha. Caso exceda o limite, é tomada decisões diferentes.

            const int EXCEDEULIMITESENHAS = QTDMAXIMASENHAS + 1;    //  Variavel criada para ficar mais facil leitura, caso exceda o limite de senhas permitidas

            int qtdSenhasAtivas = 0;                    // Contador de senhas pendentes de serem chamadas

            int[] senhasPendentesDeSeremAtendidas = new int[QTDMAXIMASENHAS];   // Fila de atendimento

            uint opcaoSelecionadaPeloCliente = 0;       // Opção que o cliente selecionara no menu

            bool repetePerguntaOpcao = false;           // Variavel para evitar ter que fazer o mesmo teste logico 2x.


            while (true)
            {
                Console.WriteLine("\n--------- BANCO\n");
                Console.WriteLine("Verifique as opções abaixo e selecione o serviço, pressionando o seu número de correspondência: \n");
                Console.WriteLine("\t1 - Pegar Senha ");
                Console.WriteLine("\t2 - Chamar Senha ");
                Console.WriteLine("\t3 - Imprimir fila ");
                Console.WriteLine("\t4 - Encerrar o programa ");

                // Fazendo validação para não permitir LETRAS e NÚMEROS
                do
                {
                    Console.Write("\nDigite o serviço desejado: ");

                    repetePerguntaOpcao = uint.TryParse(Console.ReadLine(), out opcaoSelecionadaPeloCliente);

                    repetePerguntaOpcao = !repetePerguntaOpcao || 
                        opcaoSelecionadaPeloCliente < 1 || 
                        opcaoSelecionadaPeloCliente > 4;
                    
                    if (repetePerguntaOpcao)
                        Console.WriteLine("\n\tDigite um valor VÁLIDO!");

                } while (repetePerguntaOpcao);


                // Processamento
                switch (opcaoSelecionadaPeloCliente)
                {

                    case PEGARSENHA:


                        if (qtdSenhasAtivas == 0)
                        {
                            senhasPendentesDeSeremAtendidas[0] = novaSenha = PRIMEIRASENHA;
                        } 
                        else if (qtdSenhasAtivas == QTDMAXIMASENHAS)
                        {
                            Console.Clear();
                            Console.WriteLine("\n--------- BANCO\n");
                            Console.WriteLine($"\tNão é possível gerar uma nova senha! TENTE NOVAMENTE MAIS TARDE!");
                            break;
                        }
                        else
                        {
                            for (int i = 0; i < QTDMAXIMASENHAS; i++)
                            {
                                if (senhasPendentesDeSeremAtendidas[i] == 0)
                                {
                                    novaSenha = senhasPendentesDeSeremAtendidas[i - 1] + 1;

                                    if (novaSenha >= EXCEDEULIMITESENHAS)
                                        senhasPendentesDeSeremAtendidas[i] = novaSenha = PRIMEIRASENHA;

                                    senhasPendentesDeSeremAtendidas[i] = novaSenha;

                                    break;
                                }
                            }
                        }

                        qtdSenhasAtivas++;

                        Console.Clear();
                        Console.WriteLine("\n--------- BANCO\n");
                        Console.WriteLine($"\tSUA SENHA É: {novaSenha}");

                        break;

                    case CHAMARSENHA:

                        // Caso não tenha senhas pendentes de serem chamadas dá mensagem específica
                        if (qtdSenhasAtivas == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\n--------- BANCO\n");
                            Console.WriteLine($"\tNÃO HÁ SENHAS EM ESPERA!");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n--------- BANCO\n");
                            Console.WriteLine($"\tSENHA: {senhasPendentesDeSeremAtendidas[0]}\n\tCompareça ao guichê!");
                            
                            senhasPendentesDeSeremAtendidas[0] = 0;

                            qtdSenhasAtivas--;

                            // Reorganiza a fila
                            for (int i = 0; i < qtdSenhasAtivas; i++)
                            {
                                senhasPendentesDeSeremAtendidas[i] = senhasPendentesDeSeremAtendidas[i + 1]; 
                            }

                            // Apagando ultimo registro do array, para evitar duplicidades
                            if (qtdSenhasAtivas == 4)
                                senhasPendentesDeSeremAtendidas[QTDMAXIMASENHAS - 1] = 0;
                            else
                                senhasPendentesDeSeremAtendidas[qtdSenhasAtivas] = 0;
                        }
                        break;

                    case IMPRIMIRFILA:

                        Console.Clear();
                        Console.WriteLine("\n--------- BANCO\n");
                        Console.WriteLine($"\tO banco está com {qtdSenhasAtivas} senhas em espera.");

                        Console.Write($"\tAS SENHAS QUE ESTÃO AGUARDANDO SÃO: ");
                        for (int i = 0; i < qtdSenhasAtivas; i++)
                        {
                            Console.Write($"{senhasPendentesDeSeremAtendidas[i]} ");
                        }

                        Console.WriteLine();

                        break;

                    case ENCERRARPROGRAMA:

                        // Caso não tenha sido retirado senha, sai do programa.
                        if (qtdSenhasAtivas == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\n--------- BANCO\n");
                            Console.Write("\tPrograma será encerrado!\n");
                            Console.Write("\nPressione ENTER retornar para tela anterior!");
                            Console.ReadLine();
                            return;
                        }
                        // Caso tenhas senhas pendentes de serem atendidas, não sai do programa
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n--------- BANCO\n");
                            Console.Write("\tImpossível encerrar o programa! \n\n\tExistem senhas pendente de serem atendidas!\n");
                        }
                        break;
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