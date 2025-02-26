using System;

namespace Senha
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"\n--------- SENHA\n");

            Console.Write("Digite a sua senha: ");
            string senha = Console.ReadLine();

            if (senha.Length > 3)
            {
                if (senha == "123") // Utilizando operador relacional.Estrutura de decisao simples. Esta aninhada dentro de outra estrutura de decisao.
                { // Indica o inicio do bloco de instrucao.
                    Console.WriteLine("\nSenha CORRETA!");
                    Console.WriteLine("Acesso PERMITIDO! ;D");
                } // Indica o final do bloco de instrucao.
                else // É melhor para o desempenho do pc, pois testa so uma vez.
                {
                    Console.WriteLine("\nSenha INCORRETA!");
                    Console.WriteLine("Acesso NEGADO :(");
                    Console.Beep();
                }
            }
            else
            {
                Console.WriteLine("\nSenha fora do padrão!");
                Console.WriteLine("Acesso NEGADO :(");
                //return; Pode ser utilizado, mais vai impedir a execucao dos demais codigos. 
            }
            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();
        }
    }
}
