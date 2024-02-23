namespace ExerciciosPOO_02_SistemaHotel
{
    internal class Program
    {
        // Declaração e inicialização de listas para armazenar objetos de Pessoa, Suíte e Reserva
        static List<Pessoa> pessoas = new List<Pessoa>();
        static List<Suite> suites = new List<Suite>();
        static List<Reserva> reservas = new List<Reserva>();

        static void Main(string[] args)
        {
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("ARAYA ALFENAR HOTEL\nMenu:");
                Console.WriteLine();
                Console.WriteLine("1. Cadastro");
                Console.WriteLine("2. Consultar");
                Console.WriteLine("3. Listar");
                Console.WriteLine("4. Sair");
                Console.WriteLine();

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Cadastro(); // Chama o método Cadastro
                        break;
                    case 2:
                        Consultar(); // Chama o método Consultar
                        break;
                    case 3:
                        Listar(); // Chama o método Listar
                        break;
                    case 4:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
            Console.Clear();
        }

        static void Cadastro()  // Métodos Cadastro
        {
            Console.WriteLine("Cadastro:");
            Console.WriteLine("1. Hospede");
            Console.WriteLine("2. Suite");
            Console.WriteLine("3. Reserva");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Cadastro de Pessoa:");
                    CadastrarPessoa();
                    break;

                case 2:
                    Console.WriteLine("Cadastro de Suite:");
                    CadastrarSuite();
                    break;

                case 3:
                    Console.WriteLine("Cadastro de Reserva:");
                   
                    CadastrarReserva();
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            Console.WriteLine("Deseja fazer uma nova operação (s/n)?");
            string continuar = Console.ReadLine().ToLower();
            if (continuar != "s")
                return;
        }

        private static Pessoa CadastrarPessoa()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Idade: ");
            int idade = int.Parse(Console.ReadLine());
            Console.Write("Gênero: ");
            string genero = Console.ReadLine();
            Console.Write("Profissão: ");
            string profissao = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Contato de Emergência: ");
            string contatoEmergencia = Console.ReadLine();

            Pessoa pessoa = new Pessoa(nome, idade, genero, profissao, email, telefone, contatoEmergencia);
            pessoas.Add(pessoa);
            return pessoa;
        }

        private static void CadastrarSuite()
        {
            Console.Write("Capacidade: ");
            int capacidade = int.Parse(Console.ReadLine());

            Console.Write("Valor da Diária: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());

            Console.Write("Tipo de Quarto: ");
            string tipoQuarto = Console.ReadLine();

            Console.Write("Número do Quarto: ");
            int numeroQuarto = int.Parse(Console.ReadLine());
          
            Suite suite = new Suite(capacidade, valorDiaria, tipoQuarto, numeroQuarto);

            suites.Add(suite);
            Console.WriteLine("Suite cadastrada com sucesso");
        }

        private static void CadastrarReserva()
        {
            Console.WriteLine("Nome da pessoa:");
            string termoPesquisaPessoa = Console.ReadLine();
            var pessoa = pessoas.FirstOrDefault(p => p.Nome.Equals(termoPesquisaPessoa) || p.Email.Equals(termoPesquisaPessoa));

            if (pessoa == null) {
                Console.WriteLine("Pessoa nao encontrada");
                return;
            }

            Console.WriteLine("Suite:");
            string termoPesquisaSuite = Console.ReadLine();
            var suite = suites.FirstOrDefault(p => p.NumeroQuarto.ToString().Equals(termoPesquisaSuite));
            if (suite == null)
            {
                Console.WriteLine("Suite nao encontrada");
                return;
            }

            Console.WriteLine("Data de início da reserva (formato: dd/mm/aaaa):");
            DateTime dataInicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.WriteLine("Data de fim da reserva (formato: dd/mm/aaaa):");
            DateTime dataFim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.WriteLine("Quantidade de quartos:");
            int qntQuartos = int.Parse(Console.ReadLine());

            var reserva = Reserva.FazerReserva(pessoa, suite, dataInicio, dataFim, qntQuartos);

            Console.WriteLine();
            reservas.Add(reserva);

            Console.WriteLine("Resumo da reserva:");
            Console.WriteLine(reserva);
            Console.WriteLine(reserva.InformarCondicoesCancelamento());
            Console.WriteLine("Deseja confirmar a reserva?");
            var resposta = Console.ReadLine();
            if (resposta == "s") 
            {
                reservas.Add(reserva);
            }
            else { Console.WriteLine("Reserva cancelada."); }

        }

        static void Consultar()
        {
            Console.WriteLine("Consulta:");
            Console.WriteLine("1. Hospede (apenas 1)");
            Console.WriteLine("2. Suite (Apenas 1)");
            Console.WriteLine("3. Reserva (Apenas 1)");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Consultar Hospede:");

                    Console.Write("Digite o nome ou email da pessoa: ");
                    string termoPesquisa = Console.ReadLine();

                    var pessoa = pessoas.FirstOrDefault(p => p.Nome.Equals(termoPesquisa) || p.Email.Equals(termoPesquisa));

                    if(pessoa == null)
                        Console.WriteLine("Pessoa não encontrada.");

                    else Console.WriteLine(pessoa.ToString());

                    break;

                case 2:
                    Console.WriteLine("Consultar Suite.\nNúmero do quarto:");
                    string numeroQuarto = Console.ReadLine();


                    var suite = suites.FirstOrDefault(p => p.NumeroQuarto.ToString().Equals(numeroQuarto));

                    if (suite == null)
                        Console.WriteLine("Suite não encontrada.");

                    else Console.WriteLine(suite.ToString());

                    break;

                case 3:
                    Console.WriteLine("Consultar Reserva:");
             
                    Console.WriteLine("Nome do hóspede:");
                    string nomePessoa = Console.ReadLine();

                    Reserva reservaEncontrada = reservas.FirstOrDefault(r => r.Pessoa.Nome.Equals(nomePessoa));

                    if (reservaEncontrada != null)
                    {
                        Console.WriteLine($"Reserva encontrada:\n{ reservaEncontrada}");
                    }
                    else
                    {
                        Console.WriteLine("Reserva não encontrada.");
                    }
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            Console.WriteLine("Deseja fazer uma nova operação (s/n)?");
            string continuar = Console.ReadLine().ToLower();
            if (continuar != "s")
                return;
        }


        static void Listar()  // Métodos Listar 
        {
            Console.WriteLine("Lista:");
            Console.WriteLine("1. Hospedes");
            Console.WriteLine("2. Suites");
            Console.WriteLine("3. Reservas");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Lista de hóspedes:");
                    foreach (Pessoa pessoa in pessoas)
                    {
                        Console.WriteLine(pessoa);
                    }
                    break;

                case 2:
                    Console.WriteLine("Lista de Suites:");
                    foreach (Suite suite in suites)
                    {
                        Console.WriteLine(suite);
                    }
                    break;

                case 3:
                    Console.WriteLine("Lista de reservas:");
                    foreach (Reserva reserva in reservas)
                    {
                        Console.WriteLine(reserva);
                    }
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            Console.WriteLine("Deseja fazer uma nova operação (s/n)?");
            string continuar = Console.ReadLine().ToLower();
            if (continuar != "s")
                return;
        }
    }
}
        

