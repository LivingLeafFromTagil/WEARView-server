using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WardrobeApp.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<Look> Looks { get; set; }
        public Photo ()
        {
            Looks = new List<Look>();
        }

    }
}