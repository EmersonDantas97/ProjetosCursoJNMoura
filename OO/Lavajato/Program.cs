using System;
using System.Collections.Generic;


/*
Console.WriteLine("[1] - Adicionar carro na fila de lavagem");
Console.WriteLine("[2] - Lavar carro da fila de lavagem");
Console.WriteLine("[3] - Retirar carro do pátio");
Console.WriteLine("[4] - Sair do lava jato");

Opção 1:
    Gerar Id com auto incremento (+1).
    Perguntar o nome do carro.
    Perguntar ano do carro.
    Adicionar o carro na fila.

Opção 2:
    Pegar o primeiro carro da fila de carros (retirar desta fila).
    Manda para o pátio (Adicionar a uma lista).
    Perguntar qual carro deseja retirar. 
    Utilizar foreach. Para treinar a lógica. 

Opção 3:
    Perguntar o id do carro, para ser removido da lista de carros no pátio. 
    Buscar na lista o id informado.
    2 cenários podem ocorrer:
        1º Cenário - Encontrar o carro: Retirar o carro da lista
        2º Cenário - Não encontrar o carro: Dar mensagem carro não encontrado.

Opção 4: 
    Perguntar: Deseja encerrar o programa?
    2 cenários podem ocorrer:
        1º Cenário - Sim. Encerrar. Não pode ter carros na fila de carros, nem na lista de carros.
        2º Cenário - Não. Continua.

Obs: Por enquanto, não adicionar o dono do carro.
 */

// OOExercicios

namespace Lavajato
{

    internal class Program
    {
        enum opcoesSistema 
        {
            adicionarCarroNaFila  = 1,
            lavarCarroDaFila = 2,
            retirarCarroDoPatio = 3,
            sairDoPrograma = 4
        }

        static void Main(string[] args)
        {
            bool opcaoDigitadaEInvalida = false;

            uint opcaoDigitada = 0;

            int novaSenha = 0;

            Queue<Carro> filaDeCarrosParaLavar = new Queue<Carro>();
            List<Carro> carrosNoPatio = new List<Carro>();

            while (true)
            { 
                Console.WriteLine("\n--------- LAVAJATO\n");

                Console.WriteLine($"\t[{(int)opcoesSistema.adicionarCarroNaFila}] - Adicionar carro na fila de lavagem.");
                Console.WriteLine($"\t[{(int)opcoesSistema.lavarCarroDaFila}] - Lavar carro da fila de lavagem.");
                Console.WriteLine($"\t[{(int)opcoesSistema.retirarCarroDoPatio}] - Retirar carro do pátio.");
                Console.WriteLine($"\t[{(int)opcoesSistema.sairDoPrograma}] - Sair do lava jato.");

                do
                {
                    Console.Write("\nDigite a opção desejada: ");
                    opcaoDigitadaEInvalida = !uint.TryParse(Console.ReadLine(), out opcaoDigitada) || 
                        !(opcaoDigitada >= (int)opcoesSistema.adicionarCarroNaFila && opcaoDigitada <= (int)opcoesSistema.sairDoPrograma);
                        
                    if (opcaoDigitadaEInvalida)
                        Console.WriteLine("\tOpção digitada é inválida! Verifique as opções acima...");

                } while (opcaoDigitadaEInvalida);

                switch (opcaoDigitada)
                {
                    case (int) opcoesSistema.adicionarCarroNaFila:

                        Carro carroNovoNaFila = new Carro();

                        carroNovoNaFila.Id = ++novaSenha;

                        Console.WriteLine();

                        Console.Write("\tInforme o NOME do carro: ");
                        carroNovoNaFila.Nome = Console.ReadLine();

                        Console.Write("\tInforme o ANO do carro: ");
                        carroNovoNaFila.Ano = int.Parse(Console.ReadLine());

                        filaDeCarrosParaLavar.Enqueue(carroNovoNaFila);

                        Console.WriteLine($"\n\tCarro adicionado na fila! SUA SENHA É: {carroNovoNaFila.Id}");

                        Console.Write("\nAção concluída! Pressione ENTER para retornar para o menu de opções!");
                        Console.ReadLine();

                        Console.Clear();

                        break;

                    case (int) opcoesSistema.lavarCarroDaFila:

                        if (filaDeCarrosParaLavar.Count == 0)
                        {
                            Console.WriteLine("\n\tNão tem carros para serem atendidos!");
                        }
                        else
                        {
                            Carro carroSendoLavado = filaDeCarrosParaLavar.Dequeue();

                            Console.WriteLine($"\n\tSenha chamada: {carroSendoLavado.Id} / {carroSendoLavado.Nome}");
                            
                            carrosNoPatio.Add(carroSendoLavado);
                        }
                        
                        Console.Write("\nAção concluída! Pressione ENTER para retornar para o menu de opções!");
                        Console.ReadLine();

                        Console.Clear();

                        break;

                    case (int) opcoesSistema.retirarCarroDoPatio:

                        if (carrosNoPatio.Count == 0)
                        {
                            Console.WriteLine("\n\tNão tem carros no pátio para retirada!");

                            Console.Write("\nAção concluída! Pressione ENTER para retornar para o menu de opções!");
                            Console.ReadLine();

                            Console.Clear();
                        }
                        else
                        {
                            //Console.Write("Digite o ID do carro que será retirado: "); 
                            //int idDoCarroParaRetirada = int.Parse(Console.ReadLine());

                            //int  contador = 0;

                            //foreach (var carro in carrosNoPatio)
                           // {

                            #region Ideia inicial
                            //if (carro.Id == idDoCarroParaRetirada)
                            //{
                            //    Console.WriteLine($"\n\tSeu {carro.Nome} foi lavado! Pode ser retirado!");
                            //    carrosNoPatio.Remove(carro);

                            //    Console.Write("\nAção concluída! Pressione ENTER para retornar para o menu de opções!");
                            //    Console.ReadLine();
                            //    Console.Clear();
                            //    break;
                            //}
                            //else
                            //{
                            //    Console.WriteLine("Carro inexistente! Digite o id correto...\n");
                            //}
                            #endregion

                                Console.WriteLine("\n\tDigite o id do carro que sera retirado: ");
                                int tirar = int.Parse(Console.ReadLine());
                                int c = 0;

                                foreach (Carro item in carrosNoPatio) //confere all itens
                                {
                                    if (item.Id == tirar) //procura carro com id igual ao digitado
                                    {
                                        Console.WriteLine("Seu carro ja foi lavado e pode ser retirado.");
                                        carrosNoPatio.Remove(item);
                                        break;
                                    }
                                    // Caso não encontre, irá adicionar 1 ao contador. 
                                    // Simbolizando que eu já tentei remover 1 carro e não consegui.
                                    else
                                    {
                                        c++;
                                    }

                                    // 10 carros no patio, tentei 10 vezes remover e não. dá a msg!
                                    if (c == carrosNoPatio.Count)
                                    {
                                    Console.WriteLine("Carro não encontrado!");
                                    }
                                }
                        }
                        break;

                    case (int) opcoesSistema.sairDoPrograma:

                        Console.Write("\nDeseja encerrar o programa? (S/N): ");
                        var resposta = Console.ReadLine();

                        if (resposta == "S")
                        {
                            // Verificação se tem carros na fila, antes de encerrar o programa.
                            if (carrosNoPatio.Count == 0 && filaDeCarrosParaLavar.Count == 0)
                            {
                                Console.WriteLine("\nEncerrando o programa...");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("\n\tAinda há senhas na fila! Aguarde o atendimento.");
                                Console.Write("\nPressione ENTER para retornar para o menu de opções!");
                                Console.ReadLine();

                                Console.Clear();
                            }
                        } else if (resposta == "N")
                        {
                            Console.Write("\nPressione ENTER para retornar para o menu de opções!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                }
            }

            Console.Write("\nPressione ENTER para fechar o programa!");
            Console.ReadLine();
        }
    }
}
