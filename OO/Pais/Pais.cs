using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Um país tem como atributos o seu nome, o nome da sua capital, sua dimensão em Km2. 
    Implemente (codifique) uma classe que represente um país conforme os itens abaixo:
        Construtor vazio;
        Construtor que inicialize o nome, capital e a dimensão do país;
        Um método que permita verificar se dois países são iguais. 
            Dois países são iguais se eles tiverem o mesmo nome e a mesma capital.
            A assinatura deste método deve ser: public bool Igual(Pais pais)

    Cite um encapsulamento utilizado no exercício.
    Qual conceito de OO foi utilizado na implementação dos construtores? Explique-o.
    Você utilizou o a palavra reservada “this” na classe que representa o país? Por que? 
*/

namespace Pais
{
    internal class Pais
    {
        private string nome;
        private string nomeCapital;
        private double dimensaoEmKm2;

        public Pais()
        {
        }

        public Pais(string nome, string nomeCapital, double dimensaoEmKm2)
        {
            this.nome = nome;
            this.nomeCapital = nomeCapital;
            this.dimensaoEmKm2 = dimensaoEmKm2;
        }

        public bool Igual(Pais pais)
        {
            if (pais.nome == this.nome && pais.nomeCapital == this.nomeCapital)
                return true;

            return false;
        }
    }
}
