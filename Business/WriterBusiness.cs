using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Data.Models;

namespace Business
{
    public class WriterBusiness
    {
        WriterDataAccess writerDataAccess = new WriterDataAccess();
        public List<Writer> GetAll()
        {
            return writerDataAccess.WriterGetAll();
        }

        public Writer GetById(int Id)
        {
            return writerDataAccess.WriterGetById(Id);
        }

        public string Add(Writer Writer)
        {
            if (writerDataAccess.WriterAdd(Writer))
                return "Yazar Basariyla Eklendi";
            else
                return "Yazar Eklenemedi";
        }
        public string Remove(int Id)
        {
            if (writerDataAccess.WriterRemove(Id))
                return "Yazar Basariyla Silindi";
            else
                return "Yazar Silinemedi";
        }
        public string Update(Writer Writer)
        {
            if (writerDataAccess.WriterUpdate(Writer))
                return "Yazar Basariyla Guncellendi";
            else
                return "Yazar Guncelelnemedi";
        }
    }
}
