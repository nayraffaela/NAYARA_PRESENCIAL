namespace ExerciciosPOO_02_SistemaHotel
{
    public class Pessoa
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string Genero { get; private set; }
        public string Profissao { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string ContatoEmergencia { get; private set; }

        public Pessoa(string nome, int idade, string genero, string profissao, string email, string telefone, string contatoEmergencia)
        {
            Nome = nome;
            Idade = idade;
            Genero = genero;
            Profissao = profissao;
            Email = email;
            Telefone = telefone;
            ContatoEmergencia = contatoEmergencia;
        }

        public void AtualizarInformacoes(string nome, int idade, string genero, string profissao, string email, string telefone, string contatoEmergencia)
        {
            Nome = nome;
            Idade = idade;
            Genero = genero;
            Profissao = profissao;
            Email = email;
            Telefone = telefone;
            ContatoEmergencia = contatoEmergencia;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Idade: {Idade}, Gênero: {Genero}, Profissão: {Profissao}, Email: {Email}, Telefone: {Telefone}, Contato de Emergência: {ContatoEmergencia}";
        }
       
    }
}