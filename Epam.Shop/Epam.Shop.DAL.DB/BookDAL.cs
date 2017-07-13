using Epam.Shop.DALInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Shop.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace Epam.Shop.DAL.DB
{
    public class BookDAL : IBookDAL
    {
        public string ConnectionString;

        public BookDAL()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["prShop"].ConnectionString;
        }

        public bool AddBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Book] (Id, Title, Author, Year, Price) VALUES (@Id, @Title, @Author, @Year, @Price)", connection);
                command.Parameters.AddWithValue("@Id", book.Id);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Year", book.Year);
                command.Parameters.AddWithValue("@Price", book.Price);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool DeleteBook(Guid BookId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Book] WHERE [Id]=@Id", connection);
                command.Parameters.AddWithValue("@Id", BookId);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT [Id], [Title], [Author], [Year], [Price] FROM [dbo].[Book]", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Book()
                    {
                        Id = (Guid)reader["Id"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],
                        Year = (int)reader["Year"],
                        Price = (int)reader["Price"]
                    };
                }
            }
        }

        public Book GetBook(string title)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT [Id], [Title], [Author], [Year], [Price] FROM[dbo].[Book] WHERE [Title]=@Title", connection);
                command.Parameters.AddWithValue("@Title", title);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new Book()
                    {
                        Id = (Guid)reader["Id"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],
                        Year = (int)reader["Year"],
                        Price = (int)reader["Price"]
                    };
                }
                return null;
            }
        }

        public Book GetById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT [Id], [Title], [Author], [Year], [Price] FROM[dbo].[Book] WHERE [Id]=@Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new Book()
                    {
                        Id = (Guid)reader["Id"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],
                        Year = (int)reader["Year"],
                        Price = (int)reader["Price"]
                    };
                }
                return null;
            }
        }
    }
}
