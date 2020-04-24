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
    public class ResearchBlogPostCategoriesController : NotificationControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResearchBlogPostCategories
        public ActionResult Index()
        {
            return View(db.ResearchBlogPostCategories.ToList());
        }

        // GET: ResearchBlogPostCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchBlogPostCategory researchBlogPostCategory = db.ResearchBlogPostCategories.Find(id);
            if (researchBlogPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(researchBlogPostCategory);
        }

        // GET: ResearchBlogPostCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResearchBlogPostCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name")] ResearchBlogPostCategory researchBlogPostCategory)
        {
            if (ModelState.IsValid)
            {
                db.ResearchBlogPostCategories.Add(researchBlogPostCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(researchBlogPostCategory);
        }

        // GET: ResearchBlogPostCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchBlogPostCategory researchBlogPostCategory = db.ResearchBlogPostCategories.Find(id);
            if (researchBlogPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(researchBlogPostCategory);
        }

        // POST: ResearchBlogPostCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "name")] ResearchBlogPostCategory researchBlogPostCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(researchBlogPostCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(researchBlogPostCategory);
        }

        // GET: ResearchBlogPostCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchBlogPostCategory researchBlogPostCategory = db.ResearchBlogPostCategories.Find(id);
            if (researchBlogPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(researchBlogPostCategory);
        }

        // POST: ResearchBlogPostCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ResearchBlogPostCategory researchBlogPostCategory = db.ResearchBlogPostCategories.Find(id);
            db.ResearchBlogPostCategories.Remove(researchBlogPostCategory);
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
