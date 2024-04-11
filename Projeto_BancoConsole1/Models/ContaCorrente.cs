namespace Projeto_BancoConsole1.Models
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            Tipo = TipoConta.Corrente;
            Saldo = 0;
            Numero = Math.Round(new Random().NextDouble(), 8).ToString();
        }

        public static ContaCorrente Create(long id, decimal saldo, string numero, decimal taxa)
        {
           var conta = new ContaCorrente();
            conta.Id = id;
            conta.Saldo = saldo;
            conta.Numero = numero;
            conta.taxaManutencao = taxa;

            return conta;
        }

        public decimal taxaManutencao { get; set; }

        public override void Transferir(decimal quantia) //metd
        {
            if (quantia <= 0)
            {
                throw new ArgumentException("A quantia a ser transferida deve ser maior que zero.");
            }

            if (Saldo < quantia)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar a transferência.");
            }

            Saldo -= quantia; //dedução

        }
        public override void Depositar(decimal quantia)
        {
            if (quantia <= 0)
            {
                throw new ArgumentException("A quantia a ser depositada deve ser maior que zero.");
            }

            Saldo += quantia;

        }
        public decimal DescontarTaxa() //metd
        {
            Saldo = Saldo - Saldo * taxaManutencao;
            return Saldo;
        }
    }
}
