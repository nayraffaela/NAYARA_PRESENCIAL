using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte02_Ex._09
{
    internal class JogoAdivinhacao
    {
        internal int SecretNumber { get; private set; }
        private Random random { get; set; }
        public JogoAdivinhacao()
        {
            random = new Random();
            SecretNumber = random.Next(1, 101);
        }
        public void GerarNumeroAleatorio()
        {
            SecretNumber = random.Next(1, 101);
        }

        public void FazerPalpite(int palpite)
        {
            if (palpite == SecretNumber)
            {
                Console.WriteLine("Parabéns! Você acertou o número secreto!");
            }
            else if (palpite < SecretNumber)
            {
                Console.WriteLine("O número secreto é maior que o seu palpite.");
            }
            else
            {
                Console.WriteLine("O número secreto é menor que o seu palpite.");
            }
        }
    }
}

       
