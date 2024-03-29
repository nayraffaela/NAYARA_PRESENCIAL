namespace Projeto_BancoConsole1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = null;

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

                if(opcao > 1 && opcao < 5 && !VerificaClienteConta(cliente))
                {
                    Console.WriteLine("Selecione a opção 1 para cadastrar uma conta antes de realizar uma operação.");
                } 
                else
                {
                    switch (opcao)
                    {
                        case 1:
                            cliente = CadastrarCliente();
                            if (cliente == null)
                            {
                                Console.WriteLine("É necessário cadastrar um cliente primeiro.");
                            }
                            else
                            {
                                CadastrarNovaConta(cliente);
                            }
                            break;

                        case 2:
                            RealizarTransferencia(cliente);
                            break;

                        case 3:
                            RealizarDeposito(cliente);
                            break;

                        case 4:
                            ConsultarSaldo(cliente);
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

        static Cliente CadastrarCliente()
        {
            Console.WriteLine("CADASTRO DE NOVO CLIENTE");
            Cliente cliente = new Cliente();

            Console.WriteLine("Informe o CPF do cliente (11 dígitos):");
            string cpf = Console.ReadLine();
            while (cpf.Length != 11)
            {
                Console.WriteLine("CPF inválido. Por favor, digite novamente:");
                cpf = Console.ReadLine();
            }
            cliente.CPF = cpf;

            Console.WriteLine("Informe o nome do cliente:");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Informe a data de nascimento do cliente (dd/mm/aaaa):");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
            {
                cliente.DataNascimento = dataNascimento;
            }

            return cliente;
        }

        static void CadastrarNovaConta(Cliente cliente)
        {
            Console.WriteLine("CADASTRO DE NOVA CONTA");

            Console.WriteLine("Informe o tipo de conta (0 para Conta Corrente, 1 para Conta Poupança):");
            int tipoContaInput = int.Parse(Console.ReadLine());
            TipoConta tipoConta = (TipoConta)tipoContaInput;

            //instância da classe Conta com as informações que foram incluidas
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

            Console.WriteLine("Nova conta cadastrada com sucesso!");
        }

        

        static void RealizarTransferencia(Cliente cliente)
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
            return cliente != null && cliente.Conta != null;
        }
        static void ConsultarSaldo(Cliente cliente)
        {
            Console.WriteLine("CONSULTA DE SALDO");
            Console.WriteLine("Dados do cliente:");
            Console.WriteLine("Nome: " + cliente.Nome);
            Console.WriteLine("CPF: " + cliente.CPF);
            Console.WriteLine("Data de Nascimento: " + cliente.DataNascimento.ToString("dd/MM/yyyy"));
            Console.WriteLine("Tipo de cliente: " + cliente.Tipo);

            Console.WriteLine("Dados da conta:");
            Console.WriteLine("Número: " + cliente.Conta.Numero);
            Console.WriteLine("Saldo: " + cliente.Conta.Saldo);
            Console.WriteLine("Tipo de conta: " + cliente.Conta.Tipo);
        }
    }
}