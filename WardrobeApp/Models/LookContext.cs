using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WardrobeApp.Models
{
    public class LookContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Look> Looks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>().HasMany(c => c.Looks)
                .WithMany(s => s.Photos)
                .Map(t => t.MapLeftKey("PhotoId")
                .MapRightKey("LookId")
                .ToTable("PhotoLook"));
        }
    }
}