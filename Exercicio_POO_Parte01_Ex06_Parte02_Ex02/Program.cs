namespace Exercicio_POO_Parte01_Ex06_Parte02_Ex02
{
    internal class Program
    {
        static List<Produto> produtos = new List<Produto>();

        static void Main(string[] args)
        {
            string escolha;

            do
            {
                Console.WriteLine("Informe a opção desejada:");

                Console.WriteLine("1.Informações de produtos");
                Console.WriteLine("2.Cadastrar novo produto");
                Console.WriteLine("3. Atualizar informações de um produto");
                Console.WriteLine("4.Sair do sistema");
                Console.WriteLine();

                escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.WriteLine("Informações de produtos");
                        MostrarInformacoesProduto();
                        break;

                    case "2":
                        Console.WriteLine("Cadastrar novo produto");
                        CadastrarNovoProduto();
                        break;

                    case "3":
                        Console.WriteLine("Atualizar informações de um produto");
                        AtualizarInformacoesProduto();
                        break;

                    case "4":
                        Console.WriteLine("Saindo do sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor, selecione uma opção válida.");
                        break;
                }

                Console.WriteLine();
            } while (escolha != "4");
        }

        private static void AtualizarInformacoesProduto()
        {
            Console.WriteLine("Informe o nome do produto:");
            string nomeProduto = Console.ReadLine();

            Produto produto = produtos.FirstOrDefault(
                       f => f.Nome == nomeProduto
             );

            if (produto != null)
            {
                Console.WriteLine($"Funcionário encontrado: {produto.Nome}");

                Console.WriteLine("Informe o novo preco:");
                produto.Preco = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Informe a quantidade para adicionar em estoque:");
                int quantidade = Convert.ToInt32(Console.ReadLine());

                produto.AdicionarEstoque(quantidade);

                Console.WriteLine("Informações do produto atualizadas com sucesso!");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
        }

        private static void MostrarInformacoesProduto()
        {
            if (produtos == null || produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado");
            }

            foreach (var produto in produtos)
            {
                Console.WriteLine($"Nome: {produto.Nome}, Preco: {produto.Preco}, Estoque: {produto.CacularEstoque()}");

            }
        }

        private static void CadastrarNovoProduto()
        {
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Estoque inicial:");
            int estoqueInicial = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Preco:");
            double preco = Convert.ToDouble(Console.ReadLine());

            Produto novoProduto = new Produto(nome, preco, estoqueInicial);

            produtos.Add(novoProduto);
            Console.WriteLine("Novo produto cadastrado com sucesso!");
        }
    }
}
