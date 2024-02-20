namespace Exercicio_POO_Parte02_Ex._09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JogoAdivinhacao jogo = new JogoAdivinhacao();

            Console.WriteLine("Vamos jogar o Jogo de Adivinhação!");

            while (true)
            {
                Console.Write("Digite seu palpite (entre 1 e 100): ");
                int palpite;
                if (!int.TryParse(Console.ReadLine(), out palpite) || palpite < 1 || palpite > 100)
                {
                    Console.WriteLine("Por favor, digite um número válido entre 1 e 100.");
                    continue;
                }

                jogo.FazerPalpite(palpite);
                if (palpite == jogo.SecretNumber)
                {
                    Console.WriteLine("Deseja jogar novamente? (s/n)");
                    if (Console.ReadLine().ToLower() != "s")
                        break;
                    else
                        jogo.GerarNumeroAleatorio();
                }
            }

            Console.WriteLine("Obrigado por jogar!");
        }
    }
}
