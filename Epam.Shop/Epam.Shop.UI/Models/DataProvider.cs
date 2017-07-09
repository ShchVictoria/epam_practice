using Epam.Shop.BLL;
using Epam.Shop.BLLInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Shop.UI.Models
{
    public class DataProvider
    {
        public static IAuthLogic logic = new AuthLogic();
    }
}