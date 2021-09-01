using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using DataAccess;

namespace Business
{
    public class BookBusiness
    {
        BookDataAcces bookDataAcces = new BookDataAcces();
        public List<Book> GetAll()
        {
            return bookDataAcces.BookGetAll();
        }

        public Book GetById(int Id)
        {
            return bookDataAcces.BookGetById(Id);
        }

        public string Add(Book book)
        {
            if (bookDataAcces.BookAdd(book))
                return "Kitap Basariyla Eklendi";
            else
                return "Kitap Eklenemedi";
        }
        public string Remove(int Id)
        {
            if (bookDataAcces.BookRemove(Id))
                return "Kitap Basariyla Silindi";
            else
                return "Kitap Silinemedi";
        }
        public string Update(Book book)
        {
            if (bookDataAcces.BookUpdate(book))
                return "Kitap Basariyla Guncellendi";
            else
                return "Kitap Guncelelnemedi";
        }
    }
}
