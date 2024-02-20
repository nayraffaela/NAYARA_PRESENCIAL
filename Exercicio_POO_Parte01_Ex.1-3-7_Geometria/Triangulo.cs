using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte01_Ex._1_3_7_Geometria
{
    internal class Triangulo
    {
        private double _ladoA;
        private double _ladoB;
        private double _ladoC;
        public Triangulo(double ladoA, double ladoB, double ladoC)
        {
            _ladoA = ladoA;
            _ladoB = ladoB;
            _ladoC = ladoC;
        }
        public double calcularArea()
        {
            //calculo/fórmula de Herão:
            double semiperimetro = (_ladoA + _ladoB + _ladoC) / 2;
            return Math.Sqrt(semiperimetro * (semiperimetro - _ladoA) * (semiperimetro - _ladoB) * (semiperimetro - _ladoC));
        }
        public bool valido()
        {
            return _ladoA + _ladoB > _ladoC && _ladoA + _ladoC > _ladoB && _ladoB + _ladoC > _ladoA;

        }

    }
}
    

