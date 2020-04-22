using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationGrupp13.Enums;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Controllers
{
    public class InformalBlogPostsController : NotificationControllerBase
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
            else
            {
                try
                {
                    using (var context = new ApplicationDbContext())
                    {
                        var currentUser = User.Identity.GetUserId();
                        var postId = id.Value;
                        var postType = PostType.Informal;
                        var exists = context.ViewedNotifications
                            .Any(x => x.PostId == postId &&
                                      x.PostType == postType &&
                                      x.UserId == currentUser);
                        if (!exists)
                        {
                            var viewedNotification = new ViewedNotifications
                            {
                                PostId = postId,
                                UserId = currentUser,
                                PostType = postType,
                                TimeStamp = DateTime.Now
                            };
                            context.ViewedNotifications.Add(viewedNotification);
                            context.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
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
        public ActionResult Create([Bind(Include = "id,postText,title,creator,dateTime,category,fileName")] InformalBlogPost informalBlogPost, HttpPostedFileBase file)
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

            FileInfo fi = new FileInfo(file.FileName);

            if (fi.Extension == ".jpg" || fi.Extension == ".jpeg" || fi.Extension == ".png") {
                if (file != null) {
                    string fileName = Path.GetFileName(file.FileName);
                    string fileToSave = Path.Combine(Server.MapPath("~/InformalBlogPostImages"), fileName);
                    file.SaveAs(fileToSave);
                    informalBlogPost.fileName = fileName;
                }
            }

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
        public ActionResult Edit([Bind(Include = "id,postText,title,creator,category")] InformalBlogPost informalBlogPost)
        {
            informalBlogPost.creator = User.Identity.Name;
            informalBlogPost.dateTime = DateTime.Now;

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
