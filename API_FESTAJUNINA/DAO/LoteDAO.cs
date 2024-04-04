using System;
using System.Collections.Generic;
using System.Linq;
using API_FESTAJUNINA.Models;
using API_FESTAJUNINA.Repository;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
 
namespace API_FESTAJUNINA.DAO
{
    public class LoteDAO
    {
        private MySqlConnection _connection;
 
        public LoteDAO()
            {
                _connection = MySqlConnectionFactory.GetConnection();
            }
 
            public List<Lote> GetAll()
            {
                List<Lote> lotes= new List<Lote>();
                string query = "SELECT * FROM lotes";
 
 
                try
                {
                    _connection.Open();
                    MySqlCommand command = new MySqlCommand(query, _connection);
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Lote lote = new Lote();
                            lote.idlote = reader.GetInt32("id_lotes");
                            lote.Descricao = reader.GetString("descricao");
                            lote.ValorUnitario = reader.GetDouble("valor_unitario");
                            lote.QuantidadeTotal = reader.GetInt32("quantidade_total");
                            lote.Saldo = reader.GetInt32("saldo");
                            lote.Ativo = reader.GetBoolean("ativo");
                            lote.IdEvento = reader.GetInt32("evento_id_evento");
                            lotes.Add(lote);
                        }
                    }
                }
                catch(MySqlException ex)
                {
                    //mapeando os erros do banco
                    Console.WriteLine($"Erro do BANCO: {ex.Message}");
                }
                catch(Exception ex)
                {
                    //mapenado os erros de forma geral
                    Console.WriteLine($"Erro Desconhecido {ex.Message}");
                }
                finally
                {
                    //fecha a conexão com o banco
                    _connection.Close();
                }
 
                return lotes;
            }
 
                public Lote GetId(int id)
                {
                    Lote lote = new Lote();
                    string query = $"SELECT * FROM lotes WHERE id_lotes = {id}";
                    try
                    {
                        _connection.Open();
                        MySqlCommand command = new MySqlCommand(query, _connection);
                        using(MySqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                Lote lote1 = new Lote();
                                lote.idlote = reader.GetInt32("id_lotes");
                                lote.Descricao = reader.GetString("descricao");
                                lote.ValorUnitario = reader.GetDouble("valor_unitario");
                                lote.QuantidadeTotal = reader.GetInt32("quantidade_total");
                                lote.Saldo = reader.GetInt32("saldo");
                                lote.Ativo = reader.GetBoolean("ativo");
                                lote.IdEvento = reader.GetInt32("evento_id_evento");
                               
                               
                               
                            }
                        }
                    }
                    catch(MySqlException ex)
                    {
                        Console.WriteLine($"Erro no Banco: {ex.Message}");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Erro Desconhecido: {ex.Message}");
                    }
                    finally
                    {
                        _connection.Close();
                    }
                    return lote;
                }
 
                public void CriarLote(Lote lote)
                {
                    string query = "INSERT INTO lotes (descricao,valor_unitario,quantidade_total,saldo,ativo,evento_id_evento ) VALUES (@Descricao,@ValorUnitario, @QuantidadeTotal, @Saldo, @Ativo, @IdEvento)";
                   
 
 
                    try
                    {
                        _connection.Open();
                        using(var command = new MySqlCommand(query, _connection))
                        {
                            command.Parameters.AddWithValue("@Descricao", lote.Descricao);
                            command.Parameters.AddWithValue("@ValorUnitario", lote.ValorUnitario);
                            command.Parameters.AddWithValue("@QuantidadeTotal", lote.QuantidadeTotal);
                            command.Parameters.AddWithValue("@Saldo", lote.Saldo);
                            command.Parameters.AddWithValue("@Ativo", lote.Ativo);
                            command.Parameters.AddWithValue("@IdEvento", lote.IdEvento);
                           
                         
                            command.ExecuteNonQuery();
                        }
                    }
                    catch(MySqlException ex)
                    {
                        Console.WriteLine($"Erro de Banco: {ex.Message}");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Erro Desconhecido: {ex.Message}");
                    }
                    finally
                    {
                        _connection.Close();
                    }
 
                }
 
            public void AtualizarLote(int id, Lote lote)
            {
                string query = "UPDATE lotes SET " +
                                " descricao = @Descricao, " +
                                " valor_unitario = @ValorUnitario, " +
                                " quantidade_total = @QuantidadeTotal, " +
                                " saldo = @Saldo, " +  
                                " ativo = @Ativo, " +
                                " evento_id_evento = @IdEvento " +
                                " WHERE id_lotes = @IdLote"
                                 ;
                       
 
                try
                {
                   
                   _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                       
                    {       command.Parameters.AddWithValue("@IdLote", id);
                            command.Parameters.AddWithValue("@Descricao", lote.Descricao);
                            command.Parameters.AddWithValue("@ValorUnitario", lote.ValorUnitario);
                            command.Parameters.AddWithValue("@QuantidadeTotal", lote.QuantidadeTotal);
                            command.Parameters.AddWithValue("@Saldo", lote.Saldo);
                            command.Parameters.AddWithValue("@Ativo", lote.Ativo);
                            command.Parameters.AddWithValue("@IdEvento", lote.IdEvento);
 
                            command.ExecuteNonQuery();
                    }
                }
                catch(MySqlException ex)
                {
                     Console.WriteLine($"Erro de Banco: {ex.Message}");
                }
                catch(Exception ex)
                {
                     Console.WriteLine($"Erro de Banco: {ex.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }
 
            public void DeletarLote (int id)
            {
                string query = "DELETE FROM lotes WHERE id_lotes = @IdLote";
 
                try
                {
                    _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@IdLote", id);
                        command.ExecuteNonQuery();
                    }
                }
               
                catch(MySqlException ex)
                {
                     Console.WriteLine($"Erro de Banco: {ex.Message}");
                }
                catch(Exception ex)
                {
                     Console.WriteLine($"Erro de Banco: {ex.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }
 
    }
}
 
 
 