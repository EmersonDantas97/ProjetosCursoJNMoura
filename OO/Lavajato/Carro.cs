using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavajato
{
    internal class Carro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }

        public Carro()
        {
        }

        public Carro(int id, string nome, int ano)
        {
            this.Id = id;
            this.Nome = nome;
            this.Ano = ano;
        }

    }
}
