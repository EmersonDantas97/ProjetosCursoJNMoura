using System;

namespace Porta
{
    internal class Program
    {
        static void Main(string[] args) // Classe só trabalha no objeto, não colocar impressão.
        {
            Console.WriteLine("\n--------- CATRACA");

            Porta porta01 = new Porta();
            Porta porta02 = new Porta(true, CorDaPorta.Nenhuma, 1.00, 2.00, 0.05);

            porta01.pintarAmarelo();
            porta01.pintarVerde();

            string portaAberta1 = porta01.estaAberta() ? "Sim" : "Não";
            string portaAberta2 = porta02.estaAberta() ? "Sim" : "Não";

            Console.WriteLine();

            Console.WriteLine($"\tA porta 01 está aberta? {portaAberta1}");
            Console.WriteLine($"\tA cor da porta 01 é? {porta01.getCor()}");

            Console.WriteLine();

            Console.WriteLine($"\tA porta 02 está aberta? {portaAberta2}");
            Console.WriteLine($"\tA cor da porta 02 é? {porta02.getCor()}");

            Console.Write("\nPressione ENTER para fechar o programa!");
            Console.ReadLine();
        }
    }
}
