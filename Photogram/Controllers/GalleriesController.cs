using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Photogram.DAL;
using Photogram.Models;

namespace Photogram.Controllers
{
    public class GalleriesController : Controller
    {
        readonly PhotogramContext db = new PhotogramContext();

        // GET: Galleries
        public ActionResult Index()
        {
            return View(db.Galleries.ToList());
        }

        // GET: Galleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // GET: Galleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Galleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["ImageFilen"];
                if (file != null && file.ContentLength > 0)
                {
                    gallery.ImageGallery = System.Guid.NewGuid().ToString() + ".jpg";
                    file.SaveAs(HttpContext.Server.MapPath("~/GalleryPhoto/") + gallery.ImageGallery);
                }
                db.Galleries.Add(gallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gallery);
        }

        // GET: Galleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery gallery = db.Galleries.Find(id);
            db.Galleries.Remove(gallery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}