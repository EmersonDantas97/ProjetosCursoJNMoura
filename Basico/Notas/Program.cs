using System;

/*
    Faça um programa para ler três notas e o número de faltas de um aluno e escrever qual a sua situação final: 
    Aprovado, Reprovado por Falta ou Reprovado por Média. 
    A média para aprovação é 7,0 e o limite de faltas é 25% do total de aulas. 
    O número de aulas ministradas no semestre foi de 80. A reprovação por falta sobrepõe a reprovação por Média.
 */

namespace Notas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n--------- NOTAS");

            Console.Write("\nDigite o valor da nota 1: ");
            double nota1 = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor da nota 2: ");
            double nota2 = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor da nota 3: ");
            double nota3 = int.Parse(Console.ReadLine());

            Console.Write("Digite numero de faltas: ");
            double numeroDeFaltas = int.Parse(Console.ReadLine());
            
            const double numeroDeAulas = 80;
            double porcentagemFaltas = numeroDeFaltas / numeroDeAulas;
            const double presencaMinima = 0.25;

            double mediaNotas = (nota1 + nota2 + nota3) / 3;
            const double mediaDeCorte = 7.00;

            if (porcentagemFaltas > presencaMinima)
                Console.WriteLine("\n Aluno foi REPROVADO POR FALTA!");
            else if (mediaNotas < mediaDeCorte)
                Console.WriteLine("\n Aluno foi REPROVADO POR MÉDIA!");
            else
                Console.WriteLine("\n Aluno foi APROVADO!");

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();

        }
    }
}
