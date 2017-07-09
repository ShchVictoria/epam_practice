using Epam.Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shop.BLLInterface
{
    public interface IAuthLogic
    {
        bool AddUser(string login, string password, string name, string secondName, string email);

        User Get(string login);

        bool UserExists(string login);

        Guid GetIdRole(string name);
    }
}
