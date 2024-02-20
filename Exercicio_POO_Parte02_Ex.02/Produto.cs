using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte02_Ex._02
{
    internal abstract class Produto
    {
        public string Nome { get; set; }
        public int Valor { get; set; }

        public Produto(string nome, int valor)
        {
            Nome = nome;
            Valor = valor;
        }

        // Método abstrato para aplicar desconto
        public abstract void AplicarDesconto(int percentualDesconto);
    }

    internal class ProdutoComum : Produto
    {
        public ProdutoComum(string nome, int valor) : base(nome, valor)
        {
        }

        // Implementação do método de aplicar desconto para produto comum
        public override void AplicarDesconto(int percentualDesconto)
        {
            Valor -= (Valor * percentualDesconto) / 100;
        }
    }
}