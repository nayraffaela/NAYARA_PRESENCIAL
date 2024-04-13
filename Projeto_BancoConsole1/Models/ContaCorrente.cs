namespace Projeto_BancoConsole1.Models
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            Tipo = TipoConta.Corrente;
            taxaManutencao = 0.5m;
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


            DescontarTaxa(quantia); // Deduz a taxa de manutenção
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
        private void DescontarTaxa(decimal quantiaTransferida) //metd
        {
            decimal taxaDesconto;
            switch (Cliente.Tipo)
            {
                case TipoCliente.Comum:
                    taxaDesconto = quantiaTransferida * ( taxaManutencao + 0.1m); // 10% de desconto para clientes comuns
                    break;
                case TipoCliente.Super:
                    taxaDesconto = quantiaTransferida * (taxaManutencao + 0.05m); // 5% de desconto para clientes super
                    break;
                case TipoCliente.Premium:
                    taxaDesconto = quantiaTransferida * (taxaManutencao + 0.02m); // 2% de desconto para clientes premium
                    break;
                default:
                    taxaDesconto = 0; // Nenhum desconto padrão
                    break;
            }
            Saldo -= taxaDesconto;
        }
    }
}
