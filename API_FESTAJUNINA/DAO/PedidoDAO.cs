using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using API_FESTAJUNINA.Models;
using API_FESTAJUNINA.Repository;
using System.Data;


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
                        pedido.total = reader.GetInt32("total");
                        pedido.quantidade = reader.GetInt32("quantidade");
                        pedido.forma_pagamento = reader.GetString("forma_pagamento");
                        pedido.status = reader.GetString("status");
                        pedido.validacao_id_usuario = reader.IsDBNull("validacao_id_usuario") ? 0 : reader.GetInt32("validacao_id_usuario");
                        pedido.usuario_id_usuario = reader.GetInt32("usuario_id_usuario");
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
                        pedido.total = reader.GetInt32("total");
                        pedido.quantidade = reader.GetInt32("quantidade");
                        pedido.forma_pagamento = reader.GetString("forma_pagamento");
                        pedido.status = reader.GetString("status");
                        pedido.validacao_id_usuario = reader.IsDBNull("validacao_id_usuario") ? 0 : reader.GetInt32("validacao_id_usuario");
                        pedido.usuario_id_usuario = reader.GetInt32("usuario_id_usuario");

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
            "data=@data, " +
            "total=@total, " +
            "quantidade=@quantidade, " +
            "forma_pagamento=@forma_pagamento, "  +
            "status=@status, " +
            "validacao_id_usuario=@validacao_id_usuario, " +
            "usuario_id_usuario=@usuario_id_usuario " +
            "WHERE id_pedido=@id_pedido";

            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {

                    command.Parameters.AddWithValue("@id_pedido", id);
                    command.Parameters.AddWithValue("@data", pedido.data);
                    command.Parameters.AddWithValue("@total", pedido.total);
                    command.Parameters.AddWithValue("@quantidade", pedido.quantidade);
                    command.Parameters.AddWithValue("@forma_pagamento", pedido.forma_pagamento);
                    command.Parameters.AddWithValue("@status", pedido.status);
                    command.Parameters.AddWithValue("@validacao_id_usuario", pedido.validacao_id_usuario);
                    command.Parameters.AddWithValue("@usuario_id_usuario", pedido.usuario_id_usuario);
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
                string query = "INSERT INTO pedido (data, total, quantidade, forma_pagamento, status, validacao_id_usuario, usuario_id_usuario) " +
                            "VALUES (@data, @total, @quantidade, @forma_pagamento, @status, @validacao_id_usuario, @usuario_id_usuario)";

                try
                {
                    _connection.Open();
                    using (var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@data", pedido.data);
                        command.Parameters.AddWithValue("@total", pedido.total);
                        command.Parameters.AddWithValue("@quantidade", pedido.quantidade);
                        command.Parameters.AddWithValue("@forma_pagamento", pedido.forma_pagamento);
                        command.Parameters.AddWithValue("@status", pedido.status);
                        command.Parameters.AddWithValue("@validacao_id_usuario", 0);
                        command.Parameters.AddWithValue("@usuario_id_usuario", pedido.usuario_id_usuario);
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