using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using API_FESTAJUNINA.Models;
using API_FESTAJUNINA.Repository;


namespace API_FESTAJUNINA.DAO
{
    public class PedidoDAO
    {
        private MySqlConnection _connection;

        public PedidoDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }
        
        public List<Pedidos> GetAll()
        {

            List<Pedidos> pedidos = new List<Pedidos>();
            string query = "SELECT * from pedido";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pedidos pedido = new Pedidos();
                        pedido.id_pedido = reader.GetInt32("id_pedido");
                        pedido.data = reader.GetDateTime("data");
                        pedido.validar_id_usuario = reader.GetInt32("validar_id_usuario");
                        pedido.total = reader.GetInt32("total");
                        pedido.forma_pagamento = reader.GetString("forma_pagamento");
                        pedidos.Add(pedido);

                    }
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"erro do BANCO: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"erro desconhecido: {ex.Message}");

            }
            finally
            {
                _connection.Close();
            }

            return pedidos;

        }
        public Pedidos GetId(int id)
        {
            Pedidos pedido = new Pedidos();
            string guery = $"SELECT * FROM pedido Where id_pedido = {id}";
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(guery, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pedido.id_pedido = reader.GetInt32("id_pedido");
                        pedido.data = reader.GetDateTime("data");
                        pedido.validar_id_usuario = reader.GetInt32("validar_id_usuario");
                        pedido.total = reader.GetInt32("total");
                        pedido.forma_pagamento = reader.GetString("forma_pagamento");

                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"erro do BANCO: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"erro do BANCO: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
            return pedido;
        }
     
        public void AtualizarPedido(int id, Pedidos pedido)
        {
            string query = "UPDATE pedido SET " +
            "total=@total, " +
            "quantidade=@quantidade, " +
            "status=@status, " +
            "validar_id_usuario=@validar_id_ususario," +
            "forma_pagamento=@forma_pagamento," +
            "data=@data" +
            "WHERE id_pedido=@id_pedido";

            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {

                    command.Parameters.AddWithValue("@id_pedido", id);
                    command.Parameters.AddWithValue("@forma_pagamento", pedido.forma_pagamento);
                    command.Parameters.AddWithValue("@data", pedido.data);
                    command.Parameters.AddWithValue("@total", pedido.total);
                    command.Parameters.AddWithValue("@quantidade", pedido.quantidade);
                    command.Parameters.AddWithValue("@validar_id_usuario", pedido.validar_id_usuario);
                    command.Parameters.AddWithValue("@status", pedido.status);
                    command.ExecuteNonQuery();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"erro do BANCO: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"erro do BANCO: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

        }

        public void DeletarPedido(int id)
        {
            string query = "DELETE FROM personagem Where id_pedido = @id_pedido";

            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@id_pedido", id);
                    command.ExecuteNonQuery();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"erro do BANCO: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"erro do BANCO: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        public void FazerPedido(Pedidos pedido)
            {
                string query = "INSERT INTO pedido (forma_pagamento,data, total, quantidade, validar_id_usuario ,tipo, status)" +
                            "VALUES (@forma_pagamento, @data, @total,@quantidade, @validar_id_usuario, @tipo, @status)";

                try
                {
                    _connection.Open();
                    using (var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@nome", pedido.data);
                        command.Parameters.AddWithValue("@total", pedido.total);
                        command.Parameters.AddWithValue("@quantidade", pedido.quantidade);
                        command.Parameters.AddWithValue("@forma_pagamento", pedido.forma_pagamento);
                        command.Parameters.AddWithValue("@validar_id_usuario", pedido.validar_id_usuario);
                        command.Parameters.AddWithValue("@status", pedido.status);
                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"erro do BANCO: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"erro do BANCO: {ex.Message}");
                }
                finally
                {
                    _connection.Close();
                }


            }

    }

}