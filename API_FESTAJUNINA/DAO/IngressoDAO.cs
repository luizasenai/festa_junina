using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_FESTAJUNINA.Models;
using MySql.Data.MySqlClient;

namespace API_FESTAJUNINA.DAO
{
    public class IngressoDAO
    {
        private MySqlConnection _connection;

        public IngressoDAO()
        {
            _connection = MySqlConnectionFactory.getConnection();
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
                        ingresso.IdIngresso = reader.GetInt32("id_personagem");
                        ingresso.Valor = reader.GetString("valor");
                        ingresso.Status = reader.GetString("status");
                        ingresso.Tipo = reader.GetString("tipo");
                        ingresso.CodigoQr = reader.GetString("codigo_qr");
                        ingresso.UsuarioId = reader.GetInt32("usuario_id_usuario");
                        ingresso.UsuarioPedido = reader.GetInt32("usuario_pedido_id_usuario");
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
    }
}