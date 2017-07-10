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
    public class AuthenticationDAL : IAuthentication
    {
        public string ConnectionString;

        public AuthenticationDAL()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["prShop"].ConnectionString;
        }

        public bool Add(User user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[User] (Id, Login, Password, IdRole, Name, SecondName, Email) VALUES (@Id, @Login, @Password, @IdRole, @Name, @SecondName, @Email)", connection);
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@IdRole", user.IdRole);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@SecondName", user.SecondName);
                command.Parameters.AddWithValue("@Email", user.Email);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        //public User Get(Guid id)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("SELECT [Id], [Login], [Password], [IdRole], [Name], [SecondName], [Email] FROM[dbo].[User] WHERE [Id]=@Id", connection);
        //        command.Parameters.AddWithValue("@Id", id);
        //        connection.Open();
        //        var reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            return new User()
        //            {
        //                Id = (Guid)reader["Id"],
        //                Login = (string)reader["Login"],
        //                Password = (byte[])reader["Password"],
        //                IdRole = (Guid)reader["IdRole"],
        //                Name = (string)reader["Name"],
        //                SecondName = (string)reader["SecondName"],
        //                Email = (string)reader["Email"]
        //            };
        //        }
        //        return null;
        //    }
        //}

        public IEnumerable<String> GetAllRoles()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT [Name] FROM [dbo].[Roles]", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return (string)reader["Name"];
                }
            }
        }

        public User GetByLogin(string login)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT [Id], [Login], [Password], [IdRole], [Name], [SecondName], [Email] FROM[dbo].[User] WHERE [Login]=@Login", connection);
                command.Parameters.AddWithValue("@Login", login);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new User()
                    {
                        Id = (Guid)reader["Id"],
                        Login = (string)reader["Login"],
                        Password = (byte[])reader["Password"],
                        IdRole = (Guid)reader["IdRole"],
                        Name = (string)reader["Name"],
                        SecondName = (string)reader["SecondName"],
                        Email = (string)reader["Email"]
                    };
                }
                return null;
            }
        }

        public IEnumerable<string> GetRole(string login)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT [Name] FROM [dbo].[Roles] INNER JOIN [dbo].[User] ON [Roles].[Id]=[User].[IdRole] WHERE [User].[Login]=@Login", connection);
                command.Parameters.AddWithValue("@Login", login);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return (string)reader["Name"];
                }
            }
        }

        public Guid GetRoleId(string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT [Id], [Name] FROM[dbo].[Roles] WHERE [Name]=@Name", connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return (Guid)reader["Id"];
                }
                throw new ArgumentException("Incorrect role name");
            }
        }
    }
}
