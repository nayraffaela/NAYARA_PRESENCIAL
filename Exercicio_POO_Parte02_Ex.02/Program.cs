namespace Exercicio_POO_Parte02_Ex._02
{
    internal class Program
    {
        static void Main(string[] args)
        {

            LojaVirtual loja = new LojaVirtual();
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("Digite a opção em que você se enquadra:");
                Console.WriteLine();
                Console.WriteLine("1.Sou vendedor.");
                Console.WriteLine("2.Sou cliente.");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MenuVendedor(loja);
                        break;
                    case 2:
                        MenuCliente(loja);
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


            static void MenuVendedor(LojaVirtual loja)
            {
                bool novoCadastro = true;

                while (novoCadastro)
                {
                    Console.WriteLine("Menu do Vendedor:");
                    Console.WriteLine("1. Cadastrar Novo Produto e Valor");
                    Console.WriteLine("2. Aplicar Desconto");

                    int opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Console.Write("Nome do produto: ");
                            string nome = Console.ReadLine();
                            Console.Write("Valor do produto: ");
                            int valor = int.Parse(Console.ReadLine());
                            ProdutoComum produto = new ProdutoComum(nome, valor);
                            loja.CadastrarProduto(produto);
                            break;
                        case 2:
                            Console.Write("Percentual de desconto: ");
                            int desconto = int.Parse(Console.ReadLine());
                            loja.AplicarDesconto(desconto);
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

            static void MenuCliente(LojaVirtual loja)
            {
                bool novaConsulta = true;

                while (novaConsulta)
                {
                    Console.WriteLine("Menu do Cliente:");
                    Console.WriteLine("1. Pesquisar Produto e Adicionar ao Carrinho / Ver Carrinho e Finalizar Compra");
                    Console.WriteLine("2. Sair");

                    int opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Digite o nome do produto:");
                            string nomeProduto = Console.ReadLine();
                            ProdutoComum produtoEncontrado = loja.PesquisarProduto(nomeProduto);

                            if (produtoEncontrado != null)
                            {
                                loja.AdicionarAoCarrinho(produtoEncontrado);
                                Console.WriteLine("Produto incluído no carrinho com sucesso!");
                                int total = loja.CalcularValorTotalCompra();
                                Console.WriteLine($"Valor Total da Compra: R$ {total}");
                                novaConsulta = false; // Finalizar consulta após adicionar ao carrinho
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado.");
                            }
                            break;

                        case 2:
                            novaConsulta = false; // Sair do menu do cliente
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
            }
        }
    }
}