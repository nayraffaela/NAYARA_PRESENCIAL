using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte02_Ex._05_e_09
{
    internal class Baralho
    {
        private List<JogoCartas> cartas;

        public Baralho()
        {
            InicializarBaralho();
        }

        private void InicializarBaralho()
        {
            cartas = new List<JogoCartas>();

            string[] naipes = { "Paus", "Ouro", "Copas", "Espadas" };
            string[] valores = { "Ás", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez", "Valete", "Dama", "Rei" };

            foreach (var naipe in naipes) 
            {
                foreach (var valor in valores)
                {
                    cartas.Add(new JogoCartas(valor,naipe));
                }
            }
        }
        public void Embaralhar()
        {
            Random random = new Random();
            cartas = cartas.OrderBy(x => random.Next()).ToList();
        }
        public List<JogoCartas> Distribuir(int quantidade)
        { 
            List<JogoCartas> mao = new List<JogoCartas>();

            if (quantidade <= cartas.Count)
            {
                mao = cartas.GetRange(0,quantidade);
                cartas.RemoveRange(0, quantidade);
            }
            return mao;
        }
    }
}
