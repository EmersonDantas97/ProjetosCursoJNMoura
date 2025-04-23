using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Biblioteca
    {
        public static List<Livro> ListaDeLivrosCadastrados;

        public Biblioteca()
        {
            ListaDeLivrosCadastrados = new List<Livro>();
        }

        public static bool CadastraNoSistema(Livro livro)
        {
            ListaDeLivrosCadastrados.Add(livro);
            return true;
        }
    }
}
