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
            User newUser = new User() { Id = Guid.NewGuid(), Login = login, Password = hash, Name = name, SecondName = secondName, Email = email, IdRole = GetRoleId("User") };
            return dal.Add(newUser);
        }

        public IEnumerable<string> GetAllRoles()
        {
            return dal.GetAllRoles();
        }

        public User GetByLogin(string login)
        {
            return dal.GetByLogin(login);
        }

        public IEnumerable<string> GetRole(string login)
        {
            return dal.GetRole(login).ToArray();
        }

        public Guid GetRoleId(string name)
        {
            return dal.GetRoleId(name);
        }

        public bool TryLogin(string login, string password)
        {
            byte[] bytes = new byte[password.Length];
            for (int i = 0; i < password.Length; i++)
            {
                bytes[i] = Convert.ToByte(password[i]);
            }
            var hash = systemHash.ComputeHash(bytes);
            var user = dal.GetByLogin(login);
            return user.Password.ToString() == hash.ToString();
        }

        public bool UserExists(string login)
        {
            var user = dal.GetByLogin(login);
            return user != null;
        }
    }
}
