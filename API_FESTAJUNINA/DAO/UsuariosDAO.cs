using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using API_FESTAJUNINA.Models;
using MySql.Data.MySqlClient;

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
                string query = "SELECT * FROM usuarios";
                
            
            try
                {
                    _connection.Open();
                    MySqlCommand command = new MySqlCommand(query, _connection);
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                            {
                                Usuarios usuarios = new Usuarios();
                                usuarios.IdUsuario = reader.GetInt32("id_usuarios");
                                usuarios.NomeInteiro = reader.GetString("nome_inteiro");
                                usuarios.Email = reader.GetString("email");
                                usuarios.Senha = reader.GetString("senha");
                                usuarios.Telefone = reader.GetString("telefone");
                                usuarios.Perfil = reader.GetString("perfil");
                                usuarios.Status = reader.GetString("status");
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

        // public Pedidos GetId(int id)
        // {
        //     Pedidos pedido = new Pedidos();
        //     string guery = $"SELECT * FROM pedido Where id_pedido = {id}";
        //     try
        //     {
        //         _connection.Open();
        //         MySqlCommand command = new MySqlCommand(guery, _connection);
        //         using (MySqlDataReader reader = command.ExecuteReader())
        //         {
        //             if (reader.Read())
        //             {
        //                 usuarios.id_usuarios = reader.GetInt32("id_usuario");
        //                 usuarios.NomeInteiro = reader.GetDateTime("nome_inteiro");
        //                 usuarios.email = reader.GetInt32("email");
        //                 usuarios.senha = reader.GetInt32("total");
        //                 usuarios.telefone = reader.GetString("telefone");
        //                 usuarios.perfil = reader.GetInt32("perfil");
        //                 usuarios.status = reader.GetInt32("status");
 
        //             }
        //         }
        //     }
        //     catch (MySqlException ex)
        //     {
        //         Console.WriteLine($"erro do BANCO: {ex.Message}");
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"erro do BANCO: {ex.Message}");
        //     }
        //     finally
        //     {
        //         _connection.Close();
        //     }
        //     return pedido;
        // }
     
        public void AtualizarUsuarios(int id, Usuarios usuario )
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
 
        public void DeletarPedido(int id)
        {
            string query = "DELETE FROM personagem Where id_usuario = @id_usuario";
 
            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@id_usuario", id);
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
                string query = "INSERT INTO pedido (@nome_inteiro, @email,  @senha, @telefone, @perfil, @id_usuario, @status)" +
                            "VALUES ( @status)";
 
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

    }
}
            

         

