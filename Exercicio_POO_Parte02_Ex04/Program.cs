namespace Exercicio_POO_Parte02_Ex04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MaquinaDeVendas maquina = new MaquinaDeVendas();
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("Digite a opção em que você se enquadra:");
                Console.WriteLine();
                Console.WriteLine("1. Sou vendedor.");
                Console.WriteLine("2. Sou cliente.");
                Console.WriteLine("3. Sair.");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MenuVendedor(maquina);
                        break;
                    case 2:
                        RealizarCompra(maquina);
                        break;
                    case 3:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void MenuVendedor(MaquinaDeVendas maquina)
        {
            bool novoCadastro = true;

            while (novoCadastro)
            {
                Console.WriteLine("Menu do Vendedor:");
                Console.WriteLine("1. Cadastrar Novo Produto e Valor");
                Console.WriteLine("2. Sair");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Nome do produto: ");
                        string nome = Console.ReadLine();
                        Console.Write("Valor do produto: ");
                        double valor = double.Parse(Console.ReadLine());
                        maquina.CadastrarProduto(nome, valor);
                        break;
                    case 2:
                        novoCadastro = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Deseja fazer um novo cadastro? (S/N)");
                char resposta = char.Parse(Console.ReadLine().ToUpper());
                novoCadastro = (resposta == 'S');
            }
        }

        static void RealizarCompra(MaquinaDeVendas maquina)
        {
            bool novaCompra = true;

            while (novaCompra)
            {
                Console.WriteLine("Menu do Cliente:");
                Console.WriteLine("Digite o nome do produto:");
                string nomeProduto = Console.ReadLine();
                double precoProduto = maquina.SelecionarProduto(nomeProduto);
                if (precoProduto > 0)
                {
                    Console.WriteLine($"Produto selecionado. Preço: {precoProduto}");

                    Console.WriteLine("Digite o valor a ser inserido:");
                    double valorInserido = double.Parse(Console.ReadLine());
                    maquina.InserirDinheiro(valorInserido);

                    double troco = maquina.DarTroco(precoProduto);
                    Console.WriteLine($"Troco: {troco}");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }

                Console.WriteLine("Deseja fazer uma nova compra? (S/N)");
                char resposta = char.Parse(Console.ReadLine().ToUpper());
                novaCompra = (resposta == 'S');
            }
        }
    }
}
