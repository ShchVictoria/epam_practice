using Epam.Shop.BLL;
using Epam.Shop.BLLInterface;
using Epam.Shop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Shop.UI.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        [Authorize]
        public ActionResult Index()
        {
            var user = DataProvider.logic.GetByLogin(User.Identity.Name);
            ProfileVM profile = new ProfileVM() { Name = user.Name, SecondName = user.SecondName };
            return View(profile);
        }
    }
}