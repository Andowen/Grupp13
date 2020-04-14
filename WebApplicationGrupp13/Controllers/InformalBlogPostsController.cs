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
    public class InformalBlogPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InformalBlogPosts
        public ActionResult Index()
        {
            List<string> ct = new List<string>();
            foreach (InformalBlogPostCategory category in db.InformalBlogPostCategories)
            {
                ct.Add(category.name);
            }


            ViewBag.CategoryList = ct;

            return View(db.InformalBlogPosts.ToList());
        }

        // GET: InformalBlogPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalBlogPost informalBlogPost = db.InformalBlogPosts.Find(id);
            if (informalBlogPost == null)
            {
                return HttpNotFound();
            }
            return View(informalBlogPost);
        }

        // GET: InformalBlogPosts/Create
        public ActionResult Create()
        {
            var categories = db.InformalBlogPostCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach (InformalBlogPostCategory ct in categories)
            {
                categorylist.Add(ct.name);
            }
            ViewBag.CategoryList = categorylist;
            return View();
        }

        // POST: InformalBlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,postText,title,creator,dateTime,category")] InformalBlogPost informalBlogPost)
        {

            var categories = db.InformalBlogPostCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach (InformalBlogPostCategory ct in categories)
            {
                categorylist.Add(ct.name);
            }
            ViewBag.CategoryList = categorylist;
            
            var test = informalBlogPost.category;


            informalBlogPost.creator = User.Identity.Name;
            informalBlogPost.dateTime = DateTime.Now;
            db.InformalBlogPosts.Add(informalBlogPost);
            db.SaveChanges();
            return RedirectToAction("Index");

            //if (ModelState.IsValid)
            //{
            //    db.InformalBlogPosts.Add(informalBlogPost);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(informalBlogPost);
        }

        // GET: InformalBlogPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalBlogPost informalBlogPost = db.InformalBlogPosts.Find(id);
            if (informalBlogPost == null)
            {
                return HttpNotFound();
            }
            return View(informalBlogPost);
        }

        // POST: InformalBlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,postText,title,creator,dateTime,category")] InformalBlogPost informalBlogPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informalBlogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(informalBlogPost);
        }

        // GET: InformalBlogPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalBlogPost informalBlogPost = db.InformalBlogPosts.Find(id);
            if (informalBlogPost == null)
            {
                return HttpNotFound();
            }
            return View(informalBlogPost);
        }

        // POST: InformalBlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformalBlogPost informalBlogPost = db.InformalBlogPosts.Find(id);
            db.InformalBlogPosts.Remove(informalBlogPost);
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
