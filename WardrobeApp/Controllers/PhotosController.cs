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
    public class PhotosController : Controller
    {
        private LookContext db = new LookContext();

        [HttpGet]
        public ActionResult Index(int id)
        {
            IQueryable <Photo> u = db.Photos.Include(p => p.User);
            ViewBag.UserId = id;
            return View(u.Where(p => p.UserId == id));
        }

        [HttpGet]
        public ActionResult Upload(int id)
        {
            return View(id);
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload, string category, int userId)
        {
            if (upload != null)
            {
                
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                System.IO.Directory.CreateDirectory(Server.MapPath("~/Files/") + userId);

                upload.SaveAs(Server.MapPath("~/Files/" + userId + "/" + fileName));
                Photo photo = new Photo();
                photo.Link = "../../Files/" + userId + "/" + fileName;
                photo.Category = category;
                photo.UserId = userId;
                db.Photos.Add(photo);
                User u = db.Users.Find(userId);
                u.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = userId });
            }
            return HttpNotFound(); ;
        }
    }
}
