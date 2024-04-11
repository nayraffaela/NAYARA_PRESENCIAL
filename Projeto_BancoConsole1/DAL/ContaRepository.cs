using Microsoft.Data.SqlClient;
using Projeto_BancoConsole1.Models;

public class ContaRepository
{
    private readonly string connectionString;

    public ContaRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void CriarConta(Cliente cliente)
    {
        var conta = cliente.Conta;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Conta (numero, saldo, tipo, taxa, clienteId)
                                        VALUES (@numero, @saldo, @tipo, @taxa, @clienteId); SELECT SCOPE_IDENTITY();";
                
                command.Parameters.AddWithValue("@numero", conta.Numero);
                command.Parameters.AddWithValue("@saldo", conta.Saldo);
                command.Parameters.AddWithValue("@tipo", conta.Tipo);

                if(conta.Tipo == TipoConta.Poupanca)
                {
                    command.Parameters.AddWithValue("@taxa", ((ContaPoupanca)conta).taxaRendimento);
                }else
                {
                    command.Parameters.AddWithValue("@taxa", ((ContaCorrente)conta).taxaManutencao);
                }

                command.Parameters.AddWithValue("@clienteId", cliente.Id);

                long id = (long)command.ExecuteScalar();

                cliente.Id = id;
            }
        }
    }
    public Conta GetContaById(long id)
    {
        Conta conta = null;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
          
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Conta WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        conta = LerConta(id, reader);
                    }
                }
            }
        }
        return conta;
    }

    private static Conta LerConta(long id, SqlDataReader reader)
    {
        Conta conta;
        var tipoConta = reader["tipo"].ToString();
        var saldo = (decimal)reader["saldo"];
        var numero = reader["numero"].ToString();
        var taxa = (decimal)reader["taxa"];

        if (tipoConta == TipoConta.Poupanca.ToString())
        {
            conta = ContaCorrente.Create(id, saldo, numero, taxa);
        }
        else
        {
            conta = ContaPoupanca.Create(id, saldo, numero, taxa);
        }

        return conta;
    }

    public void UpdateConta(Cliente cliente)
    {
        var conta = cliente.Conta;
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"UPDATE Conta 
                                        SET numero = @numero, saldo = @saldo, tipo = @tipo, taxa = @taxa, clienteId = @clienteId
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

                command.Parameters.AddWithValue("@clienteId", cliente.Id);
                command.Parameters.AddWithValue("@id", conta.Id);

                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteConta(long id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Conta WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }

    public List<Conta> GetAllContas()
    {
        List<Conta> contas = new List<Conta>();

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Conta";

                using (var reader = command.ExecuteReader())
                {
                    var id = (long)reader["saldo"];
                    while (reader.Read())
                    {
                        contas.Add(LerConta(id, reader));
                    }
                }
            }
        }

        return contas;
    }
}