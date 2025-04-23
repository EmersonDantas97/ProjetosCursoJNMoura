using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Pessoa maria = new Aluno("Maria", "Joaquina");

            Funcionario joao = new Funcionario("Joao", "Silva", 1500);
            Console.WriteLine("Valor Xerox para funcionário: {0}", joao.valorCopiasXerox(10));

            Aluno zeca = new Aluno("Zeca", "Beats", "RA3210");
            Console.WriteLine("Valor Xerox para aluno: {0}", zeca.valorCopiasXerox(10));

            Console.ReadLine();
        }
    }
}
