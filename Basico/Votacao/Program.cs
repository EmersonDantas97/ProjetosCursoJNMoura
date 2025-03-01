using System;

/* 
 Em uma eleição presidencial, existem quatro candidatos. Os votos são informados através de códigos. Os códigos utilizados são:

    • 1,2,3,4 votos para os respectivos candidatos;
    • 5 voto nulo; 
    • 6 voto em branco.

    Assim, escreva um programa para receber um único voto e imprima: 
    • Se o usuário votou em um candidato: "Voto contabilizado com sucesso..."
    • Se o usuário votou nulo: "Voto nulo contabilizado..."
    • Se o usuário votou em branco: "Voto branco contabilizado..."
    • Se o voto for diferente de todas as opções acima: "Voto inválido..."
*/

namespace Votacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n--------- VOTACAO");


            Console.WriteLine("\n  Digite 1 e pressione a tecla ENTER para: CANDIDATO_1");
            Console.WriteLine("  Digite 2 e pressione a tecla ENTER para: CANDIDATO_2");
            Console.WriteLine("  Digite 3 e pressione a tecla ENTER para: CANDIDATO_3");
            Console.WriteLine("  Digite 4 e pressione a tecla ENTER para: CANDIDATO_4");
            Console.WriteLine("  Digite 5 e pressione a tecla ENTER para: VOTO NULO");
            Console.WriteLine("  Digite 6 e pressione a tecla ENTER para: VOTO BRANCO");

            Console.Write("\nDigite seu voto: ");
            int voto = int.Parse(Console.ReadLine());

            #region "Solução 01"
            /*
            const int candidato1 = 1;
            const int candidato2 = 2;
            const int candidato3 = 3;
            const int candidato4 = 4;
            const int votoNulo = 5;
            const int votoBranco = 6;

            if (voto == candidato1 || voto == candidato2 || voto == candidato3 || voto == candidato4)
                Console.WriteLine("\n Voto contabilizado com SUCESSO...");
            else if (voto == votoNulo)
                Console.WriteLine("\n Voto NULO contabilizado...");
            else if (voto == votoBranco)
                Console.WriteLine("\n Voto BRANCO contabilizado...");
            else
                Console.WriteLine("\n Voto inválido! Verifique as opções acima e VOTE NOVAMENTE...");
            */
            #endregion

            #region "Solução 02"
            /*// SOLUÇÃO FEITA JUNTO AO PROFESSOR
            const int candidato1 = 1;
            const int candidato2 = 2;
            const int candidato3 = 3;
            const int candidato4 = 4;
            const int votoBranco = 5;
            const int votoNulo = 6;

            if (voto == candidato1)
                Console.WriteLine("\n Voto contabilizado com SUCESSO...");
            else if (voto == candidato2)
                Console.WriteLine("\n Voto contabilizado com SUCESSO...");
            else if (voto == candidato3)
                Console.WriteLine("\n Voto contabilizado com SUCESSO...");
            else if (voto == candidato4)
                Console.WriteLine("\n Voto contabilizado com SUCESSO...");
            else if (voto == votoBranco)
                Console.WriteLine("\n Voto BRANCO contabilizado...");
            else if (voto == votoNulo)
                Console.WriteLine("\n Voto NULO contabilizado...");
            else
                Console.WriteLine("\n Voto inválido! Verifique as opções acima e VOTE NOVAMENTE...");
            */
            #endregion

            #region "Solução 03"
            /*
            const int menorVotoValido = 1;
            const int maiorVotoValido = 4;
            const int votoBranco = 5;
            const int votoNulo = 6;

            if (voto >= menorVotoValido && voto <= maiorVotoValido)
                Console.WriteLine("\n Voto contabilizado com SUCESSO...");
            else if (voto == votoNulo)
                Console.WriteLine("\n Voto NULO contabilizado...");
            else if (voto == votoBranco)
                Console.WriteLine("\n Voto BRANCO contabilizado...");
            else
                Console.WriteLine("\n Voto inválido! Verifique as opções acima e VOTE NOVAMENTE...");
            #endregion
            */
            #endregion

            #region "Solução 04"
            const int candidato1 = 1;
            const int candidato2 = 2;
            const int candidato3 = 3;
            const int candidato4 = 4;
            const int votoNulo = 5;
            const int votoBranco = 6;

            switch (voto) // Cria a tabela em memoria e vai direto ao ponto especifico. Faz só um teste lógico. 
            {
                case candidato1:
                case candidato2:
                case candidato3:
                case candidato4:
                    Console.WriteLine("\n Voto contabilizado com SUCESSO...");
                    break;
                case votoBranco:
                    Console.WriteLine("\n Voto BRANCO contabilizado...");
                    break;
                case votoNulo:
                    Console.WriteLine("\n Voto NULO contabilizado...");
                    break;
                default:
                    Console.WriteLine("\n Voto inválido! Verifique as opções acima e VOTE NOVAMENTE...");
                    break;
            }
            #endregion

            Console.Write("\nPressione ENTER para finalizar o programa!");
            Console.ReadLine();
        }
    }
}
