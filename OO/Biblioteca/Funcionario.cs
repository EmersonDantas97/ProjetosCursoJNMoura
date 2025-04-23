using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Funcionario : Usuario
    {
        public Funcionario()
        {
        }

        public void CadastrarNovoLivro(Livro livro)
        {
            Biblioteca.CadastraNoSistema(livro);
        }
    }
}
