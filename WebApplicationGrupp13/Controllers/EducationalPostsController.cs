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
    public class EducationalPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EducationalPosts
        public ActionResult Index()
        {
            return View(db.EduPosts.ToList());
        }

        // GET: EducationalPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalPost educationalPost = db.EduPosts.Find(id);
            if (educationalPost == null)
            {
                return HttpNotFound();
            }
            return View(educationalPost);
        }

        // GET: EducationalPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationalPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,postText,title")] EducationalPost educationalPost)
        {
            if (ModelState.IsValid)
            {
                db.EduPosts.Add(educationalPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(educationalPost);
        }

        // GET: EducationalPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalPost educationalPost = db.EduPosts.Find(id);
            if (educationalPost == null)
            {
                return HttpNotFound();
            }
            return View(educationalPost);
        }

        // POST: EducationalPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,postText,title")] EducationalPost educationalPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationalPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educationalPost);
        }

        // GET: EducationalPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalPost educationalPost = db.EduPosts.Find(id);
            if (educationalPost == null)
            {
                return HttpNotFound();
            }
            return View(educationalPost);
        }

        // POST: EducationalPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationalPost educationalPost = db.EduPosts.Find(id);
            db.EduPosts.Remove(educationalPost);
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
