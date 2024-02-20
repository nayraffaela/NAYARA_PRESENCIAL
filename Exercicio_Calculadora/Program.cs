namespace Caculadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Opcao = "1";
            double number01 = 0;
            double number02 = 0;

        

            

            while (Opcao != "5")
            {
                Console.WriteLine("Qual a operação matemática que desejada");
                Console.WriteLine("1.Soma");
                Console.WriteLine("2.Subtração");
                Console.WriteLine("3.Multiplicação");
                Console.WriteLine("4.Divisão");
                Console.WriteLine("5.Sair");
                Console.WriteLine();
                Console.WriteLine("Digite a opção desejada:");
                Opcao = Console.ReadLine();
                Console.WriteLine();

                if (Opcao == "1" || Opcao == "2" || Opcao == "3" || Opcao == "4")
                {
                    Console.WriteLine("Digite o segundo número para a operação:");
                    number02 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Digite o primeiro número para a operação:");
                    number01 = Convert.ToDouble(Console.ReadLine());
                }

                switch (Opcao)
                {
                    case "1":
                        double adicao = soma(number01, number02);
                        Console.WriteLine($"O resultado de {number01} + {number02} é: {adicao}");
                        break;

                    case "2":
                        double subtracao = subtrai(number01, number02);
                        Console.WriteLine($"O resultado de {number01} - {number02} é: {subtracao}");
                        break;

                    case "3":
                        double multiplicacao = multiplica(number01, number02);
                        Console.WriteLine($"O resultado de {number01} * {number02} é: {multiplicacao}");
                        break;

                    case "4":
                        if (number02 != 0)
                        {
                            double divisao = divide(number01, number02);
                            Console.WriteLine($"O resultado de {number01} / {number02} é: {divisao}");
                        }
                        else
                        {
                            Console.WriteLine("Erro: Não é possivel dividir por 0.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Saindo do programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;

                }
            }

        }

     

        private static double divide(double number01, double number02)
        {
            return number01 / number02;
        }

        private static double multiplica(double number01, double number02)
        {
            return number01 * number02;
        }

        private static double subtrai(double number01, double number02)
        {
            return number01 - number02;
        }

        private static double soma(double number01, double number02)
        {
            return number01 + number02;
        }
    }
}
