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
    public class FormalBlogPostCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<FormalBlogPostComment> GetComments (int blogPostId, string blogPostType){
            var listOfAllComments = db.FormalBlogPostComments.ToList();
            var listOfMatchingComments = new List<FormalBlogPostComment>();
            foreach (FormalBlogPostComment comment in listOfAllComments) {
                if(comment.blogPostId.Equals(blogPostId)){
                    if (comment.blogPostType.Equals(blogPostType)) {
                        listOfMatchingComments.Add(comment);
                    }

                }
            }
            return listOfMatchingComments;


        }

        [HttpPost]
        public void CreateComment(int blogPostId, string blogPostType, string commentText) {
            
            FormalBlogPostComment comment = new FormalBlogPostComment();
            comment.author = User.Identity.Name;
            comment.dateTime = DateTime.Now;
            comment.blogPostId = blogPostId;
            comment.blogPostType = blogPostType;
            comment.commentText = commentText;
           

                db.FormalBlogPostComments.Add(comment);
                db.SaveChanges();
         

       

        }
        public bool DoesCommentExist(string blogPostType, string commentText, string author) {

            bool exists = true;
            var listOfallComments = db.FormalBlogPostComments.ToList();
            foreach(FormalBlogPostComment comment in listOfallComments) {
                if(comment.blogPostType.Equals(blogPostType) && comment.commentText.Equals(commentText) && comment.author.Equals(author)) {

                    exists = false;
                }


            }



            return exists;
        }












        // GET: Comments
        public ActionResult Index()
        {
            return View(db.FormalBlogPostComments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBlogPostComment comment = db.FormalBlogPostComments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,author,commentText,dateTime,blogPostId,blogPostType")] FormalBlogPostComment comment)
        {
            if (ModelState.IsValid)
            {
                db.FormalBlogPostComments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBlogPostComment comment = db.FormalBlogPostComments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,author,commentText,dateTime,blogPostId,blogPostType")] FormalBlogPostComment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBlogPostComment comment = db.FormalBlogPostComments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormalBlogPostComment comment = db.FormalBlogPostComments.Find(id);
            db.FormalBlogPostComments.Remove(comment);
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
