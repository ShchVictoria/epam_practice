using Epam.Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Shop.UI.Models
{
    public class BookVM
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public int Price { get; set; }

        public static IEnumerable<BookVM> GetAll()
        {
            List<BookVM> list = new List<BookVM>();
            foreach (var item in DataProvider.logicBook.GetAllBooks())
            {
                list.Add(new BookVM()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Author = item.Author,
                    Year = item.Year,
                    Price = item.Price
                });
            }
            return list;
        }

        public static bool Add(BookVM model)
        {
            var result = DataProvider.logicBook.AddBook(new Entities.Book()
            {
                Id = model.Id,
                Title = model.Title,
                Author = model.Author,
                Year = model.Year,
                Price = model.Price
            });
            return result;
        }

        public static bool Delete(Guid id)
        {
            return DataProvider.logicBook.DeleteBook(id);
        }

        public static BookVM Get(Guid id)
        {
            var result = DataProvider.logicBook.GetById(id);
            return new BookVM()
            {
                Id = result.Id,
                Title = result.Title,
                Author = result.Author,
                Year = result.Year,
                Price = result.Price
            };
        }

        public static bool Update(BookVM model)
        {
            var result = DataProvider.logicBook.Update(new Book()
            {
                Id = model.Id,
                Title = model.Title,
                Author = model.Author,
                Year = model.Year,
                Price = model.Price
            });
            return result;
        }
    }
}