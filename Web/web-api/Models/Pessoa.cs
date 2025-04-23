using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models
{
    public class Pessoa
    {
        //private static int contador = 0;

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Pessoa(string nome, int idade)
        {
            //Id = ++contador;
            Nome = nome;
            Idade = idade;
        }

        public Pessoa() { }
    }
}