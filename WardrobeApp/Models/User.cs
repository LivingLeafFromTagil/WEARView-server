using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WardrobeApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<Photo> Photos;
        public ICollection<Look> Looks;
        public User()
        {
            Photos = new List<Photo>();
            Looks = new List<Look>();
        }
    }
}