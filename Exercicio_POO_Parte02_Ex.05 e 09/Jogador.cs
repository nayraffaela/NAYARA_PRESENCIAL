using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte02_Ex._05_e_09
{
    internal class Jogador
    {
        public string Nome { get; private set; }
        public List<JogoCartas> Mao { get; private set; }

        public Jogador(string nome)
        {
            Nome = nome;
            Mao = new List<JogoCartas>();
        }

        public void ReceberCartas(List<JogoCartas> cartas)
        {
            Mao.AddRange(cartas);
        }
        public void FazerJogada(Baralho baralho)
        {
            Console.WriteLine($"{Nome}, é sua vez de jogar.");

            // Exibir a mão atual do jogador
            Console.WriteLine("Sua mão atual:");
            for (int i = 0; i < Mao.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Mao[i].Valor} de {Mao[i].Naipe}");
            }
            Console.WriteLine("Selecione o número das cartas que deseja descartar (separadas por vírgula) ou pressione Enter para passar a vez:");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                string[] indices = input.Split(',');
                List<int> cartasDescartadas = new List<int>();
                foreach (var indice in indices)
                {
                    if (int.TryParse(indice.Trim(), out int cartaIndex) && cartaIndex > 0 && cartaIndex <= Mao.Count)
                    {
                        cartasDescartadas.Add(cartaIndex - 1);
                    }
                }
                foreach (var cartaIndex in cartasDescartadas)
                {
                    if (cartaIndex < Mao.Count)
                    {
                        Mao.RemoveAt(cartaIndex);
                    }
                }

                int cartasParaDistribuir = cartasDescartadas.Count;
                Mao.AddRange(baralho.Distribuir(cartasParaDistribuir));
            }
            else
            {
                Console.WriteLine($"{Nome} passou a vez.");
            }
        }
    }
}




