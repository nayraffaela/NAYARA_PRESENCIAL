namespace Exercicio_POO_Parte01_Ex06_Parte02_Ex02
{
    internal class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        private int _quantidadeEstoque { get; set; }

        public Produto(string nome, double preco, int estoqueInicial)
        {
            Nome = nome;
            Preco = preco;
            _quantidadeEstoque = estoqueInicial;
        }

        public void AdicionarEstoque(int quantidade)
        {
            _quantidadeEstoque = _quantidadeEstoque + quantidade;
        }

        public int CacularEstoque()
        { 
            return _quantidadeEstoque; 
        }

        public string VerificarDisponibilidade()
        {
            if (_quantidadeEstoque > 0)
            {
                return "Disponível";
            }
            else
            {
                return "Indisponível";
            }
        }
    }
}