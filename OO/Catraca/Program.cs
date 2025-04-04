using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catraca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carro

            uint opcaoSelecionadaPeloCliente = 0;

            bool repetePergunta = false;

            const int CADASTROALUNO = 1, 
                PASSARNACATRACA = 2, 
                EXCLUIRALUNO = 3, 
                ENCERRARSERVICO = 4;

            Dictionary<int, string> alunosCadastrados = new Dictionary<int, string>();

            Console.WriteLine("\n--------- CATRACA");

            Console.WriteLine("\nVerifique as opções abaixo e selecione o serviço com base no seu respectivo número: ");

            Console.WriteLine($"\n\t {CADASTROALUNO} - CADASTRAR ALUNO ");
            Console.WriteLine($"\t {PASSARNACATRACA} - PASSAR NA CATRACA ");
            Console.WriteLine($"\t {EXCLUIRALUNO} - EXCLUIR ALUNO ");
            Console.WriteLine($"\t {ENCERRARSERVICO} - ENCERRAR SERVIÇO ");

            do
            {
                Console.Write("\nDigite a opção referente ao serviço desejado: ");
                repetePergunta = !uint.TryParse(Console.ReadLine(), out opcaoSelecionadaPeloCliente) && (opcaoSelecionadaPeloCliente > 0 && opcaoSelecionadaPeloCliente < 4);

                if (repetePergunta)
                    Console.WriteLine("\tOpção desejada inválida! Verifique as opções acima e tente novamente....");

            } while (repetePergunta);

            Console.Write("\nPressione ENTER para fechar o programa!");
            Console.ReadLine();
        }
    }
}
