using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Canis animal1 = new Canis();

            Console.WriteLine(animal1.getDescricao());
            
            Diptera animal2 = new Diptera();
            Console.WriteLine(animal2.getDescricao());

            Console.ReadLine();
        }
    }
}
