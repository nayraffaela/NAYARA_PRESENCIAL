using Microsoft.Data.SqlClient;
using Projeto_BancoConsole1.Models;
using System.Drawing;

public class ClienteRepository
{
    private readonly string connectionString;

    public ClienteRepository(string connectionString) //construtor recebe string conexão BD
    {
        this.connectionString = connectionString;
    }

    public void AddCliente(Cliente cliente) //mts de add novo cliente ao BD
    {
        using (var connection = new SqlConnection(connectionString)) //abrir conexão
        {
            connection.Open();
            using (var command = connection.CreateCommand())//criar comando slq p/input dados na Tab cliente
            {
                command.CommandText = @"INSERT INTO Cliente (cpf, senha, nome, dataNascimento)
                                        VALUES (@cpf, @senha, @nome, @dataNascimento); SELECT CONVERT(BIGINT, SCOPE_IDENTITY())";
                command.Parameters.AddWithValue("@cpf", cliente.Cpf);
                command.Parameters.AddWithValue("@senha", cliente.Senha);
                command.Parameters.AddWithValue("@nome", cliente.Nome);
                command.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);

                long clienteId = Convert.ToInt64(command.ExecuteScalar()); //execução do comando e obtemos o ID do cliente recem criado

                cliente.Id = clienteId; //atualização do ID do cliente com o ID criado recente
                Console.WriteLine("Inserção de cliente concluída com sucesso.");
            }
        }
    }

    public Cliente GetClienteByCpf(string cpf) //mtd qe obtem um cliente do BD pelo id
    {
        Cliente cliente = null;

        using (var connection = new SqlConnection(connectionString)) //ABRINDO conexão com BD
        {
            connection.Open();
            using (var command = connection.CreateCommand()) //criar comendo SQL p/seleção de dados do cliente pelo ID
            {
                command.CommandText = "SELECT * FROM Cliente WHERE cpf = @cpf";
                command.Parameters.AddWithValue("@cpf", cpf);

                using (var reader = command.ExecuteReader()) //executa comando sql e le os dados do cliente
                {
                    if (reader.Read())
                    {
                        cliente = new Cliente //retorna um novo objt Cliente com os dados lidos do BD
                        {
                            Id = (long)reader["id"],
                            Cpf = reader["cpf"].ToString(),
                            Senha = reader["senha"].ToString(),
                            Nome = reader["nome"].ToString(),
                            DataNascimento = (DateTime)reader["dataNascimento"],
                        };
                    }
                }
            }
        }

        if (cliente == null) return cliente;

        var conta = GetContaByCliente(cliente);
        cliente.Conta = conta;
        conta.Cliente = cliente;

        return cliente;
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

                command.ExecuteNonQuery();//execução do comando sql p/update dados clientes
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

                command.ExecuteNonQuery(); //execução do comando sql p/delete cliente
            }
        }
    }

    public Conta GetContaByCliente(Cliente cliente) //Método p/ conta do banco pelo id
    {
        Conta conta = null;

        using (var connection = new SqlConnection(connectionString)) //conexão BD
        {
            connection.Open();

            using (var command = connection.CreateCommand()) //comando sql p/selecionar dados com base ID
            {
                command.CommandText = "SELECT * FROM Conta WHERE clienteId = @id";
                command.Parameters.AddWithValue("@id", cliente.Id);

                using (var reader = command.ExecuteReader()) //Executa o SQL e le os dados
                {
                    if (reader.Read())
                    {
                        conta = ContaRepository.LerConta(reader);
                    }
                }
            }
        }
        return conta;
    }

    public List<Cliente> GetAllClientes() //mtd p/obter lista de clientes
    {
        List<Cliente> clientes = new List<Cliente>();

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand()) //cria slq p/selecionar all clientes da TAB Cliente
            {
                command.CommandText = "SELECT * FROM Cliente";

                using (var reader = command.ExecuteReader()) //executa comando slq e le dados all clientes
                {
                    while (reader.Read()) //eqnt houver dados a ler, criar objetos Cliente correspondente
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