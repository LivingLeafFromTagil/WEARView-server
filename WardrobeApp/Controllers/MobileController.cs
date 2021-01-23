using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WardrobeApp.Models;


namespace WardrobeApp.Controllers
{
    
    [Route("api/[controller]")]
    public class MobileController : ApiController
    {
        LookContext db = new LookContext();
        
        public int GetUserId(string login, string password)
        {
            User U = db.Users.Where(p => (p.Login == login) && (p.Password == password)).FirstOrDefault();
            if (U == null)
            {
                return 0;
            }
            return U.Id;

        }

        public int PostAddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.Id;
        }

       public IQueryable<Photo> GetPhotos(int Id)
        {
            IQueryable<Photo> photos = db.Photos.Where(p => p.UserId == Id);
            return photos;
        }

        public IQueryable<Look> GetLooks(int Id)
        {
            IQueryable<Look> looks = db.Looks.Where(p => p.UserId == Id);
            return looks;
        }

        public void PostAddPhotos( IQueryable<Photo> photos)
        {
            foreach(Photo p in photos)
            {
                db.Photos.Add(p);
            }
            db.SaveChanges();
        }

        public void PostAddLooks(IQueryable<Look> looks)
        {
            foreach (Look l in looks)
            {
                db.Looks.Add(l);
            }
            db.SaveChanges();
        }

        public void DeletePhoto(int id)
        {
            Photo p = db.Photos.Find(id);
            if (p != null)
            {
                db.Photos.Remove(p);
                db.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            User u = db.Users.Find(id);
            if (u != null)
            {
                db.Users.Remove(u);
                db.SaveChanges();
            }
        }

        public void DeleteLook(int id)
        {
            Look l = db.Looks.Find(id);
            if (l != null)
            {
                db.Looks.Remove(l);
                db.SaveChanges();
            }
        }


    }
}