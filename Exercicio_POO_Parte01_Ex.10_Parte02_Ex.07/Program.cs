namespace Exercicio_POO_Parte01_Ex._10_Parte02_Ex._07
{
    internal class Program
    {
       static Biblioteca biblioteca = new Biblioteca();

        static void Main(string[] args)
        {
            var opcao = "";
            while (opcao != "5")
            {
                Console.WriteLine("Digite a opção desejada:");
                Console.WriteLine("1.Cadastrar um novo livro.");
                Console.WriteLine("2.Emprestismo de livros.");
                Console.WriteLine("3.Devolução e baixa de livros");
                Console.WriteLine("4.Verificar a disponibilização de livros");
                Console.WriteLine("5. Sair do programa.");


                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        string titulo, autor;
                        CadastrarNovoLivro(out titulo, out autor);
                        break;

                    case "2":
                        EmprestarLivro(out titulo, out autor);
                        break;

                    case "3":
                        DevolverLivro(out titulo, out autor);
                        break;

                    case "4":
                        VerificarDisponibilidade(out titulo, out autor);

                        break;

                    case "5":
                        Console.WriteLine("Saindo do programa.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;

                }
            }
        }

        private static void VerificarDisponibilidade(out string titulo, out string autor)
        {
            Console.WriteLine("Para verificar disponibilidade de livros informe:");

            Console.WriteLine("Autor:");
            autor = Console.ReadLine();

            Console.WriteLine("Titulo:");
            titulo = Console.ReadLine();

            var livro = biblioteca.ConsultarLivro(autor, titulo);

            if (livro != null && livro.EstaDisponivel())
                Console.WriteLine("Livro disponivel");
            else
            {
                Console.WriteLine("O livro não está disponível na biblioteca.");
            }
        }

        private static void DevolverLivro(out string titulo, out string autor)
        {
            Console.WriteLine("Para devolução e baixa de livros, informe:");

            Console.WriteLine("Titulo :");
            titulo = Console.ReadLine();

            Console.WriteLine("Autor:");
            autor = Console.ReadLine();

            var resultadoDevolucao = biblioteca.DevolverLivro(autor, titulo);

            if (resultadoDevolucao == true)
                Console.WriteLine("Livro devolvido com sucesso");
            else
                Console.WriteLine("Livro não encontrado");

            Console.WriteLine();
        }

        private static void EmprestarLivro(out string titulo, out string autor)
        {
            Console.WriteLine("Para emprestimo de livros, informe:");

            Console.WriteLine("Autor:");
            autor = Console.ReadLine();

            Console.WriteLine("Titulo:");
            titulo = Console.ReadLine();

            Console.WriteLine("Nome completo do solicitante");
            var solicitante = Console.ReadLine();

            Console.WriteLine("Data do emprestimo:");
            DateTime inicio = DateTime.Now;

            var resultadoEmprestimo = biblioteca.EmprestarLivro(autor, titulo, solicitante, inicio);


            if (resultadoEmprestimo == true)
                Console.WriteLine("Livro emprestado com sucesso");
            else
                Console.WriteLine("Livro não esta disponivel");
        }

        private static void CadastrarNovoLivro(out string titulo, out string? autor)
        {
            Console.WriteLine("Livro:");
            titulo = Console.ReadLine();
            Console.WriteLine("Autor:");
            autor = Console.ReadLine();
            Console.WriteLine("Páginas:");
            int numeroPaginas = int.Parse(Console.ReadLine());

            Livro novoLivro = new Livro(titulo, autor, numeroPaginas);

            biblioteca.CadastrarLivros(novoLivro);

            Console.WriteLine("Livro cadastrado com sucesso!");
            Console.WriteLine("ID do livro cadastrado: " + novoLivro.VerId());
            Console.WriteLine();
        }
    }
}
