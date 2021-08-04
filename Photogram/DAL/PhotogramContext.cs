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

    }
}