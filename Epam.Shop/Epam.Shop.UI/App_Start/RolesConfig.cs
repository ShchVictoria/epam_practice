using Epam.Shop.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Shop.UI.App_Start
{
    public class RolesConfig
    {
        private static bool Registered = false;

        private RolesConfig() { }

        public static void Init()
        {
            var roles = AdapterController.GetAllRoles();
            if (!Registered && roles.Count() <= 0)
            {
                AdapterController.RegisterRoles();
                Registered = true;
            }
        }
    }
}