using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Definir 6 atributos para essa pessoa
    1 método que afeta um dos atributos
    Criar 3 objetos pessoas e manipular os atributos e invocar o método
    para cada objeto
*/

namespace Pessoa
{
    internal class Program
    {
        class Pessoa
        {
            public string nome;
            public int idade;
            public string endereco;
            public string cidadeQueMora;
            public string celular;
            public double altura;
            public DateTime dataNascimento;

            public void fazerAniversario()
            {
                idade++;
                return;
            }
        }

        static void Main(string[] args)
        {
            Pessoa pessoa1 = new Pessoa();
            pessoa1.altura = 1.60;
            pessoa1.celular = "14988054131";
            pessoa1.nome = "Emerson";
            pessoa1.endereco = "Rua";
            pessoa1.cidadeQueMora = "Ipaussu";
            pessoa1.idade = 28;
            pessoa1.fazerAniversario();

            Pessoa pessoa2 = new Pessoa();
            pessoa2.altura = 1.64;
            pessoa2.celular = "14988050000";
            pessoa2.nome = "Bruna";
            pessoa2.endereco = "Avenida";
            pessoa2.cidadeQueMora = "Sta Cruz";
            pessoa2.idade = 27;
            pessoa2.fazerAniversario();

            Pessoa pessoa3 = new Pessoa();
            pessoa3.altura = 1.79;
            pessoa3.celular = "14911111111";
            pessoa3.nome = "Matheus";
            pessoa3.endereco = "Travessa";
            pessoa3.cidadeQueMora = "Bauru";
            pessoa3.idade = 17;
            pessoa3.fazerAniversario();


        }
    }
}
