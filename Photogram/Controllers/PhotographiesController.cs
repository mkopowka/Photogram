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
    public class PhotographiesController : Controller
    {
        readonly PhotogramContext db = new PhotogramContext();

        // GET: Photographies
        public ActionResult Index()
        {
            var photographies = db.Photographies.Include(p => p.Category).Include(p => p.Gallery);
            return View(photographies.ToList());
        }

        // GET: Photographies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photography photography = db.Photographies.Find(id);
            if (photography == null)
            {
                return HttpNotFound();
            }
            return View(photography);
        }

        // GET: Photographies/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name");
            return View();
        }

        // POST: Photographies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ImagePhoto,Description,CategoryId,GalleryId")] Photography photography)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["ImageFilen"];
                if (file != null && file.ContentLength > 0)
                {
                    photography.ImagePhoto = System.Guid.NewGuid().ToString() + ".jpg";
                    file.SaveAs(HttpContext.Server.MapPath("~/PhotographyPhoto/") + photography.ImagePhoto);
                }
                db.Photographies.Add(photography);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Gallery> galleries = db.Galleries.ToList();
            List<Category> categories = db.Categories.ToList();
            SelectList selectgal = new SelectList(galleries.AsReadOnly(), "Id", "Name");
            SelectList selectcat = new SelectList(categories.AsReadOnly(), "Id", "Name");
            ViewBag.CategoryId = selectcat;
            ViewBag.GalleryId = selectgal;
            return View(photography);
        }


        // GET: Photographies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photography photography = db.Photographies.Find(id);
            if (photography == null)
            {
                return HttpNotFound();
            }
            return View(photography);
        }

        // POST: Photographies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photography photography = db.Photographies.Find(id);
            db.Photographies.Remove(photography);
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
