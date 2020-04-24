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
    public class InformalBlogPostCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();




        public List<InformalBlogPostComment> GetComments(int blogPostId, string blogPostType) {
            var listOfAllComments = db.InformalBlogPostComments.ToList();
            var listOfMatchingComments = new List<InformalBlogPostComment>();
            foreach (InformalBlogPostComment comment in listOfAllComments) {
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

            InformalBlogPostComment comment = new InformalBlogPostComment();
            comment.author = User.Identity.Name;
            comment.dateTime = DateTime.Now;
            comment.blogPostId = blogPostId;
            comment.blogPostType = blogPostType;
            comment.commentText = commentText;


            db.InformalBlogPostComments.Add(comment);
            db.SaveChanges();




        }

        [HttpPost]
        public void DeleteComment(int commentId) {
            InformalBlogPostComment informalBlogPostComment = db.InformalBlogPostComments.Find(commentId);
            db.InformalBlogPostComments.Remove(informalBlogPostComment);
            db.SaveChanges();
        }

        // GET: InformalBlogPostComments
        public ActionResult Index()
        {
            return View(db.InformalBlogPostComments.ToList());
        }

        // GET: InformalBlogPostComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalBlogPostComment informalBlogPostComment = db.InformalBlogPostComments.Find(id);
            if (informalBlogPostComment == null)
            {
                return HttpNotFound();
            }
            return View(informalBlogPostComment);
        }

        // GET: InformalBlogPostComments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InformalBlogPostComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,author,commentText,dateTime,blogPostId,blogPostType")] InformalBlogPostComment informalBlogPostComment)
        {
            if (ModelState.IsValid)
            {
                db.InformalBlogPostComments.Add(informalBlogPostComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(informalBlogPostComment);
        }

        // GET: InformalBlogPostComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalBlogPostComment informalBlogPostComment = db.InformalBlogPostComments.Find(id);
            if (informalBlogPostComment == null)
            {
                return HttpNotFound();
            }
            return View(informalBlogPostComment);
        }

        // POST: InformalBlogPostComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,author,commentText,dateTime,blogPostId,blogPostType")] InformalBlogPostComment informalBlogPostComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informalBlogPostComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(informalBlogPostComment);
        }

        // GET: InformalBlogPostComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalBlogPostComment informalBlogPostComment = db.InformalBlogPostComments.Find(id);
            if (informalBlogPostComment == null)
            {
                return HttpNotFound();
            }
            return View(informalBlogPostComment);
        }

        // POST: InformalBlogPostComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformalBlogPostComment informalBlogPostComment = db.InformalBlogPostComments.Find(id);
            db.InformalBlogPostComments.Remove(informalBlogPostComment);
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
