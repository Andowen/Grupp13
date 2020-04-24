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
    public class ResearchBlogPostCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public List<ResearchBlogPostComment> GetComments(int blogPostId, string blogPostType) {
            var listOfAllComments = db.ResearchBlogPostComments.ToList();
            var listOfMatchingComments = new List<ResearchBlogPostComment>();
            foreach (ResearchBlogPostComment comment in listOfAllComments) {
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

            ResearchBlogPostComment comment = new ResearchBlogPostComment();
            comment.author = User.Identity.Name;
            comment.dateTime = DateTime.Now;
            comment.blogPostId = blogPostId;
            comment.blogPostType = blogPostType;
            comment.commentText = commentText;


            db.ResearchBlogPostComments.Add(comment);
            db.SaveChanges();




        }

        // GET: ResearchBlogPostComments
        public ActionResult Index()
        {
            return View(db.ResearchBlogPostComments.ToList());
        }

        // GET: ResearchBlogPostComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchBlogPostComment researchBlogPostComment = db.ResearchBlogPostComments.Find(id);
            if (researchBlogPostComment == null)
            {
                return HttpNotFound();
            }
            return View(researchBlogPostComment);
        }

        // GET: ResearchBlogPostComments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResearchBlogPostComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,author,commentText,dateTime,blogPostId,blogPostType")] ResearchBlogPostComment researchBlogPostComment)
        {
            if (ModelState.IsValid)
            {
                db.ResearchBlogPostComments.Add(researchBlogPostComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(researchBlogPostComment);
        }

        // GET: ResearchBlogPostComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchBlogPostComment researchBlogPostComment = db.ResearchBlogPostComments.Find(id);
            if (researchBlogPostComment == null)
            {
                return HttpNotFound();
            }
            return View(researchBlogPostComment);
        }

        // POST: ResearchBlogPostComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,author,commentText,dateTime,blogPostId,blogPostType")] ResearchBlogPostComment researchBlogPostComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(researchBlogPostComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(researchBlogPostComment);
        }

        // GET: ResearchBlogPostComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearchBlogPostComment researchBlogPostComment = db.ResearchBlogPostComments.Find(id);
            if (researchBlogPostComment == null)
            {
                return HttpNotFound();
            }
            return View(researchBlogPostComment);
        }

        // POST: ResearchBlogPostComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResearchBlogPostComment researchBlogPostComment = db.ResearchBlogPostComments.Find(id);
            db.ResearchBlogPostComments.Remove(researchBlogPostComment);
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
