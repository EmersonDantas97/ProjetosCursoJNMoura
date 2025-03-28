using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoa
{
    internal class Pessoa // Pode ser internal ou public
    {
        public string nome;
        private int idade; // Encapsulamento. Não deixei a propriedade acessível, para obrigar a esta propriedade só ser alterada via método construtor ou o proprio método que altera ela.
        public string endereco;
        public string cidadeQueMora;
        public string celular;
        public double altura;

        public void fazerAniversario()
        {
            idade++;
            return;
        }

        #region Fazendo sobrecarga de métodos construtores
        /*
            Sobrecarga = Métodos com o mesmo nome, na mesma classe, e com assinaturas diferentes.
            Assunatura = Nome do método + parâmetros.
         */

        // Abaixo, tem 2 métodos com o mesmo nome. Isso significa que ele está sobrecarregado. Nome com o mesmo parâmetro, mas com assinaturas diferentes.
        public Pessoa() // Método construtor de objeto
        {
            idade = 0;
            nome = "";
        }

        public Pessoa(int idade) // Nome + parâmetro = assinatura.
        {
            this.idade = idade;
            nome = "";
        }

        public Pessoa(string nome)
        {
            idade = 0;
            this.nome = nome;
        }

        public Pessoa(string nome, int idade)
        {
            this.nome = nome;
            this.idade = idade;
        }

        public Pessoa(int idade, string nome)
        {
            this.nome = nome;
            this.idade = idade;
        }
        #endregion

    }
}
