using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using API_FESTAJUNINA.Models;
using API_FESTAJUNINA.Repository;
using MySql.Data.MySqlClient;
using System.Data;


namespace API_FESTAJUNINA.DAO
{
    public class UsuariosDAO
    {
        private MySqlConnection _connection;

        public UsuariosDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }

        public List<Usuarios> GetAll()
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            string query = "SELECT * FROM usuario";


            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuarios usuario = new Usuarios();
                        usuario.IdUsuario = reader.GetInt32("id_usuario");
                        usuario.NomeInteiro = reader.GetString("nome_inteiro");
                        usuario.Email = reader.GetString("email");
                        usuario.Senha = reader.GetString("senha");
                        usuario.Telefone = reader.GetString("telefone");
                        usuario.Perfil = reader.GetString("perfil");
                        usuario.Status = reader.GetInt32("status");
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

         public Usuarios GetId(int id)
         {
             Usuarios usuario = new Usuarios();
             string query = $"SELECT * FROM usuario WHERE id_usuario = {id}";
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
                         usuario.Senha = reader.GetString("senha");
                         usuario.Telefone = reader.GetString("telefone");
                         usuario.Perfil = reader.GetString("perfil");
                         usuario.Status = reader.GetInt32("status");
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

        public void AtualizarUsuarios(int id, Usuarios usuario)
        {
            string query = "UPDATE usuario SET " +
            "nome_inteiro=@nome_inteiro, " +
            "email=@email, " +
            "senha=@senha, " +
            "telefone=@telefone, " +
            "perfil=@perfil, " +
            "status=@status " +
            "WHERE id_usuario=@id_usuario";

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
                    command.Parameters.AddWithValue("@status", usuario.Status);
                    command.Parameters.AddWithValue("@id_usuario", usuario.IdUsuario);
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

        public void CriarUsario(Usuarios usuario)
        {
            string query = "INSERT INTO usuario (nome_inteiro, email,  senha, telefone, perfil, status)" +
                        "VALUES (@nome_inteiro, @email,  @senha, @telefone, @perfil, @status)";

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

    }
}
            

         

