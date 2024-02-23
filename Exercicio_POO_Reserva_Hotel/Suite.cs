namespace ExerciciosPOO_02_SistemaHotel
{
    internal class Suite
    {
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
        public string TipoQuarto { get; set; }
        public int NumeroQuarto { get; set; }

        public Suite(int capacidade, decimal valorDiaria, string tipoQuarto, int numeroQuarto)
        {
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
            TipoQuarto = tipoQuarto;
            NumeroQuarto = numeroQuarto;
        }

        public override string ToString()
        {
            return $"Numero quarto: {NumeroQuarto}, ValorDiaria: {ValorDiaria}, TipoQuarto: {TipoQuarto}, Capacidade: {Capacidade}";
        }
    }
}

      