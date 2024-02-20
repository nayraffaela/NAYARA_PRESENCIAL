using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte01_Ex._04
{
    internal class Aluno
    {
        public string Nome {  get; set; }
        public int Matricula {  get; set; }
        public List<double> Notas { get; set; } = new List<double>(); 
         
        public Aluno(string nome, int matricula)
        {
           Nome = nome;
           Matricula = matricula;

        }
        public void AdicionarNotas(double nota01, double nota02, double nota03)
        {
            Notas.Add(nota01);
            Notas.Add(nota02);
            Notas.Add(nota03);
        }

        public string VerSituacao()
        {
            var media = CalcularMedia();
            var situcaoAluno = "";

           
            if ( media >= 7.0)
            {
                situcaoAluno = "Aluno aprovado.";
            }
            else if (media >= 5.0)
            {
                situcaoAluno = "Aluno em recuperação.";
            }
            else
            {
                situcaoAluno = "Aluno reprovado";
            }
            return situcaoAluno;
        }
        public double CalcularMedia()
        {
            double nota01 = Notas[0];
            double nota02 = Notas[1];
            double nota03 = Notas[2];

           return (nota01 + nota02 + nota03) / 3.0;
        }
    }
}
    

