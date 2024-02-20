using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte01.Ex08
{
    internal class Carro
    {
        public string Marca {get; set;}
        public string Modelo { get; set;}
        public int VelocidadeCarro { get; private set;}

        public Carro(string marca, string modelo, int velocidadeCarro)
        {
            Marca = marca;
            Modelo = modelo;
            VelocidadeCarro = velocidadeCarro;
        }

        public int AcelerarCarro(int aumentoVelocidade)
        {
            return VelocidadeCarro += aumentoVelocidade;
        }
        public int FrearCarro(int diminuirVelocidade)
        {
            VelocidadeCarro -= diminuirVelocidade;
            if (VelocidadeCarro < 0)
            {
                VelocidadeCarro = 0;
            }
            return VelocidadeCarro;
        }
        public int ExibirVelocidadeCarro()
        {
            return VelocidadeCarro;
        }
    }
}
