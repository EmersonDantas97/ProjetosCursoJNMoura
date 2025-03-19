using System;
using System.Collections;
using System.Collections.Generic;

/*
 * Jogo
 * 
 * Soco  - s => 2 pontos
 * Chute - c => 5 pontos 
 * Magia - m => 10 pontos
 * 
 * Deseja executar um golpe (s-soco c-chute m-magia x-sair)?
 * 
 * x => sair
 * 
 * Soco(s)  => 10 => 20 pontos
 * Chute(s) => 3 => 15 pontos
 * Magia(s) => 4 => 40 pontos
 * Total de pontos => 75 pontos
 * 
 * -- Pressione ENTER para encerrar --
 */

namespace Jogo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n--------- JOGO\n");

            char golpeEscolhido = 'x';

            const char GOLPESOCO = 's';
            const char GOLPECHUTE = 'c';
            const char GOLPEMAGIA = 'm';
            const char OPCAOSAIR = 'x';

            int danoCausado = 0;

            const int DANOSOCO = 2;
            const int DANOCHUTE = 5;
            const int DANOMAGIA = 10;

            int qtdSocos = 0;
            int qtdChutes = 0;
            int qtdMagias = 0;

            bool repetePerguntaOpcao = false;

            while (true)
            {
                // Fazendo validação para não permitir LETRAS e NÚMEROS
                do
                {
                    Console.Write("Deseja executar um golpe(s-soco c-chute m-magia x-sair)? ");

                    repetePerguntaOpcao = !(char.TryParse(Console.ReadLine(), out golpeEscolhido)) || golpeEscolhido == GOLPESOCO || golpeEscolhido == GOLPECHUTE ||golpeEscolhido == GOLPEMAGIA;

                    if (repetePerguntaOpcao)
                        Console.Write("\n\tDigite um valor VÁLIDO!");

                } while (repetePerguntaOpcao);

                switch (golpeEscolhido)
                {
                    case GOLPESOCO:
                        qtdSocos++;
                        break;

                    case GOLPECHUTE:
                        qtdChutes++;
                        break;

                    case GOLPEMAGIA:
                        qtdMagias++;
                        break;

                    case OPCAOSAIR:
                        Console.WriteLine("\nO jogo será encerrado! Sua pontuação foi: \n");

                        danoCausado = (qtdSocos * DANOSOCO) + (qtdChutes * DANOCHUTE) + (qtdMagias * DANOMAGIA);

                        Console.WriteLine($"\tSoco(s)  => {qtdSocos} => {qtdSocos * DANOSOCO} pontos");
                        Console.WriteLine($"\tChute(s)  => {qtdChutes} => {qtdChutes * DANOCHUTE} pontos");
                        Console.WriteLine($"\tMagia(s)  => {qtdMagias} => {qtdMagias * DANOMAGIA} pontos");
                        Console.WriteLine($"\tTotal de pontos => {danoCausado} pontos");

                        Console.Write("\n-- Pressione ENTER para encerrar --");
                        Console.ReadLine();

                        return;
                }
            }
        }
    }
}
