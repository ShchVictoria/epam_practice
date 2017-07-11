using Epam.Shop.BLL;
using Epam.Shop.BLLInterface;
using Epam.Shop.Entities;
using Epam.Shop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Shop.UI.Controllers
{
    public class BookController : Controller
    {
        private static IBook bll = new BookLogic();
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookVM model)
        {
            if (User.Identity.IsAuthenticated)
            {
                var book = new Book() { Title = model.Title, Author = model.Author, Year = model.Year, Price = model.Price };
                var result = bll.AddBook(book);
                return RedirectToAction("Index", "Book");
            }
            return RedirectToAction("LogIn", "Auth");
        }
    }
}