using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WardrobeApp.Models
{
    public class Look
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public Look()
        {
            Photos = new List<Photo>();
        }
    }
}