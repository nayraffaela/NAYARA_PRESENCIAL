using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte02_Ex._05_e_09
{
    internal class CincoCartas
    {
        public Baralho baralho;
        public List<Jogador> jogadores;
        public CincoCartas()
        {
            baralho = new Baralho();
            jogadores = new List<Jogador>();
        }
        public void AdicionarJogador(string nome)
        {
            jogadores.Add(new Jogador(nome));
        }

        public void DistribuirCartas()
        {
            baralho.Embaralhar();

            foreach (var jogador in jogadores)
            {
                jogador.ReceberCartas(baralho.Distribuir(5));
            }
        }
        public void ExibirMaos()
        {
            foreach (var jogador in jogadores)
            {
                Console.WriteLine($"{jogador.Nome}:");
                foreach (var carta in jogador.Mao)
                {
                    Console.WriteLine($"- {carta.Valor} de {carta.Naipe}");
                }
            }
        }
    }
}


