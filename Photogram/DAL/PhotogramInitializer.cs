using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Photogram.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Photogram.DAL
{
    public class PhotogramInitializer : DropCreateDatabaseIfModelChanges<PhotogramContext>
    {
        protected override void Seed(PhotogramContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(
    new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));

            roleManager.Create(new IdentityRole("Admin"));
            var user = new ApplicationUser { UserName = "mkopowka@wp.pl" };
            string passwor = "Mati123";

            userManager.Create(user, passwor);
            userManager.AddToRole(user.Id, "Admin");

            var users = new List<User>
            {
                new User { FirstName="Mateusz",LastName="Kopowka",Email="mkopowka@wp.pl" }
            };
            users.ForEach(p => context.Users.Add(p));




            context.SaveChanges();
        }
    }
}