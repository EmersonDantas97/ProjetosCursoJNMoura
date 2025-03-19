using System;
using System.Collections;

/*
Array
    Tipo de dados definido.
    Não pode ser alterado. 
    Alocação estática de memória - Número de blocos não pode ser alterado.
    
ArrayList
    Tipo de dados definido e não pode ser alterado. Object = Aceita qualquer tipo de dados. ]
    Alocação "dinâmica" de memória. Realocado assim que atinge a capacidade de blocos (Dobra o tamanho quando atinge o capacity).
    O número inicial de blocos alocados em memória pode ser definido na criação ou não (caso não, aloca 4 blocos automaticamente e depois vai dobrando.)
    - PROBLEMAS:
        A própria Microsoft indica não usar.
        Segurança. Você pode alocar objetos nas posições, você pode não conseguir saber o que tem em cada posição. Ex: Invés de vir um inteiro vem uma string ou double.
        Problema principal é de Performance. Boxing e Unboxing. Unboxing traz uma perda de memória, pois faz conversão implicita. Boxing = Converter uma variável do tipo primitivo (tipo conhecido) para o tipo object (tipo desconhecido).
    Não usar ArrayList nas novas implementações. 
 */

namespace Array_List
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n--------- ARRAYLIST PROFESSOR\n");

            ArrayList itens1 = new ArrayList();
            //itens1[0] = 50; // Não dá certo, por que não alocou bloco na memória.

            // Capacity pode ate suportar a quantidade de elementos, mas o que importa é a quantidade de indices.

            itens1.Add(111);
            itens1.Add("Maria");
            itens1.Add("João");
            itens1.Add('c');
            itens1.Add("E");
            itens1.Add(true);
            itens1.Add(5.9);
            itens1.Add(10.63);
            itens1.Add(1.20);
            itens1.Add(10.56);

            //int x = itens1[0]; // Não aceita este código, pois está tentando inserir um objeto em uma variavel tipo int. Não faz a conversão implicita.

            int x = (int)itens1[0]; // Estou fazendo a conversão explicita.

            // Exibindo os valores inseridos.
            for (int i = 0; i < itens1.Count; i++)
                Console.WriteLine($"O valor <{itens1[i]}> tem o tipo <{itens1[i].GetType()}>");
    
            /*
            Recebe qualquer tipo de dados.
            Não defini a quantidade de posições.
            */

            int[] itens2 = new int[5];
            itens2[0] = 50; // Já alocou em memória 5 blocos, ao executar esta linha, vai colocar o 50 no bloco 0.
            /*
            Alocação estática.
            Somente numeros inteiros.
            5 Posições.
             */

            Console.Write("\nPressione ENTER retornar para finalizar o programa!");
            Console.ReadLine();
        }
    }
}
