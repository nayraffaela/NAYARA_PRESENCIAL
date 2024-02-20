using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte01_Ex._10_Parte02_Ex._07
{
    internal class Livro
    {
        private static int contadorId = 1;


        private int _id;
        private string _titulo;
        private string _autor;
        private int _numeroPg;

        //dados de emprestimo
        private DateTime _dataExpiracao = DateTime.MinValue;
        private string _nomeDoAluno = "";
        private bool _disponivel = true;

        public Livro(string titulo, string autor, int numeroPg)
        {
            _id = contadorId++;
            _titulo = titulo;
            _autor = autor;
            _numeroPg = numeroPg;
        }
        public int VerId()
        {
            return _id;
        }
        public string VerTitulo()
        {
            return _titulo;
        }

        public string VerAutor()
        {
            return _autor;
        }

        public bool EstaDisponivel()
        {
            return _disponivel;
        }

        public void Emprestar(DateTime dataEmprestimo, string nomeDoAluno)
        {
            var dataDevolucao = dataEmprestimo.AddDays(7);

            _dataExpiracao = dataDevolucao;
            _disponivel = false;
            _nomeDoAluno = nomeDoAluno;
        }

        public void Devolver()
        {
            _disponivel = true;
            _nomeDoAluno = "";
            _dataExpiracao = DateTime.MinValue;
        }
    }
}
