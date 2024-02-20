namespace Exercicio_POO_Parte02_Ex06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var opcao = "";
            RedeSocial redeSocial = null;
            string name, email, password;

            while (true)
            {
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1. Nova conta:");
                Console.WriteLine("2. Entrar:");
                Console.WriteLine("3. Esqueceu a senha, cadastre uma nova:");
                Console.WriteLine("4. Sair");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarNovaConta(out redeSocial, out name, out email, out password);
                        break;

                    case "2":
                        if (redeSocial != null)
                        {
                            Console.WriteLine("Informe suas credenciais para entrar:");
                            Console.WriteLine("E-mail");
                            email = Console.ReadLine();
                            Console.WriteLine("Senha:");
                            password = Console.ReadLine();

                            if (redeSocial.Email == email && redeSocial.Password == password)
                            {
                                Console.WriteLine("Entrou com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Credenciais incorretas.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Por favor, crie uma conta primeiro.");
                        }
                        break;

                    case "3":
                        if (redeSocial != null)
                        {
                            Console.WriteLine("Informe seu e-mail para redefinir a senha:");
                            var enteredEmail = Console.ReadLine();

                            if (redeSocial.Email == enteredEmail)
                            {
                                Console.WriteLine("Informe a nova senha:");
                                var newPassword = Console.ReadLine();

                                redeSocial.Password = newPassword;

                                Console.WriteLine("Senha redefinida com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("E-mail não encontrado. Por favor, verifique o e-mail informado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Por favor, crie uma conta primeiro.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Saindo...");
                        Environment.Exit(0); // Encerrar o programa
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }
                        if (redeSocial != null && opcao == "2")
                        {
                            Console.WriteLine("Opções disponíveis após entrar na rede:");
                            Console.WriteLine("5. Enviar mensagem");
                            Console.WriteLine("6. Postar comentário");
                            Console.WriteLine("7. Procurar usuários");
                            Console.WriteLine("8. Sair da conta");

                            opcao = Console.ReadLine();

                            if (opcao == "5")
                            {
                                Console.WriteLine("Digite o destinatário:");
                                var recipient = Console.ReadLine();
                                Console.WriteLine("Digite a mensagem:");
                                var message = Console.ReadLine();
                                Console.WriteLine(redeSocial.SendMessages(recipient, message));
                        }
                            else if (opcao == "6")
                            {
                                Console.WriteLine("Digite o ID do post:");
                                var postId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Digite o texto do comentário:");
                                var commentText = Console.ReadLine();
                                Console.WriteLine(redeSocial.PostComment(postId, commentText));
                    }
                            else if (opcao == "7")
                            {
                                Console.WriteLine("Digite o termo de pesquisa:");
                                var searchTerm = Console.ReadLine();
                                Console.WriteLine(redeSocial.SearchUsers(searchTerm));
                    }
                            else if (opcao == "8")
                            {
                                redeSocial = null;
                                Console.WriteLine("Você saiu da conta.");
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                            }
                        }
                }
            }

        private static void CadastrarNovaConta(out RedeSocial redeSocial, out string name, out string email, out string password)
        {
            Console.WriteLine("Para cadastrar nova conta informe:");
            Console.WriteLine("Nome:");
            name = Console.ReadLine();
            Console.WriteLine("E-mail:");
            email = Console.ReadLine();
            Console.WriteLine("Senha:");
            password = Console.ReadLine();
            redeSocial = new RedeSocial(name, "", "", "", email, password);
            Console.WriteLine(redeSocial.CreateUserAccount());
        }
    }
    }

