namespace ExerciciosPOO_02_SistemaHotel
{
    internal class Reserva
    {
        public Pessoa Pessoa { get; set; }
        public Suite Suite { get; set; }
        public DateTime DataInicioReserva { get; set; }
        public DateTime DataFimReserva { get; set; }
        public int QntQuartos { get; set; }
        public decimal ValorReserva { get; set; } // Adicionando a propriedade ValorDiaria

        private Reserva() { }

        public override string ToString()
        {
            return $"Hospede: {Pessoa}\nSuite: {Suite}\nDataInicio: {DataInicioReserva.ToString("dd-MM-yyyy hh:mm")}\nDataFim: {DataFimReserva.ToString("dd-MM-yyyy hh:mm")}\nValor Reserva: {ValorReserva}";
        }

        public string InformarCondicoesCancelamento()
        {
            return "Condições de cancelamento:\nCancele gratuitamente até 7 dias após o momento da reserva.\nApós este período será cobrado 75% da reserva.";
        }

        public static Reserva FazerReserva(Pessoa pessoa, Suite suite, DateTime dataInicio, DateTime dataFim, int qntQuartos)
        {
            var reserva = new Reserva();

            reserva.Pessoa = pessoa;
            reserva.Suite = suite;
            reserva.DataInicioReserva = dataInicio;
            reserva.DataFimReserva = dataFim;
            reserva.QntQuartos = qntQuartos;

            var quantidadeDias = (dataFim - dataInicio).Days;
            reserva.ValorReserva = suite.ValorDiaria * quantidadeDias;

            if (quantidadeDias > 10)
                reserva.ValorReserva = reserva.ValorReserva * 0.9m;

            return reserva;
        }
    }
}
