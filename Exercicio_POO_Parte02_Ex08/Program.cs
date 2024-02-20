using Exercicio_POO_Parte02_Ex08;

namespace Exercicio_POO_Parte02_Ex08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ano = 2024;
            Calendario calendario = new Calendario(ano);

            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("Digite a opção de deseja consultar:");
                Console.WriteLine("1. Consultar mês");
                Console.WriteLine("2. Consultar calendário anual de 2024");
                Console.WriteLine("3. Consultar feriados nacionais");
                Console.WriteLine("4. Consultar diferença numérica entre dias");
                Console.WriteLine("5. Sair");
                Console.WriteLine();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ConsultarMes(calendario);
                        Console.WriteLine();
                        break;
                    case "2":
                        calendario.MostrarCalendarioAnual();
                        Console.WriteLine();
                        break;

                    case "3":
                        calendario.ExibirFeriados();
                        Console.WriteLine();
                        break;
                    case "4":
                        ConsultarDiferenca(calendario);
                        Console.WriteLine();
                        break;
                    case "5":
                        sair = true;
                        Console.WriteLine("Saindo do programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }
            }
        }

        static void ConsultarMes(Calendario calendario)
        {
            Console.WriteLine("Digite o número do mês que deseja consultar (1 a 12): ");
            int mes = int.Parse(Console.ReadLine());

            if (mes >= 1 && mes <= 12)
            {
                calendario.MostrarCalendarioMensal(mes);
            }
            else
            {
                Console.WriteLine("Mês inválido. Por favor, escolha um número de mês válido (1 a 12).");
            }
        }

        static void ConsultarDiferenca(Calendario calendario)
        {
            Console.WriteLine("Digite a primeira data no formato (dd/mm/aaaa): ");
            DateTime data1 = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite a segunda data no formato (dd/mm/aaaa): ");
            DateTime data2 = DateTime.Parse(Console.ReadLine());

            calendario.CalcularDiferençaDatas(data1, data2);
        }
    }
}
