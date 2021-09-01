using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using MySqlConnector;

namespace DataAccess
{
    public class WriterDataAccess
    {
        public List<Writer> WriterGetAll()
        {
            List<Writer> WriterList = new List<Writer>();

            using (Connection conn = new Connection())
            {
                MySqlConnection mySqlConnection = conn.GetConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(@"select * from Writer", mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    WriterList.Add(new Writer
                    {
                        WriterId = mySqlDataReader.GetInt32("WriterId"),
                        WriterName = mySqlDataReader.GetString("WriterName")
                    });
                }
            }
           
            return WriterList;
        }
        public Writer WriterGetById(int WriterId)
        {
            using(Connection conn = new Connection())
            {
                MySqlConnection mySqlConnection = conn.GetConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(@"select * from Writer where WriterId=@WriterId", mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@WriterId", WriterId);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                mySqlDataReader.Read();
                return new Writer {
                    WriterId = mySqlDataReader.GetInt32("WriterId"),
                    WriterName = mySqlDataReader.GetString("WriterName")};
            }
        }
        public bool WriterAdd(Writer writer)
        {
            using (Connection conn = new Connection())
            {
                MySqlConnection mySqlConnection = conn.GetConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(@"insert into Writer(WriterName)
                        values (@WriterName)", mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@WriterName", writer.WriterName);

                int result = mySqlCommand.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool WriterRemove(int WriterID)
        {
            using (Connection conn = new Connection())
            {
                MySqlConnection mySqlConnection = conn.GetConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(@"delete from Writer where WriterId=@WriterId", mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@WriterId", WriterID);

                int result = mySqlCommand.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool WriterUpdate(Writer writer)
        {
            using (Connection conn = new Connection())
            {
                MySqlConnection mySqlConnection = conn.GetConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(@"update Writer set WriterName=@WriterName, 
                       where WriterId=@WriterId");
                mySqlCommand.Parameters.AddWithValue("@WriterId", writer.WriterId);
                mySqlCommand.Parameters.AddWithValue("@WriterName", writer.WriterName);

                int result = mySqlCommand.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
