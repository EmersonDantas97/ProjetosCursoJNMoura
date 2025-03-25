using System;
using System.Collections.Generic;

namespace dicionario
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Lista de Estudantes - Usando "Dictionary"

            //Dictionary<char, string> estudantes = new Dictionary<char, string>();
            var estudantes = new Dictionary<char, string>(); // Fazendo a mesma coisa de outra maneira.

            // No dicionário, o índice é associado com a chave. Retornar true ou false. 

            estudantes.Add('A', "Jeferson"); // Chave: 'A', Valor: 'Jeferson'
            estudantes.Add('B', "João");
            estudantes.Add('C', "Maria");
            estudantes.Add('D', "Pedro");

            Console.WriteLine($"{estudantes['A']}"); // Retornará o valor "Jeferson"

            estudantes.Remove('Y'); // Caso não consiga achar o valor, vai retornar false.

            foreach (var item in estudantes)
                Console.WriteLine(item);

            // Conforme visto acima, para eu acessar os valores, basta utilizar a chave.

            #endregion

            #region Lista de Estudantes - Usando "List"

            List<string> listaEstudantes = new List<string>();

            listaEstudantes.Add("Jeferson"); // índice: 0, Valor: 'Jeferson'
            listaEstudantes.Add("João");
            listaEstudantes.Add("Maria");
            listaEstudantes.Add("Pedro");

            foreach (var alunoNaLista in listaEstudantes)
                if (alunoNaLista == "Jeferson")
                    Console.WriteLine($"{alunoNaLista}");

            //listaEstudantes.Remove("Pedro"); // Caso não consiga achar o valor, vai dar erro.
            //listaEstudantes.RemoveAt(3); // Vai remover pelo índice.

            // Conforme visto acima, para fazer a mesma coisa do dictionary, seria necessário eu fazer "foreach" e também um "if". Utilizando mais processamento do PC.
            
            #endregion

            int x = 10;
            var y = 20; // "var" Faz a conversão em momento de compilação.

            y = 40;

            y = 'a';

            char w = 'a';

            //y = "Maça";
        }
    }
}
