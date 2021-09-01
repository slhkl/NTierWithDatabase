using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Connection : IDisposable
    {
        public MySqlConnection GetConnection()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(Environment.GetEnvironmentVariable("MYSQL_URI"));
            mySqlConnection.Open();
            return mySqlConnection;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
