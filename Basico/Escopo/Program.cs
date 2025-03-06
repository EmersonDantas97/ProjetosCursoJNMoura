using System;

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

            int i = 0, j = 0, x = 1; 

            for (i = 0; i < 2;) 
            {
                for (j = 2; j > -1; j--) 
                {
                    x += i + j; //4, 5
                }
                i++;
                do
                {
                    x += j;
                    j++;
                } while (j < 2);
            }
            while (x < 20)
            {
                x += 2;
                if (x % 2 == 0)
                {
                    x--;
                }
            }

            Console.WriteLine(x);
            Console.WriteLine(j);
            Console.WriteLine(i);
            #endregion
        }
    }
}
