using Epam.Shop.BLLInterface;
using Epam.Shop.DAL.DB;
using Epam.Shop.DALInterface;
using Epam.Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shop.BLL
{
    public class AuthLogic : IAuthLogic
    {
        private readonly IAuthentication dal;
        SHA256 systemHash;

        public AuthLogic()
        {
            dal = new AuthenticationDAL();
            systemHash = SHA256.Create();
        }

        public bool AddUser(string login, string password, string name, string secondName, string email)
        {
            byte[] bytes = new byte[password.Length];
            for (int i = 0; i < password.Length; i++)
            {
                bytes[i] = Convert.ToByte(password[i]);
            }
            var hash = systemHash.ComputeHash(bytes);
            User newUser = new User() { Id = Guid.NewGuid(), Login = login, Password = hash, Name = name, SecondName = secondName, Email = email, IdRole = Guid.NewGuid() /*this.GetIdRole("User")*/ };
            return dal.Add(newUser);
        }

        public User Get(string login)
        {
            return dal.Get(login);
        }

        public Guid GetIdRole(string name)
        {
            return dal.GetIdRole(name);
        }

        public bool UserExists(string login)
        {
            var user = dal.Get(login);
            return user != null;
        }
    }
}
