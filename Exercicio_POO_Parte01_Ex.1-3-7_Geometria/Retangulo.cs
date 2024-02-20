using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte01_Ex._1_3_7_Geometria
{
    internal class Retangulo
    {
        private double _altura;
        private double _largura;
        public Retangulo(double altura, double largura)
        {
            _altura = altura;
            _largura = largura;
        }
        public double calcularArea()
        { return _largura * _altura; }

        public double calcularPerimetro()
        { return 2 * (_largura + _altura); }
    }
}
    