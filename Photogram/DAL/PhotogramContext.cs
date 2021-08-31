using Photogram.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Photogram.DAL
{
    public class PhotogramContext : DbContext
    {
        public PhotogramContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Photography> Photographies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public void SaveUser(User user)
        {
            Users.Add(user);
            SaveChanges();
        }
        public User GetUser()
        {
            string username = System.Web.HttpContext.Current.User.Identity.Name;
            var temp = Users.Where(s => username.Contains(s.Email)).ToList();
            return temp.Count == 1 ? temp.First() : null;
        }
    }
}