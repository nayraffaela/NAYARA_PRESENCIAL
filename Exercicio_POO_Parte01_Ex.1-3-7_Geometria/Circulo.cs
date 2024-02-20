using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte01_Ex._1_3_7_Geometria
{
    internal class Circulo
    {
        public Circulo(double raio)
        {
            _raio = raio;
        }
        //declara uma váriavel de instância privada de nome _raio;
        private double _raio;
        public double Raio
        {
            get { return _raio; }
            set { _raio = value; }
        }

        public double CalcularArea()
        {
            // Método para calcular a área do círculo
            return Math.PI * Math.Pow(_raio, 2);
        }

        // Método para calcular o perímetro (circunferência) do círculo
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * _raio;
        }
    }
}


      