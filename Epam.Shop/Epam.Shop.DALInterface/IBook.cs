using Epam.Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shop.DALInterface
{
    public interface IBook
    {
        bool DeleteBook(Guid BookId);

        bool AddBook(Book book);

        Book GetBook(string name);

        IEnumerable<Book> GetAllBooks(Guid Id);
    }
}
