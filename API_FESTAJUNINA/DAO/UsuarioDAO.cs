using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using API_FESTAJUNINA.Models;
using API_FESTAJUNINA.Repository;
using MySql.Data.MySqlClient;

namespace API_FESTAJUNINA.DAO
{
    public class UsuariosDAO
    {
        private MySqlConnectionFactory _connection;

        public UsuariosDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string query = "SELECT * FROM usuario";


            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.IdUsuario = reader.GetInt32("id_usuarios");
                        usuario.NomeInteiro = reader.GetString("nome_inteiro");
                        usuario.Email = reader.GetString("email");
                        usuario.Senha = reader.GetString("senha");
                        usuario.Telefone = reader.GetString("telefone");
                        usuario.Perfil = reader.GetString("perfil");
                        usuario.IdPedido =  reader.GetInt32("pedido");
                        usuario.Status = reader.GetByte("status");
                        usuarios.Add(usuario);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro do banco:{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro desconhecido:{ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return usuarios;

        }

         public Usuario GetId(int id)
         {
             Usuario usuario = new Usuario();
             string query = $"SELECT * FROM usuario Where id_usuario = {id}";
             try
             {
                 _connection.Open();
                 MySqlCommand command = new MySqlCommand(query, _connection);
                 using (MySqlDataReader reader = command.ExecuteReader())
                 {
                     if (reader.Read())
                     {
                         usuario.IdUsuario = reader.GetInt32("id_usuario");
                         usuario.NomeInteiro = reader.GetString("nome_inteiro");
                         usuario.Email = reader.GetString("email");
                         usuario.Telefone = reader.GetString("telefone");
                         usuario.Perfil = reader.GetString("perfil");
                         usuario.Status = reader.GetByte("status");
                         usuario.IdPedido = reader.GetInt32("id_pedido_id");
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
             return usuario;
         }

        public void AtualizarUsuarios(int id, Usuario usuario)
        {
            string query = "UPDATE usuario SET " +
            "id_usuario=@id_usuario, " +
            "nome_inteiro=@nome_inteiro, " +
            "email=@email, " +
            "senha=@senha, " +
            "telefone=@telefone, " +
            "perfil=@perfil, " +
            "status=@status " +
            "WHERE id_pedido=@id_pedido";

            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {

                    command.Parameters.AddWithValue("@nome_inteiro", usuario.NomeInteiro);
                    command.Parameters.AddWithValue("@email", usuario.Email);
                    command.Parameters.AddWithValue("@senha", usuario.Senha);
                    command.Parameters.AddWithValue("@telefone", usuario.Telefone);
                    command.Parameters.AddWithValue("@perfil", usuario.Perfil);
                    command.Parameters.AddWithValue("id_usuario", usuario.IdUsuario);
                    command.Parameters.AddWithValue("@status", usuario.Status);
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

        public void DeletarUsuario(int id)
        {
            string query = "DELETE FROM usuario Where id_usuario = @IdUsuario";

            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", id);
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

        public void CriarUsario(Usuario usuario)
        {
            string query = "INSERT INTO usuario (@nome_inteiro, @email,  @senha, @telefone, @perfil, @id_usuario, @status)" +
                        "VALUES ( nome_inteiro, email,  senha, telefone, perfil, id_usuario, status)";

            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@nome_inteiro", usuario.NomeInteiro);
                    command.Parameters.AddWithValue("@email", usuario.Email);
                    command.Parameters.AddWithValue("@senha", usuario.Senha);
                    command.Parameters.AddWithValue("@telefone", usuario.Telefone);
                    command.Parameters.AddWithValue("@perfil", usuario.Perfil);
                    command.Parameters.AddWithValue("@id_usuario", usuario.IdUsuario);
                    command.Parameters.AddWithValue("@status", usuario.Status);
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

        internal void FazerUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}


