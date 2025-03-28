using System;
using System.Collections.Generic;

namespace Dicionario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, char> x = new Dictionary<char, char>();

            x.Add('A', '@');
            x.Add('a', '@');
            x.Add('E', '3');
            x.Add('e', '3');
            x.Add('I', '1');
            x.Add('i', '1');
            x.Add('O', '0');
            x.Add('o', '0');
            x.Add('U', '%');
            x.Add('u', '%');

            Console.Write("Digite a frase: ");
            string y = Console.ReadLine();

            string z = y;

            foreach (KeyValuePair<char, char> item in x)
            {
                z = z.Replace(item.Key, item.Value);
            }

            Console.WriteLine("Resultado: {0}", z);

            Console.ReadLine();
        }
    }
}
