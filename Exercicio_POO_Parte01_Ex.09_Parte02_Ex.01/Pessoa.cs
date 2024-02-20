using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte01_Ex._09_Parte02_Ex._01
{
    internal class Pessoa
    {
        private string _nome;
        private int _idade;
        private string _profissão;

        public Pessoa(string nome, int idade, string profissão)
        {
            _nome = nome;
            _idade = idade;
            _profissão = profissão;
        }

        public int CalcularIdade()
        {
            DateTime dataDeNascimento = DateTime.Now.AddYears(-_idade);
            DateTime dataAtual = DateTime.Now;

            int idade = dataAtual.Year - dataDeNascimento.Year;
            if (dataDeNascimento.Date > dataAtual.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }
        public string VerInfo()
        {
            return $"Nome: {_nome}\nProfissão:{_profissão}";
        }
    }
}
    