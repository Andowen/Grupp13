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
    public class EducationalPostCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EducationalPostCategories
        public ActionResult Index()
        {
            return View(db.EducationalPostCategories.ToList());
        }

        // GET: EducationalPostCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalPostCategory educationalPostCategory = db.EducationalPostCategories.Find(id);
            if (educationalPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(educationalPostCategory);
        }

        // GET: EducationalPostCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationalPostCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "category")] EducationalPostCategory educationalPostCategory)
        {
            if (ModelState.IsValid)
            {
                db.EducationalPostCategories.Add(educationalPostCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(educationalPostCategory);
        }

        // GET: EducationalPostCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalPostCategory educationalPostCategory = db.EducationalPostCategories.Find(id);
            if (educationalPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(educationalPostCategory);
        }

        // POST: EducationalPostCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "category")] EducationalPostCategory educationalPostCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationalPostCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educationalPostCategory);
        }

        // GET: EducationalPostCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalPostCategory educationalPostCategory = db.EducationalPostCategories.Find(id);
            if (educationalPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(educationalPostCategory);
        }

        // POST: EducationalPostCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EducationalPostCategory educationalPostCategory = db.EducationalPostCategories.Find(id);
            db.EducationalPostCategories.Remove(educationalPostCategory);
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
