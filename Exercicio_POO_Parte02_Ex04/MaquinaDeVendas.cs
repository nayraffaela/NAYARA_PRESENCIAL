using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte02_Ex04
{
    public class MaquinaDeVendas
    {
        private Dictionary<string, double> estoque;
        private double dinheiroInserido;

        public MaquinaDeVendas()
        {
            estoque = new Dictionary<string, double>();
            dinheiroInserido = 0;
        }

        public void CadastrarProduto(string nome, double preco)
        {
            estoque.Add(nome, preco);
        }

        public double SelecionarProduto(string nome)
        {
            if (estoque.ContainsKey(nome))
            {
                return estoque[nome];
            }
            else
            {
                return -1; // Produto não encontrado
            }
        }

        public void InserirDinheiro(double valor)
        {
            dinheiroInserido += valor;
        }

        public double DarTroco(double precoProduto)
        {
            if (dinheiroInserido >= precoProduto)
            {
                double troco = dinheiroInserido - precoProduto;
                dinheiroInserido = 0;
                return troco;
            }
            else
            {
                Console.WriteLine("Dinheiro inserido insuficiente.");
                return 0;
            }
        }
    }
}