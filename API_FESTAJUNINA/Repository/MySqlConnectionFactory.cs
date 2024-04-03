using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
<<<<<<< Updated upstream

=======
 
>>>>>>> Stashed changes
namespace API_FESTAJUNINA.Repository
{
    public class MySqlConnectionFactory
    {
<<<<<<< Updated upstream
          public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Database=bd_festa_junina;Uid=root;Pwd=senai2024;";
=======
         public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Database=bd_festa_junina;Uid=root;Pwd=senai2024";
>>>>>>> Stashed changes
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
