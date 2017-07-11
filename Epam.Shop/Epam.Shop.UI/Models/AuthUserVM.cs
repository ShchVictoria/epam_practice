using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Epam.Shop.UI.Models
{
    public class AuthUserVM
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public static bool LogIn(AuthUserVM model)
        {
            var result = DataProvider.logic.TryLogin(model.Login, model.Password);

            if (result)
            {
                FormsAuthentication.SetAuthCookie(model.Login, true);
                return true;
            }
            return false;
        }

        public static bool LogOut()
        {
            FormsAuthentication.SignOut();
            return true;
        }
    }
}