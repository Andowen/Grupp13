using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Controllers {
    public class EducationalBlogPostCommentsController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();



        public List<EducationalBlogPostComment> GetComments(int blogPostId, string blogPostType) {
            var listOfAllComments = db.EducationalBlogPostComments.ToList();
            var listOfMatchingComments = new List<EducationalBlogPostComment>();
            foreach (EducationalBlogPostComment comment in listOfAllComments) {
                if (comment.blogPostId.Equals(blogPostId)) {
                    if (comment.blogPostType.Equals(blogPostType)) {
                        listOfMatchingComments.Add(comment);
                    }

                }
            }
            return listOfMatchingComments;


        }
        [HttpPost]
        public void CreateComment(int blogPostId, string blogPostType, string commentText) {

            EducationalBlogPostComment comment = new EducationalBlogPostComment();
            comment.author = User.Identity.Name;
            comment.dateTime = DateTime.Now;
            comment.blogPostId = blogPostId;
            comment.blogPostType = blogPostType;
            comment.commentText = commentText;


            db.EducationalBlogPostComments.Add(comment);
            db.SaveChanges();




        }






        // GET: EducationalBlogPostComments
        public ActionResult Index() {
            return View(db.EducationalBlogPostComments.ToList());
        }

        // GET: EducationalBlogPostComments/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalBlogPostComment educationalBlogPostComment = db.EducationalBlogPostComments.Find(id);
            if (educationalBlogPostComment == null) {
                return HttpNotFound();
            }
            return View(educationalBlogPostComment);
        }

        // GET: EducationalBlogPostComments/Create
        public ActionResult Create() {
            return View();
        }

        // POST: EducationalBlogPostComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,author,commentText,dateTime,blogPostId,blogPostType")] EducationalBlogPostComment educationalBlogPostComment) {
            if (ModelState.IsValid) {
                db.EducationalBlogPostComments.Add(educationalBlogPostComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(educationalBlogPostComment);
        }

        // GET: EducationalBlogPostComments/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalBlogPostComment educationalBlogPostComment = db.EducationalBlogPostComments.Find(id);
            if (educationalBlogPostComment == null) {
                return HttpNotFound();
            }
            return View(educationalBlogPostComment);
        }

        // POST: EducationalBlogPostComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,author,commentText,dateTime,blogPostId,blogPostType")] EducationalBlogPostComment educationalBlogPostComment) {
            if (ModelState.IsValid) {
                db.Entry(educationalBlogPostComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educationalBlogPostComment);
        }

        // GET: EducationalBlogPostComments/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalBlogPostComment educationalBlogPostComment = db.EducationalBlogPostComments.Find(id);
            if (educationalBlogPostComment == null) {
                return HttpNotFound();
            }
            return View(educationalBlogPostComment);
        }

        // POST: EducationalBlogPostComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            EducationalBlogPostComment educationalBlogPostComment = db.EducationalBlogPostComments.Find(id);
            db.EducationalBlogPostComments.Remove(educationalBlogPostComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
