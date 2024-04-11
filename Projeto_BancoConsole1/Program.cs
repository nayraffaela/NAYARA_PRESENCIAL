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
            IConfiguration configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            // Obtém a string de conexão do arquivo de configuração
            string connectionString = configuration.GetConnectionString("SafiraBankDatabase");

            // Crie instâncias dos repositórios usando a string de conexão
            clienteRepository = new ClienteRepository(connectionString);
            contaRepository = new ContaRepository(connectionString);


            Cliente cliente = null; //indicando que a variavel cliente ainda não foi incializada pois não há ainda cadastro de cliente.

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

                if(opcao > 1 && opcao < 5 && !VerificaClienteConta(cliente)) //pra verficiar se o cliente já possui conta.
                {
                    Console.WriteLine("Selecione a opção 1 para cadastrar uma conta antes de realizar uma operação.");
                } 
                else
                {
                    switch (opcao)
                    {
                        case 1:
                            cliente = CadastrarCliente(); //chama o método
                            if (cliente == null) //caso não tenha cadastro ainda, se não segue pa
                                                 //ra sucesso.
                            {
                                Console.WriteLine("É necessário cadastrar um cliente primeiro.");
                            }
                            else
                            {
                                CadastrarNovaConta(cliente); //chama método
                            }
                            break;

                        case 2:
                            RealizarTransferencia(cliente);//chama o método
                            break;

                        case 3:
                            RealizarDeposito(cliente);//chama o método
                            break;

                        case 4:
                            ConsultarSaldo(cliente);//chama o método
                            break;

                        case 5:
                            sair = true;
                            Console.WriteLine("Obrigado por utilizar o SAFFIRA BANK. Até logo!");
                            break;

                        default:
                            Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                            break;
                    }
                }

             

                Console.WriteLine();
            }
        }

        static Cliente CadastrarCliente() //método
        {
            Console.WriteLine("CADASTRO DE NOVO CLIENTE");
            Cliente cliente = new Cliente(); //instancia

            Console.WriteLine("Informe o CPF do cliente (11 dígitos):");
            string cpf = Console.ReadLine();
            while (cpf.Length != 11)
            {
                Console.WriteLine("CPF inválido. Por favor, digite novamente:");
                cpf = Console.ReadLine();
            }
            cliente.Cpf = cpf;

            Console.WriteLine("Informe o nome do cliente:");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Informe a data de nascimento do cliente (dd/mm/aaaa):");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento)) //o out usado para que o metodo tryparse modifique a variavel
            {
                cliente.DataNascimento = dataNascimento;
            }

            Console.WriteLine("Informe a senha do cliente:");
            cliente.Senha = Console.ReadLine();

            //salva no banco....
            clienteRepository.AddCliente(cliente);

            return cliente;
        }

        static void CadastrarNovaConta(Cliente cliente)//método
        {
            Console.WriteLine("CADASTRO DE NOVA CONTA");

            Console.WriteLine("Informe o tipo de conta (0 para Conta Corrente, 1 para Conta Poupança):");
            int tipoContaInput = int.Parse(Console.ReadLine());//tentativa de conversão+ exceção;
            TipoConta tipoConta = (TipoConta)tipoContaInput; //tentativa de conversão para enum

            //instância da classe Conta
            Conta novaConta;
            if (tipoConta == TipoConta.Corrente)
            {
                novaConta = new ContaCorrente();
            }
            else
            {
                novaConta = new ContaPoupanca();
            }

            cliente.Conta = novaConta;

            contaRepository.CriarConta(cliente);

            Console.WriteLine("Nova conta cadastrada com sucesso!");
        }

        

        static void RealizarTransferencia(Cliente cliente)//método
        {
            Console.WriteLine("TRANSFERÊNCIA");
            Console.WriteLine("Digite a quantia a ser transferida:");
            decimal quantia = Convert.ToDecimal(Console.ReadLine());

            try
            {
                cliente.Conta.Transferir(quantia);
                Console.WriteLine("Transferência realizada com sucesso.");
                Console.WriteLine("Saldo após a transferência: " + cliente.Conta.Saldo);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void RealizarDeposito(Cliente cliente)
        {
            Console.WriteLine("DEPÓSITO");
            Console.WriteLine("Digite a quantia a ser depositada:");
            decimal quantia = Convert.ToDecimal(Console.ReadLine());

            try
            {
                cliente.Conta.Depositar(quantia);
                Console.WriteLine("Depósito realizado com sucesso.");
                Console.WriteLine("Saldo após o depósito: " + cliente.Conta.Saldo);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static bool VerificaClienteConta(Cliente cliente)
        {
            return cliente != null && cliente.Conta != null; //Verificação
        }
        static void ConsultarSaldo(Cliente cliente)
        {
            Console.WriteLine("CONSULTA DE SALDO");
            Console.WriteLine("Dados do cliente:");
            Console.WriteLine("Nome: " + cliente.Nome);
            Console.WriteLine("CPF: " + cliente.Cpf);
            Console.WriteLine("Data de Nascimento: " + cliente.DataNascimento.ToString("dd/MM/yyyy"));
            Console.WriteLine("Tipo de cliente: " + cliente.Tipo);

            Console.WriteLine("Dados da conta:");
            Console.WriteLine("Número: " + cliente.Conta.Numero);
            Console.WriteLine("Saldo: " + cliente.Conta.Saldo);
            Console.WriteLine("Tipo de conta: " + cliente.Conta.Tipo);
        }
    }
}