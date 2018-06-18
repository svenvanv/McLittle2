using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using McLittle.Models;

namespace McLittle.Areas.CMS.Controllers
{
    public class BlogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CMS/Blogs
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        // GET: CMS/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: CMS/Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Title,Content,ShortDiscription,ImagePath,Category, ImageUpload")] Blog blog, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();

            // afbeelding verwerken
            if (ImageUpload != null && ImageUpload.ContentLength > 0)
{
                // directory aanmaken
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Uploads"),
                product.Id.ToString());
                Directory.CreateDirectory(uploadPath);
                // TODO: oude afbeelding verwijderen
                // bestandsnaam maken, op basis van een random string (GUID)
                string fileGuid = Guid.NewGuid().ToString();

                string extension = Path.GetExtension(ImageUpload.FileName);
                string newFilename = fileGuid + extension;

                // bestand opslaan

                ImageUpload.SaveAs(Path.Combine(uploadPath, newFilename));

                // opslaan in database
                product.Image = newFilename;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: CMS/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: CMS/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,Title,Content,ShortDiscription,ImagePath,Category, ImageUpload")] Blog blog, HttpPostedFileBase ImageUpload))
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: CMS/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: CMS/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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
