namespace Projeto_BancoConsole1.Models
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
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

