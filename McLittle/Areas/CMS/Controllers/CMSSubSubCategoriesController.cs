using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using McLittle.Models;

namespace McLittle.Areas.CMS.Controllers
{
    public class CMSSubSubCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CMS/CMSSubSubCategories
        public ActionResult Index()
        {
            var subsubCategory = db.subsubCategory.Include(s => s.SubCategory);
            return View(subsubCategory.ToList());
        }

        // GET: CMS/CMSSubSubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubSubCategory subSubCategory = db.subsubCategory.Find(id);
            if (subSubCategory == null)
            {
                return HttpNotFound();
            }
            return View(subSubCategory);
        }

        // GET: CMS/CMSSubSubCategories/Create
        public ActionResult Create()
        {
            ViewBag.SubCategoryId = new SelectList(db.subcategory, "SubCategoryId", "Title");
            return View();
        }

        // POST: CMS/CMSSubSubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubSubCategoryId,SubCategoryId,Title,ImageUrl")] SubSubCategory subSubCategory)
        {
            if (ModelState.IsValid)
            {
                db.subsubCategory.Add(subSubCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategoryId = new SelectList(db.subcategory, "SubCategoryId", "Title", subSubCategory.SubCategoryId);
            return View(subSubCategory);
        }

        // GET: CMS/CMSSubSubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubSubCategory subSubCategory = db.subsubCategory.Find(id);
            if (subSubCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategoryId = new SelectList(db.subcategory, "SubCategoryId", "Title", subSubCategory.SubCategoryId);
            return View(subSubCategory);
        }

        // POST: CMS/CMSSubSubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubSubCategoryId,SubCategoryId,Title,ImageUrl")] SubSubCategory subSubCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subSubCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategoryId = new SelectList(db.subcategory, "SubCategoryId", "Title", subSubCategory.SubCategoryId);
            return View(subSubCategory);
        }

        // GET: CMS/CMSSubSubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubSubCategory subSubCategory = db.subsubCategory.Find(id);
            if (subSubCategory == null)
            {
                return HttpNotFound();
            }
            return View(subSubCategory);
        }

        // POST: CMS/CMSSubSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubSubCategory subSubCategory = db.subsubCategory.Find(id);
            db.subsubCategory.Remove(subSubCategory);
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
