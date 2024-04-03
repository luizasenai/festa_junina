using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace API_FESTAJUNINA.Repository
{
    public class MySqlConnectionFactory
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Database=bd_festa_junina;Uid=root;Pwd=senai2024;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

        internal static MySqlConnection? getConnection()
        {
            throw new NotImplementedException();
        }
    }
}