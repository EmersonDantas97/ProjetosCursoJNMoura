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

// Readonly => Permitir a alteração de um atributo somente leitura no método construtor. 

namespace Pais
{
    internal class Pais
    {
        // Propriedade pode encapsular no máximo 2 métodos.
        public string Nome { get; set; }
        public string Capital { get; set; }
        public double DimensaoEmKm2 { get; set; }
        
        public Pais()
        {
        }

        public Pais(string nome, string nomeCapital, double dimensaoEmKm2)
        {
            Nome = nome;
            Capital = nomeCapital;
            DimensaoEmKm2 = dimensaoEmKm2;
        }

        public bool Igual(Pais pais)
        {
                return pais.Nome == this.Nome && pais.Capital == this.Capital; // Está encapsulado as comparações de igualdade.
        }



        //public string Nome
        //{
        //    set
        //    {
        //        this.nome = value;
        //    }
        //    get
        //    {
        //        return this.nome;
        //    }
        //}

        //public string NomeCapital
        //{
        //    set
        //    {
        //        this.nomeCapital = value;
        //    }
        //    get
        //    {
        //        return this.nomeCapital;
        //    }
        //}

        //public double DimensaoEmKm2
        //{
        //    set
        //    {
        //        this.dimensaoEmKm2 = value;
        //    }
        //    get
        //    {
        //        return this.dimensaoEmKm2;
        //    }
        //}

        // Método Equals compara endereços.

        // Comparando o endereco.
        /*
        public bool Igual(Pais pais)
        {
            return this == pais;
        }
        */
    }
}
