using Epam.Shop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Epam.Shop.UI.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegisterBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var find = AdapterController.Get(model.Login);
                if (find)
                {
                    ModelState.AddModelError("Login", "Логин недоступен");
                }
                else
                {
                    if (model.Register())
                    {
                        var account = AdapterController.CheckUser(model.Login);
                        FormsAuthentication.SetAuthCookie(account.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
    }
}