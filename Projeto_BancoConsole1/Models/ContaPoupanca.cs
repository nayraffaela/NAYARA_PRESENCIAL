namespace Projeto_BancoConsole1.Models
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca() //construtor
        {
            Tipo = TipoConta.Poupanca;
            Saldo = 0;
            Numero = Math.Round(new Random().NextDouble(), 8).ToString();//gera numero aleatório e o arredonda p/8 csas dec
        }
        public decimal taxaRendimento { get; set; }

        public override void Transferir(decimal quantia) //metdo
        {
            if (quantia <= 0)
            {
                throw new ArgumentException("A quantia a ser transferida deve ser maior que zero.");
            }

            if (quantia > Saldo)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar a transferência.");
            }

            Saldo -= quantia; //dedução da quantia 

        }

        public override void Depositar(decimal quantia)
        {
            if (quantia <= 0)
            {
                throw new ArgumentException("A quantia a ser depositada deve ser maior que zero.");
            }

            Saldo += quantia; //add quantia

        }


        public decimal AcrescentarRendimento() //metdo
        {
            Saldo = Saldo + Saldo * taxaRendimento;
            return Saldo;
        }

        public static Conta Create(long id, decimal saldo, string numero, decimal taxa)
        {
            var conta = new ContaPoupanca();
            conta.Id = id;
            conta.Saldo = saldo;
            conta.Numero = numero;
            conta.taxaRendimento = taxa;

            return conta;
        }
    }
}