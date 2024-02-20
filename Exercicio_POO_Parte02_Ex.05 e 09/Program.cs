namespace Exercicio_POO_Parte02_Ex._05_e_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CincoCartas jogo = new CincoCartas();

            jogo.AdicionarJogador("Jogador 01");
            jogo.AdicionarJogador("Jogador 02");

            jogo.DistribuirCartas();
            Console.WriteLine();
            jogo.ExibirMaos();
            Console.WriteLine();

            bool jogoContinua = true;
            while (jogoContinua)
            {
                foreach (var jogador in jogo.jogadores)
                {
                    jogador.FazerJogada(jogo.baralho);
                }
                jogoContinua = false;
            }
            jogo.ExibirMaos();
            Console.WriteLine();
        }
    }
}

