using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte01_Ex._10_Parte02_Ex._07
{
    internal class Biblioteca
    {
        private List<Livro> livros = new List<Livro>();

        public void CadastrarLivros(Livro novoLivro)
        {
            livros.Add(novoLivro);
        }

        public bool EmprestarLivro(string autor, string titulo, string nomeDoAluno, DateTime dataEmprestimo)
        {
            var livro = livros.FirstOrDefault(l => l.VerAutor().Equals(autor) && l.VerTitulo().Equals(titulo));

            if (livro == null || !livro.EstaDisponivel()) return false;

            livro.Emprestar(dataEmprestimo, nomeDoAluno);

            return true;
        }

        public bool DevolverLivro(string autor, string titulo)
        {
            var livro = livros.FirstOrDefault(l => l.VerAutor().Equals(autor) && l.VerTitulo().Equals(titulo));

            if (livro == null) return false;

            livro.Devolver();

            return true;
        }

        public Livro ConsultarLivro(int idLivro)
        {
            var livro = livros.FirstOrDefault(l =>l.VerId() == idLivro);
            return livro;
        }

        public Livro ConsultarLivro(string autor, string titulo)
        {
            var livro = livros.FirstOrDefault(l => l.VerAutor().Equals(autor) && l.VerTitulo().Equals(titulo));
            return livro;
        }
    }
}

