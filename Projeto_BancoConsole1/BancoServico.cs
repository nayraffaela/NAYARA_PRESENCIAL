using Projeto_BancoConsole1.Models;

public class BancoServico
{
    private readonly ClienteRepository clienteRepository;
    private readonly ContaRepository contaRepository;

    public BancoServico(ClienteRepository clienteRepository, ContaRepository contaRepository)
    {
        this.clienteRepository = clienteRepository;
        this.contaRepository = contaRepository;
    }

    private Cliente CadastrarCliente(string cpf)
    {
        var cliente = new Cliente();
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

        //salva cliente no banco....
        clienteRepository.AddCliente(cliente);

        Console.WriteLine("Cliente cadastrado com sucesso");

        return cliente;
    }

    public void CadastrarNovaConta()
    {
        var cpf = GetCpf();
        var cliente = clienteRepository.GetClienteByCpf(cpf);

        if (cliente == null)
        {
            cliente = CadastrarCliente(cpf);
        }
        else
        {
            Console.WriteLine("Ja existe um cliente cadastrado com o cpf informado");
            if(!Autenticar(cliente))
            {
                 Console.WriteLine("Senha invalida, tente novamente.");
                return;
            };
        }

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
        novaConta.Cliente = cliente;

        //salva conta no banco
        contaRepository.CriarConta(novaConta);

        Console.WriteLine("Nova conta cadastrada com sucesso!");
    }

    private bool Autenticar(Cliente cliente)
    {
        Console.WriteLine("Para continuar é preciso validar a transação");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Digite sua senha:");
        string senhaDigitada = Console.ReadLine();
        Console.WriteLine("------------------------------------");

      return cliente.Senha == senhaDigitada;
    }

    private string GetCpf()
    {
        Console.WriteLine("Para continuar informe o CPF do cliente (11 dígitos):");
        var cpf = Console.ReadLine();
        while (cpf.Length != 11)
        {
            Console.WriteLine("CPF inválido. Por favor, digite novamente:");
            cpf = Console.ReadLine();
        }
        return cpf;
    }

    public void RealizarTransferencia()
    {
        var cpf = GetCpf();
        var cliente = clienteRepository.GetClienteByCpf(cpf);

        if (!Autenticar(cliente))
        {
            Console.WriteLine("Senha invalida, tente novamente.");
            return;
        };

        Console.WriteLine("Digite a quantia a ser transferida:");
        decimal quantia = Convert.ToDecimal(Console.ReadLine());


        Console.WriteLine("Digite o numero da conta para transferir:");
        string numeroContaDestino = Console.ReadLine();

        //le conta do banco
        var contaDestino = contaRepository.GetContaByNumero(numeroContaDestino);

        //se valida, deposita a quantia
        if(contaDestino == null)
        {
            Console.WriteLine("Conta invalida, tente novamente.");
            return;
        }
        else
        {
            contaDestino.Depositar(quantia);
        }

        //transfere
        cliente.Conta.Transferir(quantia);

        contaRepository.UpdateConta(contaDestino);
        contaRepository.UpdateConta(cliente.Conta);

        Console.WriteLine("Transferência realizada com sucesso.");
        Console.WriteLine("Saldo após a transferência: " + cliente.Conta.Saldo);
    }

    public void RealizarDeposito()
    {
        var cpf = GetCpf();
        var cliente = clienteRepository.GetClienteByCpf(cpf);

        if (!Autenticar(cliente))
        {
            Console.WriteLine("Senha invalida, tente novamente.");
            return;
        };

        Console.WriteLine("Digite a quantia a ser depositada:");
        decimal quantia = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Digite o numero da conta para depositar:");
        string numeroContaDestino = Console.ReadLine();

        //le conta do banco
        var contaDestino = contaRepository.GetContaByNumero(numeroContaDestino);

        //se valida, deposita a quantia
        if (contaDestino == null)
        {
            Console.WriteLine("Conta invalida, tente novamente.");
            return;
        }
        else
        {
            contaDestino.Depositar(quantia);
        }

        contaRepository.UpdateConta(contaDestino);

        Console.WriteLine("Deposito realizado com sucesso.");
        Console.WriteLine("Saldo após a Deposito: " + contaDestino.Saldo);
    }

    public void ConsultarSaldo()
    {
        var cpf = GetCpf();
        var cliente = clienteRepository.GetClienteByCpf(cpf);

        if (!Autenticar(cliente))
        {
            Console.WriteLine("Senha invalida, tente novamente.");
            return;
        };

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
