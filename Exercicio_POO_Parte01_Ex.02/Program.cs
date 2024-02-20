namespace Exercicio_POO_Parte01_Ex._02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var opcao = "1";
            ContaBancaria contaBancaria = null;

            Console.WriteLine("Digite o nome completo:");
            string nomeTitular = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Digite os números da conta:");
            double numeroConta = double.Parse(Console.ReadLine());
            Console.WriteLine();

            ContaBancaria contabancaria = new ContaBancaria(numeroConta, 0, nomeTitular);

            while (true)
            {
                Console.WriteLine("Qual operação deseja realizar?");
                Console.WriteLine("1.Depósito.");
                Console.WriteLine("2.Saque.");
                Console.WriteLine("3.Consultar saldo");
                opcao = Console.ReadLine();


                switch (opcao)
                {

                    case "1":
                        RealizarDepositos(contabancaria);
                        break;

                    case "2":
                        RealizarSaques(contabancaria);
                        break;

                    case "3":
                        VerSaldo(contabancaria);
                        break;
                }

                Console.WriteLine("Deseja realizar uma nova operação? (s/n):");
                string novaConsulta = Console.ReadLine();
                if (novaConsulta.ToLower() != "s")
                {
                    break;
                }
                Console.Clear();

            }

        }

        private static void VerSaldo(ContaBancaria contabancaria)
        {
            Console.WriteLine($"Seu saldo atual é de: {contabancaria.verSaldo():C}");
            double verSaldo = double.Parse(Console.ReadLine());
            contabancaria.verSaldo();
        }

        private static void RealizarSaques(ContaBancaria contabancaria)
        {
            Console.WriteLine("Digite o valor para saque:");
            double valorSaque = double.Parse(Console.ReadLine());
            contabancaria.RealizarSaque(valorSaque);
        }

        private static void RealizarDepositos(ContaBancaria contabancaria)
        {
            Console.WriteLine("Digite o valor a ser depositado:");
            double valorDeposito = double.Parse(Console.ReadLine());
            contabancaria.RealizarDeposito(valorDeposito);
        }
    }
}

