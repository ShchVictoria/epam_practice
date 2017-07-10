using Epam.Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shop.DALInterface
{
    public interface IAuthentication
    {
        bool Add(User user);

        User GetByLogin(string login);

        IEnumerable<string> GetRole(string login);

        IEnumerable<string> GetAllRoles();

        Guid GetRoleId(string name);
    }
}
