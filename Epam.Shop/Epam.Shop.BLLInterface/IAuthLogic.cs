using Epam.Shop.Entities;
using System;
using System.Collections.Generic;

namespace Epam.Shop.BLLInterface
{
    public interface IAuthLogic
    {
        bool AddUser(string login, string password, string name, string secondName, string email, int role);

        bool TryLogin(string login, string password);

        bool UserExists(string login);

        User GetByLogin(string login);

        IEnumerable<string> GetRole(string login);

        IEnumerable<String> GetAllRoles();

        int GetRoleId(string name);

        int RegisterRoles();
    }
}
