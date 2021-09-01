using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using DataAccess;
using MySqlConnector;

namespace DataAccess
{
    public class BookDataAcces
    {
        public List<Book> BookGetAll()
        {
            List<Book> BookList = new List<Book>();

            using (Connection conn = new Connection())
            {
                MySqlConnection mySqlConnection = conn.GetConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(@"select * from Writer
                        inner join Book on Book.WriterId=Writer.WriterId", mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while(mySqlDataReader.Read())
                {
                    BookList.Add(new Book
                    {
                        BookId = mySqlDataReader.GetInt32("BookId"),
                        BookName = mySqlDataReader.GetString("BookName"),
                        BookShelf = mySqlDataReader.GetString("BookShelf"),
                        WriterId = mySqlDataReader.GetInt32("WriterId"),
                        Writer = new Writer
                        {
                            WriterId = mySqlDataReader.GetInt32("WriterId"),
                            WriterName = mySqlDataReader.GetString("WriterName")
                        }
                    }) ;
                }
            }
            return BookList;
        }

        public Book BookGetById(int BookId)
        {
            using(Connection conn = new Connection())
            {
                MySqlConnection mySqlConnection = conn.GetConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(@"select * from Writer
                        inner join Book on Book.WriterId=Writer.WriterId and BookId=@BookId", mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@BookId", BookId);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                mySqlDataReader.Read();

                return new Book
                {
                    BookId = mySqlDataReader.GetInt32("BookId"),
                    BookName = mySqlDataReader.GetString("BookName"),
                    BookShelf = mySqlDataReader.GetString("BookShelf"),
                    WriterId = mySqlDataReader.GetInt32("WriterId"),
                    Writer = new Writer
                    {
                        WriterId = mySqlDataReader.GetInt32("WriterId"),
                        WriterName = mySqlDataReader.GetString("WriterName")
                    }
                };
            }
        }
        public bool BookAdd(Book book)
        {
            using(Connection conn = new Connection())
            {
                MySqlConnection mySqlConnection = conn.GetConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(@"insert into Book(BookName, BookShelf, WriterId)
                        values (@BookName, @BookShelf, @WriterId)", mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@BookName", book.BookName);
                mySqlCommand.Parameters.AddWithValue("@BookShelf", book.BookShelf);
                mySqlCommand.Parameters.AddWithValue("@WriterId", book.WriterId);

                int result = mySqlCommand.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool BookRemove(int BookId)
        {
            using(Connection conn = new Connection())
            {
                MySqlConnection mySqlConnection = conn.GetConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(@"delete from Book where BookId=@BookId",mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@BookId", BookId);

                int result = mySqlCommand.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool BookUpdate(Book book)
        {
            using (Connection conn = new Connection())
            {
                MySqlConnection mySqlConnection = conn.GetConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(@"update Book set BookName=@BookName, 
                        BookShelf=@BookShelf, WriterId=@WriterId where BookId=@BookId");
                mySqlCommand.Parameters.AddWithValue("@BookId", book.BookId);
                mySqlCommand.Parameters.AddWithValue("@BookName", book.BookName);
                mySqlCommand.Parameters.AddWithValue("@BookShelf", book.BookShelf);
                mySqlCommand.Parameters.AddWithValue("@WriterId", book.WriterId);

                int result = mySqlCommand.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
