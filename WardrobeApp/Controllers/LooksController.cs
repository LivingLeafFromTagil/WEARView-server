using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeApp.Models;

namespace WardrobeApp.Controllers
{
    public class LooksController : Controller
    {
        private LookContext db = new LookContext();

        [HttpGet]
        public ActionResult Looks(int id)
        {
            IQueryable<Look> u = db.Looks.Include(p => p.User);
            ViewBag.UserId = id;
            return View(u.Where(p => p.UserId == id));
        }

        [HttpGet]
        public ActionResult Details (int id)
        {
            IQueryable<Look> u = db.Looks.Include(p => p.Photos);
            Look look = u.Where(l => l.Id == id).First();
            ViewBag.Photos = look.Photos;
            ViewBag.UserId = look.UserId;
            return View(look);
        }

    }
}
