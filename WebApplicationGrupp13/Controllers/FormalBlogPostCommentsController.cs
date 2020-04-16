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
    public class FormalBlogPostCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FormalBlogPostComments
        public List<FormalBlogPostComment>GetAllCommentsFromId(int id) {
            var listOfAllComments = db.FormalBlogPostComments.ToList();
            var listOfMatchingComments = new List<FormalBlogPostComment>();
            foreach(FormalBlogPostComment comment in listOfAllComments) {
                if (comment.formalBlogPost.id.Equals(id)) {
                    listOfMatchingComments.Add(comment);
                }
            }
            return listOfMatchingComments;
        }
        public ActionResult Index()
        {
            return View(db.FormalBlogPostComments.ToList());
        }

        // GET: FormalBlogPostComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBlogPostComment formalBlogPostComment = db.FormalBlogPostComments.Find(id);
            if (formalBlogPostComment == null)
            {
                return HttpNotFound();
            }
            return View(formalBlogPostComment);
        }

        // GET: FormalBlogPostComments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormalBlogPostComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      //[HttpPost]
      //  public void CreateComment(int formalBlogPostId, string comment) {


      //      FormalBlogPost fbp = FormalBlogPostsController.GetBlogPostFromId(formalBlogPostId);
      //      FormalBlogPostComment formalBlogPostComment = new FormalBlogPostComment();
      //      formalBlogPostComment.author = User.Identity.Name;
      //      formalBlogPostComment.dateTime = DateTime.Now;
      //      formalBlogPostComment.formalBlogPost = fbp;
      //      formalBlogPostComment.comment = comment;
            
         

      //      db.FormalBlogPostComments.Add(formalBlogPostComment);
      //      db.SaveChanges();

      //  }
       
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "id,comment,author,dateTime")] FormalBlogPostComment formalBlogPostComment)
        {
            formalBlogPostComment.author = User.Identity.Name;
            formalBlogPostComment.dateTime = DateTime.Now;
           
            if (ModelState.IsValid)
            {
                db.FormalBlogPostComments.Add(formalBlogPostComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formalBlogPostComment);
        }

        // GET: FormalBlogPostComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBlogPostComment formalBlogPostComment = db.FormalBlogPostComments.Find(id);
            if (formalBlogPostComment == null)
            {
                return HttpNotFound();
            }
            return View(formalBlogPostComment);
        }

        // POST: FormalBlogPostComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,comment,author,dateTime")] FormalBlogPostComment formalBlogPostComment)
        {
           
            if (ModelState.IsValid)
            {
                db.Entry(formalBlogPostComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formalBlogPostComment);
        }

        // GET: FormalBlogPostComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBlogPostComment formalBlogPostComment = db.FormalBlogPostComments.Find(id);
            if (formalBlogPostComment == null)
            {
                return HttpNotFound();
            }
            return View(formalBlogPostComment);
        }

        // POST: FormalBlogPostComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormalBlogPostComment formalBlogPostComment = db.FormalBlogPostComments.Find(id);
            db.FormalBlogPostComments.Remove(formalBlogPostComment);
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
