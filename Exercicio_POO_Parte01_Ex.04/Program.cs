using System;

namespace Exercicio_POO_Parte01_Ex._04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var opcoes = "";
            Aluno aluno = null;

            Console.WriteLine("Digite o nome do aluno:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite a matrícula do aluno:");
            int matricula = int.Parse(Console.ReadLine());


            while (true)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Português");
                Console.WriteLine("2. Matemática");
                Console.WriteLine("3. História");
                Console.WriteLine("4. Geografia");
                Console.WriteLine("5. Língua Estrangeira");
                Console.WriteLine("7. Sair");

                opcoes = Console.ReadLine();

                switch (opcoes)
                {
                    case "1":
                        var materia = "Português";
                        aluno = processarAluno(nome, matricula, materia);
                        break;

                    case "2":
                        materia = "Matemática";
                        aluno = processarAluno(nome, matricula, materia);
                        break;

                    case "3":
                        materia = "História";
                        aluno = processarAluno(nome, matricula, materia);
                        break;

                    case "4":
                        materia = "Geografia";
                        aluno = processarAluno(nome, matricula, materia);
                        break;

                    case "5":
                        materia = "Lingua estrangeira";
                        aluno = processarAluno(nome, matricula, materia);
                        break;

                    case "7":
                        Console.WriteLine("Saindo do programa.");
                        return;

                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }
                Console.WriteLine("Deseja fazer uma nova operação? (s/n):");
                string novaConsulta = Console.ReadLine();
                if (novaConsulta.ToLower() != "s")
                {
                    break;
                }
                Console.Clear();
            }
        }

        private static Aluno processarAluno(string nome, int matricula, string materia)
        {
            Aluno aluno;
            Console.WriteLine($"Digite as três notas de {materia}:");
            Console.WriteLine("Nota 01:");
            double nota01 = double.Parse(Console.ReadLine());
            Console.WriteLine("Nota 02:");
            double nota02 = double.Parse(Console.ReadLine());
            Console.WriteLine("Nota 03:");
            double nota03 = double.Parse(Console.ReadLine());
            aluno = new Aluno(nome, matricula);
            aluno.AdicionarNotas(nota01, nota02, nota03);
            double media = aluno.CalcularMedia();
            Console.WriteLine("A média do aluno é: " + media.ToString("0.##"));
            Console.WriteLine(aluno.VerSituacao());
            return aluno;
        }
    }
}