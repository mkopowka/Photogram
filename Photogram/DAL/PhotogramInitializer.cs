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
            context.SaveChanges();
        }
    }
}