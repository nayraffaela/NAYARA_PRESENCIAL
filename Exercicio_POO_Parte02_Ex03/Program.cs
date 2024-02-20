using static Exercicio_POO_Parte02_Ex03.Agenda;

namespace Exercicio_POO_Parte02_Ex03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var escolha = "";
            var agenda = new Agenda(new List<Agenda.Contato>(), 1, "", "");

            while (escolha != "7")
            {
                Console.WriteLine("Escolha a opção desejada:");
                Console.WriteLine("1. Cadastrar contato novo.");
                Console.WriteLine("2. Ver contatos.");
                Console.WriteLine("3. Bloquear contato.");
                Console.WriteLine("4. Contatos bloqueados.");
                Console.WriteLine("5. Editar número de contato.");
                Console.WriteLine("6. Buscar contato.");
                Console.WriteLine("7. Sair da agenda");
                escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.WriteLine("Digite as informações abaixo para cadastrar novo contato.");
                        CadastrarContato();
                        break;

                    case "2":
                        Console.WriteLine("Lista de contatos:");
                        VerListaContatos(agenda);
                        break;

                    case "3":
                        Console.WriteLine("Informe o contato que deseja bloquear.");
                        InformarBloqueio(agenda);
                        break;

                    case "4":
                        Console.WriteLine("Contatos bloqueados:");
                        VerListaBloqueio(agenda);
                        break;

                    case "5":
                        Console.WriteLine("Digite o nome do contato para editar:");
                        string nomeContatoEditar = Console.ReadLine();
                        Console.WriteLine("Digite o novo número:");
                        string novoNumero = Console.ReadLine();
                        string resultadoEdicao = agenda.EditarNumero(nomeContatoEditar, novoNumero);
                        Console.WriteLine(resultadoEdicao);
                        break;

                    case "6":
                        Console.WriteLine("Digite o termo de busca:");
                        string termoBusca = Console.ReadLine();
                        Console.WriteLine("Escolha o tipo de busca (1 - Por Nome, 2 - Por Número):");
                        int tipoBuscaInt = int.Parse(Console.ReadLine());
                        TipoBusca tipoBusca = (TipoBusca)tipoBuscaInt;
                        List<Agenda.Contato> contatosEncontrados = agenda.BuscarContato(termoBusca, tipoBusca);
                        MostrarContatosEncontrados(contatosEncontrados);
                        break;

                    case "7":
                        Console.WriteLine("Saindo da agenda...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
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


        private static void VerListaBloqueio(Agenda agenda)
        {
            var contatosBloqueados = agenda.Contatos.Where(c => c.Bloqueado).ToList();
            if (contatosBloqueados.Count == 0)
            {
                Console.WriteLine("Nenhum contato bloqueado.");
            }
            else
            {
                foreach (var contato in contatosBloqueados)
                {
                    Console.WriteLine($"Nome: {contato.Nome}, Telefone: {contato.Numero}");
                }
            }
        }

        private static void InformarBloqueio(Agenda agenda)
        {
            string nomeContato = Console.ReadLine();
            var contatoParaBloquear = agenda.Contatos.FirstOrDefault(c => c.Nome == nomeContato);
            if (contatoParaBloquear != null)
            {
                contatoParaBloquear.Bloqueado = true;
                Console.WriteLine($"Contato '{nomeContato}' bloqueado com sucesso.");
            }
            else
            {
                Console.WriteLine($"Contato '{nomeContato}' não encontrado.");
            }
        }

        private static void VerListaContatos(Agenda agenda)
        {
            if (agenda.Contatos.Count == 0)
            {
                Console.WriteLine("Não há contatos cadastrados.");
            }
            else
            {
                foreach (var contato in agenda.Contatos)
                {
                    Console.WriteLine($"Nome: {contato.Nome}, Telefone: {contato.Numero}");
                }
            }
        }

        private static void CadastrarContato()
        {
            Console.WriteLine("Nome:");
            var nome = Console.ReadLine();
            Console.WriteLine("Telefone:");
            var numero = Console.ReadLine();
        }
        private static void MostrarContatosEncontrados(List<Agenda.Contato> contatos)
        {
            if (contatos.Count == 0)
            {
                Console.WriteLine("Nenhum contato encontrado.");
            }
            else
            {
                Console.WriteLine("Contatos encontrados:");
                foreach (var contato in contatos)
                {
                    Console.WriteLine($"Nome: {contato.Nome}, Telefone: {contato.Numero}");
                }
            }
        }
    }
}