using Epam.Shop.BLLInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Shop.Entities;
using Epam.Shop.DALInterface;
using Epam.Shop.DAL.DB;

namespace Epam.Shop.BLL
{
    public class BookLogic : IBook
    {
        private static IBookDAL dal;

        public BookLogic()
        {
            dal = new BookDAL();
        }

        public bool AddBook(Book book)
        {
            return dal.AddBook(book);
        }

        public bool DeleteBook(Guid BookId)
        {
            return dal.DeleteBook(BookId);
        }

        public IEnumerable<Book> GetAllBooks(Guid Id)
        {
            return dal.GetAllBooks(Id);
        }

        public Book GetBook(string name)
        {
            return dal.GetBook(name);
        }
    }
}
