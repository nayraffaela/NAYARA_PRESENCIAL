using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte01_Ex._09_Parte02_Ex._01
{
    internal class Paciente
    {
        private string _nome;
        private int _idade;
        private List<string> _historicoConsultas;

        public Paciente(string nome, int idade, List<string> historicoConsultas)
        {
            _nome = nome;
            _idade = idade;
            _historicoConsultas = historicoConsultas;
        }
        public void AdicionarConsulta(string consulta)
        {
            _historicoConsultas.Add(consulta);
        }

        public string VerHistorico()
        {
            return string.Join("\n", _historicoConsultas);
        }
    }
}
  