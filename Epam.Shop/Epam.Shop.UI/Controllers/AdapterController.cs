using Epam.Shop.BLL;
using Epam.Shop.BLLInterface;
using Epam.Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Shop.UI.Controllers
{
    public class AdapterController : Controller
    {
        private static IAuthLogic logic;

        public static void Init()
        {
            if (logic == null)
                logic = new AuthLogic();
        }

        public static User GetUser(string login)
        {
            if (logic.GetByLogin(login) != null)
            {
                return logic.GetByLogin(login);
            }
            return null;
        }

        public static void RegisterRoles()
        {
            logic.RegisterRoles();
        }

        public static bool Get(string login)
        {
            if (logic.UserExists(login))
            {
                return true; // логин занят
            }
            return false; //можно использовать
        }

        public static IEnumerable<string> GetAllRoles()
        {
            return logic.GetAllRoles();
        }

        public static void CreateAdmin(string login, string password, string email)
        {
            logic.AddUser(login, password, login, login, email, 1);
        }
    }
}