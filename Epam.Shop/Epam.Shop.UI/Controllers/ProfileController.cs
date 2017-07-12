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
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = DataProvider.logic.GetByLogin(User.Identity.Name);
                ProfileVM profile = new ProfileVM() { Name = user.Name, SecondName = user.SecondName };
                return View(profile);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}