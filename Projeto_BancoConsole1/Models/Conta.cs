namespace Projeto_BancoConsole1.Models
{
    public abstract class Conta
    {
        public long Id { get; set; }
        public string Numero { get; protected set; }
        public decimal Saldo { get; protected set; }
        public TipoConta Tipo { get; protected set; }
        public Cliente Cliente { get; set; }

        public Conta() //contrutor
        {
            Saldo = 0;
            Numero = Guid.NewGuid().ToString().Split("-").Last();
        }
        public abstract void Transferir(decimal quantia);
        public abstract void Depositar(decimal quantia);
    }

    public enum TipoConta
    {
        Corrente = 0,
        Poupanca = 1
    }
}