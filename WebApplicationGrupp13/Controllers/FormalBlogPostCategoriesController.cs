using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Controllers
{
    
    public class FormalBlogPostCategoriesController : NotificationControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FormalBlogPostCategories
        public ActionResult Index()
        {
            return View(db.FormalBlogPostCategories.ToList());
        }

        // GET: FormalBlogPostCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBlogPostCategory formalBlogPostCategory = db.FormalBlogPostCategories.Find(id);
            if (formalBlogPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(formalBlogPostCategory);
        }

        // GET: FormalBlogPostCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormalBlogPostCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name")] FormalBlogPostCategory formalBlogPostCategory)
        {
            if (ModelState.IsValid)
            {
                db.FormalBlogPostCategories.Add(formalBlogPostCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formalBlogPostCategory);
        }

        // GET: FormalBlogPostCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBlogPostCategory formalBlogPostCategory = db.FormalBlogPostCategories.Find(id);
            if (formalBlogPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(formalBlogPostCategory);
        }

        // POST: FormalBlogPostCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "name")] FormalBlogPostCategory formalBlogPostCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formalBlogPostCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formalBlogPostCategory);
        }

        // GET: FormalBlogPostCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBlogPostCategory formalBlogPostCategory = db.FormalBlogPostCategories.Find(id);
            if (formalBlogPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(formalBlogPostCategory);
        }

        // POST: FormalBlogPostCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FormalBlogPostCategory formalBlogPostCategory = db.FormalBlogPostCategories.Find(id);
            db.FormalBlogPostCategories.Remove(formalBlogPostCategory);
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
