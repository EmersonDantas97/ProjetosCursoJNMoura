using System; // FrameWork.
/*using System.Collections.Generic; // Colecoes
//using System.Linq; // Linguagem linq.
using System.Text; // Funcoes para textos
using System.Threading.Tasks; // Biblioteca de processamento paralelo ou assincrono.*/

// Tipagem estática ou dinamica

namespace AntecessorSucessor
{
    internal class Program // Internal pq é visto so neste projeto.
    {
        static void Main(string[] args) // Main não pode mudar, pois ele vai procurar esse. É a função principal.
        {
            
            Console.Write("Digite o seu numero: ");

            int numero = numero = int.Parse(Console.ReadLine()); // Inclui na memoria, armazenando 4 bytes. Valor incial é de 0, é colcado para sobrescrever, porem ele pede para colocar um valor.
            int sucessor = numero + 1; // Não houve realocacao, so sobrescreveu a memoria.
            int antecessor = numero - 1;

            // Colocar como nome da variavel, sempre o que ela faz, nao depender de comentarios.
            // System.Console.WriteLine(numero); // Outra maneira de chamar. Caso não queira declarar o System lá em cima.
            
            Console.WriteLine("Antecessor: " + numero.ToString()); // O que colocamos dentro dos parenteses, tem o nome de parametro.
            Console.WriteLine($"Sucessor: {sucessor}\nAntecessor: {antecessor}"); // Realizando interpolacao. O ideal é colocar separado, não utilizar \n
            Console.WriteLine("Antecessor: {0}, Sucessor: {1}.", antecessor, sucessor);
            Console.Beep(); // C# Faz a diferenciacao de letras minusculas e maiusculas.

            // Ex: WriteLine Cada palavra e maiuscula, isso e convencao da Microsoft.
            Console.ReadLine(); //Quebra de linha nao ocupa espaco, depois que compila o programa tira os espacos e os comentarios.
        }
    }
}
