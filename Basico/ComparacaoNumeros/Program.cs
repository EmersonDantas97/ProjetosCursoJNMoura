using System;

/*
 Usuário vai entrar com dois números inteiros
 Compará-los *  
     Exibir o Maior (Resquisito básico).
     Exibir o Menor (Resquisito básico).
     São iguais (Resquisito básico).
 */

/*
 Estrutura de decisao
    1 - Simples
    2 - Composta
    3 - Encadeada 
    4 - Aninhada
    Dica: Sempre tentar deixar a 1ª condição, a mais provavel de acontecer (sem levar em consideracao os erros).
 */

namespace ComparacaoNumeros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n------- COMPARAÇÃO DE NUMEROS");

            int numero1, numero2;

            Console.Write("\nDigite o 1º número: ");
            numero1 = int.Parse(Console.ReadLine());

            Console.Write("Digite o 2º número: ");
            numero2 = int.Parse(Console.ReadLine());

            if (numero1 == numero2) // O indicado e primeiro ser o de igualdade para economizar processamento.
            {
                Console.WriteLine("\n → Os dois números SÃO IGUAIS.");
            }
            else if (numero1 > numero2)
            {
                Console.WriteLine($"\n → O 1º número ({numero1}) é MAIOR.");
                Console.WriteLine($" → O 2º número ({numero2}) é MENOR.");
            }
            else
            {
                Console.WriteLine($"\n → O 2º número ({numero2}) é MAIOR.");
                Console.WriteLine($" → O 1º número ({numero1}) é MENOR.");
            }

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();
        }
    }
}
