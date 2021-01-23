using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WardrobeApp.Models;

namespace WardrobeApp.Controllers
{
    public class AutorizationController : Controller
    {
        LookContext db = new LookContext();

        [HttpGet]
        public ActionResult LogIn ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string Login, string Password)
        {
            User U = db.Users.Where(p => (p.Login == Login) && (p.Password == Password)).FirstOrDefault();
            if (U == null)
            {
                return Content("Неверный логин/пароль!");
            }

            return RedirectToAction("Looks", "Looks", new { id = U.Id });
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();

            return RedirectToAction("Looks", "Looks", new { id = user.Id });
        }


    }
}