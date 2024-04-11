using Microsoft.Data.SqlClient;
using Projeto_BancoConsole1.Models;

public class ClienteRepository
{
    private readonly string connectionString;

    public ClienteRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void AddCliente(Cliente cliente)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Cliente (cpf, senha, nome, dataNascimento)
                                        VALUES (@cpf, @senha, @nome, @dataNascimento); SELECT SCOPE_IDENTITY();";
                command.Parameters.AddWithValue("@cpf", cliente.Cpf);
                command.Parameters.AddWithValue("@senha", cliente.Senha);
                command.Parameters.AddWithValue("@nome", cliente.Nome);
                command.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);

                long clienteId = (long)command.ExecuteScalar();

                cliente.Id = clienteId;
            }
        }
    }

    public Cliente GetClienteById(long id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Cliente WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            Cpf = reader["cpf"].ToString(),
                            Senha = reader["senha"].ToString(),
                            Nome = reader["nome"].ToString(),
                            DataNascimento = (DateTime)reader["dataNascimento"],
                        };
                    }
                }
            }
        }
        return null;
    }

    public void UpdateCliente(Cliente cliente)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"UPDATE Cliente 
                                        SET cpf = @cpf, senha = @senha, nome = @nome, dataNascimento = @dataNascimento
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@cpf", cliente.Cpf);
                command.Parameters.AddWithValue("@senha", cliente.Senha);
                command.Parameters.AddWithValue("@nome", cliente.Nome);
                command.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
                command.Parameters.AddWithValue("@id", cliente.Id);

                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteCliente(long id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Cliente WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }

    public List<Cliente> GetAllClientes()
    {
        List<Cliente> clientes = new List<Cliente>();

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Cliente";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            Cpf = reader["cpf"].ToString(),
                            Senha = reader["senha"].ToString(),
                            Nome = reader["nome"].ToString(),
                            DataNascimento = (DateTime)reader["dataNascimento"],
                        });
                    }
                }
            }
        }

        return clientes;
    }
}