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
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(AuthUserVM model, string ReturnUrl)
        {
            var user = AdapterController.GetUser(model.Login);
            if (user != null && AuthUserVM.LogIn(model))
            {
                FormsAuthentication.SetAuthCookie(user.Name, true);

                if (ReturnUrl != null && ReturnUrl != "")
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Index", "Profile");
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            AuthUserVM.LogOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationVM model)
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
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Index", "Profile");
                    }
                }
            }
            return View();
        }

        public JsonResult IsLoginValid(string value)
        {
            bool result = RegistrationVM.IsLoginValid(value);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}