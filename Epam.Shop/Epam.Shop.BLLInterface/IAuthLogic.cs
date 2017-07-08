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
        bool AddUser(User user);

        User Get(string login);

        Guid GetIdRole(string name);
    }
}
