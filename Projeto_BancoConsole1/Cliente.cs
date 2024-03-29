namespace Projeto_BancoConsole1
{
    public class Cliente
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public TipoCliente Tipo => Conta.Saldo >= 15000 ? TipoCliente.Premium :
                        Conta.Saldo >= 5000 ? TipoCliente.Super : TipoCliente.Comum;
        public Conta Conta { get; set; }
    }
}
public enum TipoCliente
{
    Comum = 0,
    Super = 1,
    Premium = 2
}

