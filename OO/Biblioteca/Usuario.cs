using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Usuario
    {
        public string Nome;
        public string Email;
        List<Livro> livrosEmprestados;

        public Usuario()
        {
            livrosEmprestados = new List<Livro>();
        }

        public void EmprestarLivro(Livro livro)
        {
            livrosEmprestados.Add(livro);
        }

        public bool DevolverLivro(string nomeLivro)
        {
            foreach (Livro livro in livrosEmprestados)
            {
                if (livro.titulo == nomeLivro)
                {
                    livrosEmprestados.Remove(livro);
                    return true;
                }
            }
            return false;
        }
    }
}
