namespace Exercicio_POO_Parte01_Ex._09_Parte02_Ex._01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var opcao = "1";

            Console.WriteLine("Informe o nome completo do paciente:");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe a idade do paciente:");
            int idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe a profissão do paciente:");
            string profissão = Console.ReadLine();

            Paciente paciente = new Paciente(nome, idade, new List<string>());
            Pessoa pessoa = new Pessoa(nome, idade, profissão);

            while (true)
            {
                Console.WriteLine("Qual operação deseja consultar?");
                Console.WriteLine("1.Informações pessoais.");
                Console.WriteLine("2.Informações de histórico.");
                Console.WriteLine("3.Adicionar novo histórico.");
                Console.WriteLine("4.Consultar idade em ano bissexto.");
                opcao = Console.ReadLine();


                switch (opcao)
                {
                    case "1":
                        Console.WriteLine($"Informações do paciente:\n{pessoa.VerInfo()}\nIdade:{idade}.");
                        break;

                    case "2":
                        Console.WriteLine($"Histórico de consulta do paciente:\n{paciente.VerHistorico()}");
                        break;

                    case "3":
                        CriarConsultas(paciente);
                        break;

                    case "4":
                        Console.WriteLine($"A idade do paciente em ano bissexto será:\n{pessoa.CalcularIdade()}");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
                Console.WriteLine("Deseja realizar uma nova consulta? (s/n):");
                string novaConsulta = Console.ReadLine();
                if (novaConsulta.ToLower() != "s")
                {
                    break;
                }
                Console.Clear();
            }
        }

        private static void CriarConsultas(Paciente paciente)
        {
            Console.WriteLine("Adicione as informações da consulta abaixo:");
            string consulta = Console.ReadLine();
            paciente.AdicionarConsulta(consulta);
            Console.WriteLine("Consulta adicionada com sucesso!");
        }
    }
}

