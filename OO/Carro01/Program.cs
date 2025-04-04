using System;
using System.Collections.Generic;

namespace Carro01
{
    internal class Program
    {

        #region Solução ficou obsoleta diante do conceito de getters e setters.
        // tem que ser fora do main. Não é uma instrução e sim uma estrutura de dados.
        // struct Carro
        //class Carro
        //{
        //    public double cilindradas; // Quando não coloco o modificador de acesso, por padrão ele é privado.
        //    public int numeroPortas; // São atributos e não propriedades.
        //    public string cor;
        //    public string nome;
        //    public int velocidade;
        //    public double valor;

        //    public void acelerar() // Void retorna com "ok". Tem gente que fala que não retorna nada é um equívoco.
        //    {
        //        velocidade++;
        //        return;
        //    }
        //}
        // Classe compõe a estrutura de um objeto. Classe não é objeto e objeto não é classe. O objeto é criado a partir da classe. Objeto é uma instância de memória.
        #endregion

        class Carro
        {
            public double Cilindradas { get; set; }
            public int NumeroPortas { get; set; }
            public string Cor { get; set; }
            public string Nome { get; set; }
            public int Velocidade { get; set; }
            public double Valor { get; set; }

            public void Acelerar()
            {
                Velocidade++;
            }
        }

        static void Main(string[] args)
        {

            #region "Solução 01"
            /*
            List<double> cilindradas = new List<double>();
            List<int> numeroPortas = new List<int>();
            List<string> cores = new List<string>();
            List<string> nomes = new List<string>();
            List<int> velocidades = new List<int>();

            // Carro 01
            cilindradas.Add(1000);
            numeroPortas.Add(4);
            cores.Add("Branca");
            nomes.Add("Gol");
            velocidades.Add(0);

            // Carro 02
            cilindradas.Add(1000);
            numeroPortas.Add(2);
            cores.Add("Prata");
            nomes.Add("Ka");
            velocidades.Add(60);

            // Carro 03
            cilindradas.Add(2000);
            numeroPortas.Add(4);
            cores.Add("Preto");
            nomes.Add("Corolla");
            velocidades.Add(200);
            */
            #endregion

            #region "Solução 02 - Criando objetos"
            Carro carro01 = new Carro(); // Quando class, pbrigado utilizar o "new".
            carro01.Cilindradas = 1000;
            carro01.Cor = "Branca";
            carro01.Nome = "Gol";
            carro01.Velocidade = 100;
            carro01.NumeroPortas = 4;

            Carro carro02 = new Carro();
            carro02.Cilindradas = 1000;
            carro02.Cor = "Branca";
            carro02.Nome = "Gol";
            carro02.Velocidade = 100;
            carro02.NumeroPortas = 4;

            List<Carro> carros = new List<Carro>();
            carros.Add(carro01);
            carros.Add(carro02);

            carro01.Cilindradas += 1;
            carros[0].Cilindradas = 8000;

            Console.WriteLine(carros[1].Cilindradas);

            carro01.Velocidade = 0;
            
            carro01.Acelerar();
            carro01.Acelerar();

            carro02.Acelerar();

            // Struct, quando colocado em uma lista ele copia os valores. Logo, se eu alterar o objeto carro01, não vai alterar o objeto 1 da lista de carros
            // Class, quando colocado em uma lista ele cria um apontamento. Logo, se eu alterar o objeto carro01, VAI alterar o objeto 1 da lista de carros
            // O principal objetivo da orientação ao objeto é a utilização de memória, utilizando o mesmo endereço.

            #endregion

        }
    }
}
