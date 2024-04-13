using Microsoft.Extensions.Configuration;
using Projeto_BancoConsole1.Models;

namespace Projeto_BancoConsole1
{
    internal class Program
    {
        private static ClienteRepository clienteRepository;
        private static ContaRepository contaRepository;

        static void Main(string[] args)
        {
            
            //arquivo de configuracao
            IConfiguration configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            // Obtém a string de conexão do arquivo de configuração
            string connectionString = configuration.GetConnectionString("SafiraBankDatabase");

            // Crie instâncias dos repositórios usando a string de conexão
            clienteRepository = new ClienteRepository(connectionString);
            contaRepository = new ContaRepository(connectionString);

            var servico = new BancoServico(clienteRepository, contaRepository);

            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("SAFFIRA BANK\nDigite a opção desejada:");
                Console.WriteLine("1 - Cadastrar nova conta");
                Console.WriteLine("2 - Transferências");
                Console.WriteLine("3 - Depósitos");
                Console.WriteLine("4 - Consultar saldo");
                Console.WriteLine("5 - Sair");
                Console.WriteLine();

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                                servico.CadastrarNovaConta();//chama o método
                            break;

                    case 2:
                                servico.RealizarTransferencia();//chama o método
                            break;

                    case 3:
                                servico.RealizarDeposito();//chama o método
                            break;

                    case 4:
                            servico.ConsultarSaldo();//chama o método
                            break;

                    case 5:
                        sair = true;
                        Console.WriteLine("Obrigado por utilizar o SAFFIRA BANK. Até logo!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }

                Console.WriteLine();
            }
        }

      
      
       
    }
}