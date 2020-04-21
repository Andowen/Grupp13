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
    public class ResearchBlogPostsController : NotificationControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResearchBlogPosts
        public ActionResult Index()
        {
            return View(db.ResearchBlogPosts.ToList());
        }

        // GET: ResearchBlogPosts/Details/5
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
                        var postType = PostType.Research;
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
            ResearchBlogPost researchBlogPost = db.ResearchBlogPosts.Find(id);
            if (researchBlogPost == null)
            {
                return HttpNotFound();
            }
            return View(researchBlogPost);
        }

        // GET: ResearchBlogPosts/Create
        public ActionResult Create()
        {
            var categories = db.ResearchBlogPostCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach (ResearchBlogPostCategory ct in categories)
            {
                categorylist.Add(ct.name);
            }
            ViewBag.CategoryList = categorylist;
            return View();
        }

        // POST: ResearchBlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,postText,title,creator,dateTime,category,fileName")] ResearchBlogPost researchBlogPost, HttpPostedFileBase file)
        {
            var categories = db.ResearchBlogPostCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach (ResearchBlogPostCategory ct in categories)
            {
                categorylist.Add(ct.name);
            }
            ViewBag.CategoryList = categorylist;

            var test = researchBlogPost.category;
            researchBlogPost.creator = User.Identity.Name;
            researchBlogPost.dateTime = DateTime.Now;

            if (file != null) {
                string fileName = Path.GetFileName(file.FileName);
                string fileToSave = Path.Combine(Server.MapPath("~/FormalBlogPostUploads"), fileName);
                file.SaveAs(fileToSave);
                researchBlogPost.fileName = fileName;

            }
            db.ResearchBlogPosts.Add(researchBlogPost);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: ResearchBlogPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchBlogPost researchBlogPost = db.ResearchBlogPosts.Find(id);
            if (researchBlogPost == null)
            {
                return HttpNotFound();
            }
            return View(researchBlogPost);
        }

        // POST: ResearchBlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,postText,title,category")] ResearchBlogPost researchBlogPost)
        {
            researchBlogPost.creator = User.Identity.Name;
            researchBlogPost.dateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(researchBlogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(researchBlogPost);
        }

        // GET: ResearchBlogPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchBlogPost researchBlogPost = db.ResearchBlogPosts.Find(id);
            if (researchBlogPost == null)
            {
                return HttpNotFound();
            }
            return View(researchBlogPost);
        }

        // POST: ResearchBlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResearchBlogPost researchBlogPost = db.ResearchBlogPosts.Find(id);
            db.ResearchBlogPosts.Remove(researchBlogPost);
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
