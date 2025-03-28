using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Um país tem como atributos o seu nome, o nome da sua capital, sua dimensão em
    Km2. Implemente (codifique) uma classe que represente um país conforme os itens abaixo:
        Construtor vazio;
        Construtor que inicialize o nome, capital e a dimensão do país;
        Um método que permita verificar se dois países são iguais. Dois países são iguais se eles tiverem o mesmo nome e a mesma capital.
            A assinatura deste método deve ser: public bool Igual(Pais pais)

    1) Cite um encapsulamento utilizado no exercício.
    2) Qual conceito de OO foi utilizado na implementação dos construtores? Explique-o.
    3) Você utilizou o a palavra reservada “this” na classe que representa o país? Por que? 


1R: Os atributos do objeto nome, nomeCapital e dimensaoEmKm2 foram deixados encapsulados dentro da classe, para não ter acesso externo e só ser realizado o acesso/manipulação via prórpia classe.
2R: Conceito de sobrecarga. Ocorre quando tenho mais que 1 construtor com assinaturas (nome + parâmetros) diferentes.
3R: Sim. Foi utilizada, com o objetivo de se referir às caracteríticas da classe, para não ser misturado com os parâmetros do construtor, uma vez que ambos tem os mesmos nomes.


*/

namespace Pais
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nomePais;
            string capitalPais;
            double dimensaoEmKm2;
            string paisesIguais;

            Console.WriteLine("\n--------- COMPARAÇÃO ENTRE PAISES");

            Console.WriteLine("\nPAIS 1");
            Console.Write("\n\tInforme o nome do PAIS: ");
            nomePais = Console.ReadLine();
            Console.Write("\tInforme o nome da CAPITAL: ");
            capitalPais = Console.ReadLine();
            Console.Write("\tInforme a sua DIMENSÃO em Km2: ");
            dimensaoEmKm2 = double.Parse(Console.ReadLine());
            Pais pais01 = new Pais(nomePais, capitalPais, dimensaoEmKm2);

            Console.WriteLine("\nPAIS 2");
            Console.Write("\n\tInforme o nome do PAIS: ");
            nomePais = Console.ReadLine();
            Console.Write("\tInforme o nome da CAPITAL: ");
            capitalPais = Console.ReadLine();
            Console.Write("\tInforme a sua DIMENSÃO em Km2: ");
            dimensaoEmKm2 = double.Parse(Console.ReadLine());

            Pais pais02 = new Pais(nomePais, capitalPais, dimensaoEmKm2);

            paisesIguais = pais01.Igual(pais02) ? "SIM" : "NÃO";

            Console.WriteLine("\n→ COMPARAÇÃO");

            Console.WriteLine($"\n\tOs paises são iguais: {paisesIguais}");

            Console.Write("\nPressione ENTER para fechar o programa!");
            Console.Beep();
            Console.ReadLine();

        }
    }
}
