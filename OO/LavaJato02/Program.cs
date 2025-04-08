using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

namespace LavaJato02
{
    internal class Program
    {
        enum opcoesDoSistema
        {
            adicionarCarroNaFilaDeLavagem = 1,
            lavarCarro = 2,
            retirarCarro = 3,
            fecharPrograma = 4
        }

        public static void instrucoesParaRetornarAoMenu()
        {
            Console.WriteLine();
            Console.Write("Ação finalizada! Pressione ENTER para retornar ao menu anterior...");
            Console.ReadLine();
            Console.Clear();
            return;
        }

        static Carro ObterDadosCarro(int ID)
        {
            Carro novoCarroNaFila = new Carro();
            novoCarroNaFila.Id = ID;

            Console.Write("\n\tDigite o MODELO do carro: ");
            novoCarroNaFila.Nome = Console.ReadLine();

            Console.Write("\tDigite o ANO do carro: ");
            novoCarroNaFila.Ano = int.Parse(Console.ReadLine());

            return novoCarroNaFila;
        }

        static void Main(string[] args)
        {

            bool opcaoDigitadaEInvalida = false;

            uint opcaoDigitadaPeloUsuario = 0;

            int novaSenha = 0;

            LavaCar lavaJato = new LavaCar();

            while (true)
            {
                Console.WriteLine($"\n--------- LAVAJATO\n");
                Console.WriteLine($"Verifique as opções abaixo e selecione o serviço, pressionando o seu número de correspondência: \n");
                Console.WriteLine($"\t[{(int)opcoesDoSistema.adicionarCarroNaFilaDeLavagem}] - Adicionar carro na fila de lavagem");
                Console.WriteLine($"\t[{(int)opcoesDoSistema.lavarCarro}] - Lavar carro da fila de lavagem");
                Console.WriteLine($"\t[{(int)opcoesDoSistema.retirarCarro}] - Retirar carro do pátio");
                Console.WriteLine($"\t[{(int)opcoesDoSistema.fecharPrograma}] - Sair do lava jato");

                do
                {
                    Console.Write("\nDigite a opção desejada: ");
                    opcaoDigitadaEInvalida = !uint.TryParse(Console.ReadLine(), out opcaoDigitadaPeloUsuario) ||
                        !(opcaoDigitadaPeloUsuario >= (int)opcoesDoSistema.adicionarCarroNaFilaDeLavagem && opcaoDigitadaPeloUsuario <= (int)opcoesDoSistema.fecharPrograma);

                    if (opcaoDigitadaEInvalida)
                        Console.WriteLine("\tOpção digitada é INVÁLIDA! Verifique as opções acima e tente novamente...");

                } while (opcaoDigitadaEInvalida);


                switch (opcaoDigitadaPeloUsuario)
                {
                    case (int)opcoesDoSistema.adicionarCarroNaFilaDeLavagem:

                        lavaJato.AdicionarCarroParaLavar(ObterDadosCarro(++novaSenha));

                        Console.WriteLine($"\n\tCarro foi adicionado a fila e será limpo em breve! Sua senha é <{novaSenha}>");

                        break;

                    case (int)opcoesDoSistema.lavarCarro:

                        if (!lavaJato.TemCarroParaLavar())
                        { 
                            Console.WriteLine("\n\tNão tem carros na fila para lavagem!");
                            break;
                        }

                        lavaJato.LavarCarro();

                        Console.WriteLine($"\n\tCarro <{lavaJato.LavarCarro().Nome}> sendo lavado e encaminhado ao pátio!");

                        break;

                    case (int)opcoesDoSistema.retirarCarro:

                        if (!lavaJato.TemCarroNoPatio())
                        {
                            Console.WriteLine("\n\tNão tem carros no pátio!");
                            break;
                        }

                        uint idDoCarroASerChamado = 0;

                        bool idDigitadoEInvalido = false;

                        bool carroNaoEncontrado = true;

                        do
                        {
                            Console.Write("\n\tDigite o ID do carro a ser chamado: ");
                            idDigitadoEInvalido = !uint.TryParse(Console.ReadLine(), out idDoCarroASerChamado);

                            foreach (Carro carro in lavaJato.ListaDeCarrosNoPatio())
                            {
                                if (idDoCarroASerChamado == carro.Id)
                                {
                                    carroNaoEncontrado = lavaJato.RemoveCarro(idDoCarroASerChamado);
                                    Console.WriteLine($"\n\tCarro <{carro.Nome}> entregue ao cliente! ");
                                    break;
                                }
                            }

                            if (idDigitadoEInvalido)
                                Console.WriteLine("\n\tID digitádo é inválido! Confirme o ID correto e tente novamente...");
                            else if (carroNaoEncontrado)
                                Console.WriteLine("\tNenhum carro encontrado com o ID informado! Confirme o ID e tente novamente...");

                        } while (idDigitadoEInvalido || carroNaoEncontrado);

                        break;

                    case (int)opcoesDoSistema.fecharPrograma:

                        if (!lavaJato.TemCarroNoLavaCar())
                        {
                            Console.Write("\n\tSistema sendo encerrado! \n\nPressione ENTER para fechar a tela...");
                            Console.ReadLine();
                            return;
                        }
                        Console.WriteLine("\n\tNão é possível encerrar o sistema! Existem carros a serem entregues...");
                        break;
                }
                instrucoesParaRetornarAoMenu();
            }
        }
    }
}
