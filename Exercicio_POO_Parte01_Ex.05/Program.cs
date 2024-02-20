namespace Exercicio_POO_Parte01_Ex._05
{
    internal class Program
    {
        static List<Funcionario> funcionarios = new List<Funcionario>();

        static void Main(string[] args)
        {
            string escolha;

            do
            {
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1.Informações de funcionários");
                Console.WriteLine("2.Cadastrar novo funcionário");
                Console.WriteLine("3. Atualizar informações de um funcionário");
                Console.WriteLine("4. Acessar informações financeiras de um funcionário");
                Console.WriteLine("5.Sair do sistema");
                Console.WriteLine();

                escolha = Console.ReadLine();

            switch (escolha)
                {
                    case "1":
                        Console.WriteLine("Informações de funcionários");
                        MostrarInformacoesFuncionario();
                        break;

                    case "2":
                        Console.WriteLine("Cadastrar novo funcionário");
                        CadastrarNovoFuncionario();
                        break;

                    case "3":
                        Console.WriteLine("Atualizar informações de um funcionário");
                        AtualizarInformacoesFuncionario();
                        break;
                   
                    case "4":
                        Console.WriteLine("Acessar informações financeiras de um funcionário");
                        AcessarInformacoesFinanceirasFuncionario();
                        break;

                    case "5":
                        Console.WriteLine("Saindo do sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor, selecione uma opção válida.");
                        break;
                }

                Console.WriteLine();
            } while (escolha != "5");
        }

        private static void AcessarInformacoesFinanceirasFuncionario()
        {
            Console.WriteLine("Informe o nome do funcionário:");
            string nomeFuncionario = Console.ReadLine();

            Funcionario funcionario = funcionarios.FirstOrDefault(f => 
                     f.Nome == nomeFuncionario
            );

            if (funcionario != null)
            {
                double salarioLiquido = funcionario.CalcularSalarioLiquido();

                Console.WriteLine($"Informações financeiras de {funcionario.Nome}:");
                Console.WriteLine($"Salário Bruto: {funcionario.SalarioBruto}");
                Console.WriteLine($"Desconto INSS: {funcionario.CalculaInss()}");
                Console.WriteLine($"Desconto IR: {funcionario.CalculaIrpf()}");
                Console.WriteLine($"Outros descontos: {funcionario.DescontoOutros}");
                Console.WriteLine($"Salário Líquido: {salarioLiquido}");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
        }

        private static void AtualizarInformacoesFuncionario()
        {
            Console.WriteLine("Informe o nome do funcionário:");
            string nomeFuncionario = Console.ReadLine();

            Funcionario funcionario = funcionarios.FirstOrDefault(
                       f => f.Nome == nomeFuncionario
             );

            if (funcionario != null)
            {
                Console.WriteLine($"Funcionário encontrado: {funcionario.Nome}");

                Console.WriteLine("Informe o novo salário:");
                funcionario.SalarioBruto = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Informe o novo cargo:");
                funcionario.Cargo = Console.ReadLine();

                Console.WriteLine("Informações do funcionário atualizadas com sucesso!");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
        }

        private static void MostrarInformacoesFuncionario()
        {
            if (funcionarios == null || funcionarios.Count == 0) {
                Console.WriteLine("Nenhum funcionario cadastrado");
             }

            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine($"Nome: {funcionario.Nome}, Salário Bruto: {funcionario.SalarioBruto}, Cargo: {funcionario.Cargo}");
            }
        }

        private static void CadastrarNovoFuncionario()
        {
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            
            Console.WriteLine("Salário:");
            double salario = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Cargo:");
            string cargo = Console.ReadLine();

            Console.WriteLine("Outros descontos do funcionario: ");
            double descontoOutros = Convert.ToDouble(Console.ReadLine());

            Funcionario novoFuncionario = new Funcionario(nome, salario, cargo, descontoOutros);
           
            double descontoInss = novoFuncionario.CalculaInss(); 
            Console.WriteLine($"Desconto INSS: {descontoInss}");

            double descontoIrpf = novoFuncionario.CalculaIrpf();
            Console.WriteLine($"Desconto IR: {descontoIrpf}");

            funcionarios.Add(novoFuncionario);
            Console.WriteLine("Novo funcionário cadastrado com sucesso!");
        }
    }
}


