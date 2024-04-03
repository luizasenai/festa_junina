using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using API_FESTAJUNINA.Models;
using API_FESTAJUNINA.Repository;
using MySql.Data.MySqlClient;


namespace API_FESTAJUNINA.DAO
{
    public class IngressoDAO
    {
        private MySqlConnection _connection;

        public IngressoDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }

        public List<Ingresso> GetAll()
        {
            List<Ingresso> ingressos = new List<Ingresso>();
            string query = "SELECT * FROM ingresso";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ingresso ingresso = new Ingresso();
                        ingresso.IdIngresso = reader.GetInt32("id_ingresso");
                        ingresso.Valor = reader.GetString("valor");
                        ingresso.Status = reader.GetString("status");
                        ingresso.Tipo = reader.GetString("tipo");
                        ingresso.CodigoQr = reader.GetString("codigo_qr");
                        ingresso.UsuarioPedido = reader.GetInt32("pedido_id_pedido");
                        ingresso.LotesId = reader.GetInt32("lotes_id_lotes");
                        ingressos.Add(ingresso);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro de banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro de banco: {ex.Message}");

            }
            finally
            {
                _connection.Close();
            }
            return ingressos;
        }
        public Ingresso GetId(int id)
        {
            Ingresso ingresso = new Ingresso();
            string query = $"select * from ingresso where id_ingresso = {id}";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ingresso.IdIngresso = reader.GetInt32("id_ingresso");
                        ingresso.Valor = reader.GetString("valor");
                        ingresso.Status = reader.GetString("status");
                        ingresso.Tipo = reader.GetString("tipo");
                        ingresso.CodigoQr = reader.GetString("codigo_qr");
                        ingresso.UsuarioPedido = reader.GetInt32("pedido_id_pedido");
                        ingresso.LotesId = reader.GetInt32("lotes_id_lotes");

                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro de Banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return ingresso;
        }

        public void CriarIngresso(Ingresso ingresso)
        {
            string query = "INSERT INTO ingresso (valor, status, tipo, codigo_qr,pedido_id_pedido, lotes_id_lotes)" +
                           "values (@Valor, @Status, @Tipo, @CodigoQr, @IdPedido, @LotesId)";

            Console.WriteLine(Guid.NewGuid());
            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@Valor", ingresso.Valor);
                    command.Parameters.AddWithValue("@Status", "RESERVADO");
                    command.Parameters.AddWithValue("@Tipo", ingresso.Tipo);
                    command.Parameters.AddWithValue("@CodigoQr", Guid.NewGuid().ToString());
                    command.Parameters.AddWithValue("@IdPedido", ingresso.UsuarioPedido);
                    command.Parameters.AddWithValue("@LotesId", ingresso.LotesId);
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro de Banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
        public void ValidarIngresso(int id, Ingresso ingresso)
        {
            string query = "UPDATE ingresso SET" +
                           "valor=@Valor," +
                           "status=@Status" +
                           "tipo=@Tipo," +
                           "codigo_qr=@CodigoQr" +
                           "WHERE id_ingresso=@IdIngresso";
            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@IdIngresso", ingresso.IdIngresso);
                    command.Parameters.AddWithValue("@Valor", ingresso.Valor);
                    command.Parameters.AddWithValue("@Status", "RESERVADO");
                    command.Parameters.AddWithValue("@Tipo", ingresso.Tipo);
                    command.Parameters.AddWithValue("@CodigoQr", Guid.NewGuid().ToString());
                    command.ExecuteNonQuery();
                }
            }

            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro de Banco: {ex.Message}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }

            finally
            {
                _connection.Close();
            }
        }
        public void DeletarIngresso(int id)
        {
            string query = "DELETE FROM ingresso WHERE id_ingresso = @IdIngresso";

            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@IdIngresso", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro de Banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }


    }
}