using System;

// Enum é uma constante encapsulada. 

namespace EnumEstudo
{
    internal class Program
    {
        enum statusPedido {emAtendimento = 1, fazendo, emEntrega, finalizado};

        static void Main(string[] args)
        {
            Random numeroAleatorio = new Random();

            int pedido = numeroAleatorio.Next(1,4);

            Console.WriteLine($"O status do pedido é: {Enum.GetName(typeof(statusPedido), pedido)}"); // Acessando nome do enum

            Console.Write($"Os valores do Enum são: ");

            foreach (var item in Enum.GetValues(typeof(statusPedido))) // Acessando todos os nomes do enum
                Console.Write($"{item} ");

            Filme filmeParaFamilia = new Filme();
            filmeParaFamilia.Nome = "Sharknado";
            filmeParaFamilia.Genero = Genero.Comedia; // Utilizando enum em uma classe

            Console.WriteLine($"\n\nO filme <{filmeParaFamilia.Nome}> tem como genero <{filmeParaFamilia.Genero}>, e o id do gênero é <{(int)filmeParaFamilia.Genero}>.\n");
            Console.WriteLine();

            Filme filmeCelula = new Filme();
            filmeCelula.Nome = "Até o último homem"; // Utilizando enum em uma classe
            filmeCelula.Genero = Genero.Acao;

            Console.WriteLine();
            Console.WriteLine($"O filme <{filmeCelula.Nome}> tem como genero <{filmeCelula.Genero}>, e o id do gênero é <{(int)filmeCelula.Genero}>.");
            Console.WriteLine();


            Console.ReadLine();


        }
    }
}
