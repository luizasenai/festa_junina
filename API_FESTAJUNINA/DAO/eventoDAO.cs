using api.Models;
using API_FESTAJUNINA.Repository;
using MySql.Data.MySqlClient;

namespace api.DAO;
 
public class EventoDao
{
    private readonly MySqlConnection _connection;
 
    public EventoDao()
    {
        _connection = MySqlConnectionFactory.GetConnection();
    }
 
    private static List<Evento?> ReadAll(MySqlCommand command)
    {
        var eventos = new List<Evento?>();
 
        using var reader = command.ExecuteReader();
        if (!reader.HasRows) return eventos;
        while (reader.Read())
        {
            var evento = new Evento
            {
                IdEvento = reader.GetInt32("id_evento"),
                ValorUnitario = reader.GetInt32("valor_unitario"),
                QuantidadeTotal = reader.GetInt32("quantidade_total"),
                Saldo = reader.GetInt32("saldo"),
                Descricao = reader.GetString("descricao"),
                DataEvento = reader.GetDateTime("data_evento"),
                ImagemUrl = reader.GetString("imagem_url"),
                Local = reader.GetString("local"),
                Ativo = reader.GetInt32("ativo")
            };
            eventos.Add(evento);
        }
 
        return eventos;
    }
 
    public List<Evento?> Read()
    {
        List<Evento?> eventos = null!;
 
        try
        {
            _connection.Open();
            const string query = "SELECT * FROM evento";
 
            var command = new MySqlCommand(query, _connection);
 
            eventos = ReadAll(command);
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro do Banco: {ex.Message} ");
        }
 
        catch (Exception ex)
        {
            Console.WriteLine($"Erro desconhecido{ex.Message}");
        }
 
        finally
        {
            _connection.Close();
        }
 
        return eventos;
    }
 
    public Evento? ReadById(int id)
    {
        Evento? evento = null!;
 
        try
        {
            _connection.Open();
            var query = "SELECT * FROM evento Where id_evento = @Id";
 
            var command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", id);
 
            evento = ReadAll(command).FirstOrDefault();
        }
 
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro do Banco: {ex.Message} ");
        }
 
        catch (Exception ex)
        {
            Console.WriteLine($"Erro desconhecido{ex.Message}");
        }
 
        finally
        {
            _connection.Close();
        }
 
        return evento;
    }
 
    public void Create(Evento evento)
    {
        try
        {
            _connection.Open();
            const string query = "INSERT INTO evento (valor_unitario, quantidade_total, saldo, descricao, data_evento, imagem_url, local, ativo) " +
                                 "VALUES(@ValorUnitario, @QuantidadeTotal, @Saldo, @Descricao, @DataEvento, @ImagemUrl, @Local, @Ativo)";
 
            using var command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", evento.IdEvento);
            command.Parameters.AddWithValue("@ValorUnitario", evento.ValorUnitario);
            command.Parameters.AddWithValue("@QuantidadeTotal", evento.QuantidadeTotal);
            command.Parameters.AddWithValue("@Saldo", evento.Saldo);
            command.Parameters.AddWithValue("@Descricao", evento.Descricao);
            command.Parameters.AddWithValue("@DataEvento", evento.DataEvento);
            command.Parameters.AddWithValue("@ImagemUrl", evento.ImagemUrl);
            command.Parameters.AddWithValue("@Local", evento.Local);
            command.Parameters.AddWithValue("@Ativo", evento.Ativo);
 
            command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro do Banco: {ex.Message} ");
        }
 
        catch (Exception ex)
        {
            Console.WriteLine($"Erro desconhecido{ex.Message}");
        }
 
        finally
        {
            _connection.Close();
        }
    }
 
    public void Update(int id, Evento evento)
    {
        try
        {
            _connection.Open();
            const string query = "UPDATE evento SET " +
                                 "valor_unitario = @ValorUnitario, " +
                                 "quantidade_total = @QuantidadeTotal, " +
                                 "saldo = @Saldo, " +
                                 "descricao = @Descricao, " +
                                 "data_evento = @DataEvento, " +
                                 "imagem_url = @ImagemUrl, " +
                                 "local = @Local, " +
                                 "ativo = @Ativo " +
                                 "WHERE id_evento = @Id";
 
            using var command = new MySqlCommand(query, _connection);
 
            command.Parameters.AddWithValue("@Id", evento.IdEvento);
            command.Parameters.AddWithValue("@ValorUnitario", evento.ValorUnitario);
            command.Parameters.AddWithValue("@QuantidadeTotal", evento.QuantidadeTotal);
            command.Parameters.AddWithValue("@Saldo", evento.Saldo);
            command.Parameters.AddWithValue("@Descricao", evento.Descricao);
            command.Parameters.AddWithValue("@DataEvento", evento.DataEvento);
            command.Parameters.AddWithValue("@ImagemUrl", evento.ImagemUrl);
            command.Parameters.AddWithValue("@Local", evento.Local);
            command.Parameters.AddWithValue("@Ativo", evento.Ativo);
 
            command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro do Banco: {ex.Message} ");
        }
 
        catch (Exception ex)
        {
            Console.WriteLine($"Erro desconhecido{ex.Message}");
        }
 
        finally
        {
            _connection.Close();
        }
    }
 
    public void Delete(int id)
    {
        try
        {
            _connection.Open();
            const string query = "DELETE FROM evento WHERE id_evento = @Id";
 
            using var command = new MySqlCommand(query, _connection);
 
            command.Parameters.AddWithValue(@"Id", id);
            command.ExecuteNonQuery();
        }
 
        catch (MySqlException ex)
        {
            Console.WriteLine($"Erro do Banco: {ex.Message} ");
        }
 
        catch (Exception ex)
        {
            Console.WriteLine($"Erro desconhecido{ex.Message}");
        }
        finally
        {
            _connection.Close();
        }
    }
}