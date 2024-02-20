using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte02_Ex._02
{
    internal class LojaVirtual
    {
        private List<ProdutoComum> carrinho = new List<ProdutoComum>();

        public void CadastrarProduto(ProdutoComum produto)
        {
            carrinho.Add(produto);
            Console.WriteLine($"Produto '{produto.Nome}' cadastrado com sucesso!");
        }

        public void AdicionarAoCarrinho(ProdutoComum produto)
        {
            carrinho.Add(produto);
            Console.WriteLine($"Produto '{produto.Nome}' adicionado ao carrinho.");
        }

        public void GerarCarrinho()
        {
            Console.WriteLine("Carrinho de Compra:");
            foreach (ProdutoComum produto in carrinho)
            {
                Console.WriteLine($"Produto: {produto.Nome}, Valor: R$ {produto.Valor}");
            }
        }

        public void AplicarDesconto(int percentualDesconto)
        {
            foreach (ProdutoComum produto in carrinho)
            {
                produto.AplicarDesconto(percentualDesconto);
            }
            Console.WriteLine($"Desconto de {percentualDesconto}% aplicado a todos os produtos.");
        }

        public int CalcularValorTotalCompra()
        {
            int total = 0;
            foreach (ProdutoComum produto in carrinho)
            {
                total += produto.Valor;
            }
            return total;
        }

        public ProdutoComum PesquisarProduto(string nomeProduto)
        {
            foreach (ProdutoComum produto in carrinho)
            {
                if (produto.Nome.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase))
                {
                    return produto;
                }
            }
            return null; // Retorna null se o produto não for encontrado
        }
    }
}