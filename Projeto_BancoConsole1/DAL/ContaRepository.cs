using Microsoft.Data.SqlClient;
using Projeto_BancoConsole1.Models;

public class ContaRepository
{
    private readonly string connectionString;

    public ContaRepository(string connectionString)//contrutor string
    {
        this.connectionString = connectionString;
    }

    public void CriarConta(Conta conta)//metodo p/nova conta no BD
    {
        using (var connection = new SqlConnection(connectionString)) //abrir conexão com BD
        {
            connection.Open(); //comando SQL p/ input de dados em CONTA
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Conta (numero, saldo, tipo, taxa, clienteId)
                                        VALUES (@numero, @saldo, @tipo, @taxa, @clienteId); SELECT SCOPE_IDENTITY();";
                
                command.Parameters.AddWithValue("@numero", conta.Numero);
                command.Parameters.AddWithValue("@saldo", conta.Saldo);
                command.Parameters.AddWithValue("@tipo", conta.Tipo);

                if(conta.Tipo == TipoConta.Poupanca) //compara tipoconta p/add
                {
                    command.Parameters.AddWithValue("@taxa", ((ContaPoupanca)conta).taxaRendimento);
                }else
                {
                    command.Parameters.AddWithValue("@taxa", ((ContaCorrente)conta).taxaManutencao);
                }

                command.Parameters.AddWithValue("@clienteId", conta.Cliente.Id);

                long id = Convert.ToInt64(command.ExecuteScalar()); //execução do comando sql e retorna o ID conta criado

                conta.Id = id; // atualização de ID da conta recente
            }
        }
    }
    public Conta GetContaByNumero(string numero) //Método p/ conta do banco pelo id
    {
        Conta conta = null;

        using (var connection = new SqlConnection(connectionString)) //conexão BD
        {
            connection.Open();
          
            using (var command = connection.CreateCommand()) //comando sql p/selecionar dados com base ID
            {
                command.CommandText = "SELECT * FROM Conta WHERE numero = @numero";
                command.Parameters.AddWithValue("@numero", numero);

                using (var reader = command.ExecuteReader()) //Executa o SQL e le os dados
                {
                    if (reader.Read())
                    {
                        conta = LerConta(reader);
                    }
                }
            }
        }
        return conta;
    }

    public static Conta LerConta(SqlDataReader reader) //metd auxiliar que le os dados da conta no BD
    {
        Conta conta;
        var id = (long)reader["id"];
        var tipoConta = reader["tipo"].ToString();
        var saldo = (decimal)reader["saldo"];
        var numero = reader["numero"].ToString();
        var taxa = (decimal)reader["taxa"];

        if (tipoConta == TipoConta.Poupanca.ToString("D"))
        {
            conta = ContaPoupanca.Create(id, saldo, numero, taxa);
        }
        else
        {
            conta = ContaCorrente.Create(id, saldo, numero, taxa);
        }

        return conta;
    }

    public void UpdateConta(Conta conta) //update de conta no BD
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"UPDATE Conta 
                                        SET numero = @numero, saldo = @saldo, tipo = @tipo, taxa = @taxa
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@numero", conta.Numero);
                command.Parameters.AddWithValue("@saldo", conta.Saldo);
                command.Parameters.AddWithValue("@tipo", conta.Tipo);

                if (conta.Tipo == TipoConta.Poupanca)
                {
                    command.Parameters.AddWithValue("@taxa", ((ContaPoupanca)conta).taxaRendimento);
                }
                else
                {
                    command.Parameters.AddWithValue("@taxa", ((ContaCorrente)conta).taxaManutencao);
                }

                command.Parameters.AddWithValue("@id", conta.Id);

                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteConta(long id) //mtd exclusão de conta do BD pelo ID
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Conta WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery(); //execução do comando
            }
        }
    }

    public List<Conta> GetAllContas() //mtd para ter todas as contas do BD
    {
        List<Conta> contas = new List<Conta>();

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand()) //criar o comando SQL para selecionar all contas da tbela "COnta"
            {
                command.CommandText = "SELECT * FROM Conta";

                using (var reader = command.ExecuteReader()) //Executa o comando e lê dados all cntas
                {
                    var id = (long)reader["saldo"];
                    while (reader.Read()) //enqnto tiver dados a serem lidos, criar objetos conta correspondente
                    {
                        contas.Add(LerConta(reader));
                    }
                }
            }
        }

        return contas;
    }
}