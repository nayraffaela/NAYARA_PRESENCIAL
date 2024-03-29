namespace Projeto_BancoConsole1
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca()
        {
            Tipo = TipoConta.Poupanca;
            Saldo = 0;
            Numero = Math.Round(new Random().NextDouble(), 8).ToString();
        }
        public decimal taxaRendimento { get; set; }

        public override void Transferir(decimal quantia)
        {
            if (quantia <= 0)
            {
                throw new ArgumentException("A quantia a ser transferida deve ser maior que zero.");
            }

            if (quantia > Saldo)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar a transferência.");
            }

            Saldo -= quantia;
            // Lógica para realizar a transferência
        }

        public override void Depositar(decimal quantia)
        {
            if (quantia <= 0)
            {
                throw new ArgumentException("A quantia a ser depositada deve ser maior que zero.");
            }

            Saldo += quantia;
            // Lógica para realizar o depósito
        }


        public decimal AcrescentarRendimento()
        {
            Saldo = Saldo + (Saldo * taxaRendimento);
            return Saldo;
        }
    }
}