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
        // GET: Book
        public ActionResult Index()
        {
            return View(BookVM.GetAll());
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookVM model)
        {
            if (ModelState.IsValid)
            {
                if (BookVM.Add(model))
                {
                    return RedirectToAction("Index", "Book");
                }
            }
            return View(model);
        }
        
        public ActionResult Details(Guid id)
        {
            return View(BookVM.Get(id));
        }
    
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(BookVM.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(BookVM model)
        {
            if (ModelState.IsValid)
            {
                if (BookVM.Update(model))
                {
                    return RedirectToAction("Index", "Book");
                }
            }
            return View(model);
        }
        
        public ActionResult Delete(Guid id)
        {
            return View(BookVM.Get(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Guid id)
        {
            BookVM.Delete(id);
            return RedirectToAction("Index", "Book");
        }
    }
}