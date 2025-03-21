﻿using System;

/*
Treinamento para entendimento de criação de variáveis com base no escopo que foi criada.
*/

namespace Escopo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region "Teste de mesa 1"
            //int x = 0;
            //int j = 50;

            //for (int i = 0; i < 2; i++)
            //    x += 1;

            //if (x < 6)
            //{
            //    int y = 10;
            //    x = y + 5;

            //    if(y ==10)
            //    {
            //        int w = 90;
            //        x += w;
            //    }
            //}
            //else
            //{
            //    j = 80;
            //}

            //Console.WriteLine($"X = {x}");
            //Console.WriteLine($"J = {j}");
            //Console.ReadLine();

            //else
            //{
            //    int j = 10;
            //    // int w = 0; Não pode ser declarado novamente aqui, pois já foi declarado no escopo anterior.
            //    w = 10; // Desta maneira pode, pois eu estou apenas alterando o valor de uma variavel que ja existe no escopo superior.
            //}

            //x = x + j; // J esta somente no escopo do if.
            #endregion

            #region "Teste de mesa 2"
            //int i = 0, j = 0, x = 1; 

            //for (i = 0; i < 2;) 
            //{
            //    for (j = 2; j > -1; j--) 
            //    {
            //        x += i + j; //4, 5
            //    }
            //    i++;
            //    do
            //    {
            //        x += j;
            //        j++;
            //    } while (j < 2);
            //}
            //while (x < 20)
            //{
            //    x += 2;
            //    if (x % 2 == 0)
            //    {
            //        x--;
            //    }
            //}
            #endregion

            #region "Teste de mesa 3"

            //const int LIMITE = 7;

            //int a = 0, b = 0, c;
            //a = b + 1;
            //b = a;
            //c = b * 3 + 2;

            //for (; ; )
            //{
            //    b = 0;
            //    a++;
            //    if (a % 5 == 0)
            //    {
            //        break; //Interromper a estrutura de repetição -> FOR
            //    }
            //    b = c - 1;
            //}
            //do
            //{
            //    c++;
            //    a = c - b;
            //} while (c < LIMITE);

            //a = 1;

            //while (true)

            //{
            //    a++;
            //    if (a < LIMITE)
            //    {
            //        break; // Interromper a estrutura de repetição -> WHILE
            //    }
            //}

            #endregion

            #region "Teste de mesa 4 - Utilização continue"

            int y = 10;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == 1)
                        continue; // Vai para a proxima iteração.

                    y += 3;
                }
            }

            // continue, break, return são operadores de controle de fluxo.

            #endregion

            #region "Teste de mesa 5 - Pré e pós incremento"

            int a = 1;
            int b = 2;
            int c = 0;

            //a++; // a = a + 1
            //++a; // a = a + 1
            //++b; // b = b + 1
            //b++; // b = b + 1

            //a = b++ * 3; // Vai fazer o incremento, depois da operação.
            //a = b * 3;
            //b = b + 1;

            //a = ++b * 3;// Vai fazer o incremento, antes da operação.
            //b = b + 1;
            //a = b * 3;

            a = b++ / 3 * 3;
            // a = b = b / (3*3)
            // a = b = b / 9
            // a = b = b / 9

            #endregion

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

        }
    }
}
