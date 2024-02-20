using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte02_Ex._05_e_09
{
    internal class JogoCartas
    {
        public string Valor { get; private set; }
        public string Naipe {  get; private set; }

        public JogoCartas(string valor, string naipe) 
        {
            Valor = valor;
            Naipe = naipe;  
        }


    }
}
