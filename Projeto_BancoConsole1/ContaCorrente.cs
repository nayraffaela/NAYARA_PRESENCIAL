namespace Projeto_BancoConsole1
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            Tipo = TipoConta.Corrente;
            Saldo = 0;
            Numero = Math.Round(new Random().NextDouble(), 8).ToString();
        }
        public decimal taxaManutencao { get; set; }

        public override void Transferir(decimal quantia)
        {
            if (quantia <= 0)
            {
                throw new ArgumentException("A quantia a ser transferida deve ser maior que zero.");
            }

            if (Saldo < quantia)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar a transferência.");
            }

            Saldo -= quantia;

        }
        public override void Depositar(decimal quantia)
        {
            if (quantia <= 0)
            {
                throw new ArgumentException("A quantia a ser depositada deve ser maior que zero.");
            }

            Saldo += quantia;

        }
        public decimal DescontarTaxa()
        {
            Saldo = Saldo - (Saldo * taxaManutencao);
            return Saldo;
        }
    }
}
