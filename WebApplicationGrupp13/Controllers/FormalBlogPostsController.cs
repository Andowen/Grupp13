    using System;
using System.Collections;
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
    public class FormalBlogPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FormalBlogPosts

       
        public ActionResult Index()
        {
            
            List<string> ct = new List<string>();
            foreach (FormalBlogPostCategory category in db.FormalBlogPostCategories) {
                ct.Add(category.name);
            }

          
            ViewBag.CategoryList = ct;
           
            return View(db.BlogPosts.ToList());
        }

        // GET: FormalBlogPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBlogPost formalBlogPost = db.BlogPosts.Find(id);
            if (formalBlogPost == null)
            {
                return HttpNotFound();
            }
            return View(formalBlogPost);
        }

        // GET: FormalBlogPosts/Create
        public ActionResult Create()
        {
            var categories = db.FormalBlogPostCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach(FormalBlogPostCategory ct in categories) {
                categorylist.Add(ct.name);
            }
            ViewBag.CategoryList = categorylist;
    
            return View();
        }

        // POST: FormalBlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,postText,title,category")] FormalBlogPost formalBlogPost)
        {
            var categories = db.FormalBlogPostCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach (FormalBlogPostCategory ct in categories) {
                categorylist.Add(ct.name);
            }
            ViewBag.CategoryList = categorylist;
            //  if (ModelState.IsValid)
            //   {
            var test = formalBlogPost.category;
           

                formalBlogPost.creator = User.Identity.Name;
                formalBlogPost.dateTime = DateTime.Now;
                db.BlogPosts.Add(formalBlogPost);
                db.SaveChanges();
                return RedirectToAction("Index");
          //  }

         //   return View(formalBlogPost);
        }

        // GET: FormalBlogPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBlogPost formalBlogPost = db.BlogPosts.Find(id);
            if (formalBlogPost == null)
            {
                return HttpNotFound();
            }
            return View(formalBlogPost);
        }

        // POST: FormalBlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,postText,title")] FormalBlogPost formalBlogPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formalBlogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formalBlogPost);
        }

        // GET: FormalBlogPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBlogPost formalBlogPost = db.BlogPosts.Find(id);
            if (formalBlogPost == null)
            {
                return HttpNotFound();
            }
            return View(formalBlogPost);
        }

        // POST: FormalBlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormalBlogPost formalBlogPost = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(formalBlogPost);
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
