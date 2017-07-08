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

        public bool AddUser(User user)
        {
            byte[] password = new byte[user.Password.Length];
            for (int i = 0; i < user.Password.Length; i++)
            {
                password[i] = Convert.ToByte(user.Password[i]);
            }
            var hash = systemHash.ComputeHash(password);
            User newUser = new User() { Id = user.Id, Login = user.Login, Password = hash, Name = user.Name, SecondName = user.SecondName, Email = user.Email };
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
    }
}
