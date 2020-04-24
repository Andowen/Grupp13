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
    [Authorize]
    public class InformalBlogPostCategoriesController : NotificationControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InformalBlogPostCategories
        public ActionResult Index()
        {
            return View(db.InformalBlogPostCategories.ToList());
        }

        // GET: InformalBlogPostCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalBlogPostCategory informalBlogPostCategory = db.InformalBlogPostCategories.Find(id);
            if (informalBlogPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(informalBlogPostCategory);
        }

        // GET: InformalBlogPostCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InformalBlogPostCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name")] InformalBlogPostCategory informalBlogPostCategory)
        {
            if (ModelState.IsValid)
            {
                db.InformalBlogPostCategories.Add(informalBlogPostCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(informalBlogPostCategory);
        }

        // GET: InformalBlogPostCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalBlogPostCategory informalBlogPostCategory = db.InformalBlogPostCategories.Find(id);
            if (informalBlogPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(informalBlogPostCategory);
        }

        // POST: InformalBlogPostCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "name")] InformalBlogPostCategory informalBlogPostCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informalBlogPostCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(informalBlogPostCategory);
        }

        // GET: InformalBlogPostCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalBlogPostCategory informalBlogPostCategory = db.InformalBlogPostCategories.Find(id);
            if (informalBlogPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(informalBlogPostCategory);
        }

        // POST: InformalBlogPostCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            InformalBlogPostCategory informalBlogPostCategory = db.InformalBlogPostCategories.Find(id);
            db.InformalBlogPostCategories.Remove(informalBlogPostCategory);
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
