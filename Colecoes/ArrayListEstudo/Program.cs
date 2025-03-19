using System;
using System.Collections;

namespace ArrayListEstudo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n--------- ARRAYLISTESTUDO\n");

            // Criando a arraylist
            ArrayList listaDiversa = new ArrayList();

            // Adicionando elementos
            listaDiversa.Add(10);
            listaDiversa.Add("10");
            listaDiversa.Add("Texto_Nome");
            listaDiversa.Add(3.14);

            //Percorrendo o arraylist - OPÇÃO 1
            Console.WriteLine("\nOs valores inseridos são: ");
            foreach (var item in listaDiversa)
            {
                Console.WriteLine($"\tFoi inserido o valor: {item}");
            }

            // Removendo um elemento da arraylist
            listaDiversa.Remove(10);

            //Percorrendo o arraylist - OPÇÃO 2

            Console.WriteLine("\nOs tipos inseridos são: ");
            for (int i = 0; i < listaDiversa.Count; i++)
            {
                Console.WriteLine($"\tO valor {listaDiversa[i]} é {listaDiversa[i].GetType()}");
            }

            // Verificando o tamanho da arraylist
            Console.WriteLine($"\nO tamanho da arraylist é: {listaDiversa.Count}");

            Console.Write("\nPressione ENTER retornar para tela anterior!");
            Console.ReadLine();

        }
    }
}
