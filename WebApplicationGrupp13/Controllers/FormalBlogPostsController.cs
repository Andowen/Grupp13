using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationGrupp13.Enums;
using WebApplicationGrupp13.ErrorHandling;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Controllers
{
    [Authorize]
    public class FormalBlogPostsController : NotificationControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FormalBlogPosts

       public FormalBlogPostsController() {

        }
        public static FormalBlogPost GetBlogPostFromId(int id) {
            ApplicationDbContext dbContext = new ApplicationDbContext();
          
                return dbContext.BlogPosts.Find(id);
          
        }


        public static string GetProfilePictureFromUsername(string userName) {
            string image="";
            ApplicationDbContext dbContext = new ApplicationDbContext();
            foreach (ApplicationUser user in dbContext.Users.ToList()) {

                if (user.UserName.Equals(userName)) {
                    image = user.Img;
                }
            }
            return image;

        }

        public static string GetNameFromUsername(string userName)
        {
            string name = "";
            string firstname = "";
            string lastname = "";

            ApplicationDbContext dbContext = new ApplicationDbContext();
            foreach (ApplicationUser user in dbContext.Users.ToList())
            {

                if (user.UserName.Equals(userName))
                {
                    firstname = user.Firstname;
                    lastname = user.Lastname;
                    name = firstname + " " + lastname;
                }
            }
            return name;

        }





        public static string GetDateFromDateTime(DateTime dateTime) {

            string year = dateTime.Year.ToString();
            string month = dateTime.Month.ToString() ;
            string day = dateTime.Day.ToString();
            string day2 = dateTime.DayOfWeek.ToString();
            string monthInText="";
            string dayinText= "";
           


            switch (dateTime.Month) {
                case 1:
                    monthInText = "januari";
                    break;
                case 2:
                    monthInText = "februari";
                    break;
                case 3:
                    monthInText = "mars";
                    break;
                case 4:
                    monthInText = "april";
                    break;
                case 5:
                    monthInText = "maj";
                    break;
                case 6:
                    monthInText = "juni";
                    break;
                case 7:
                    monthInText = "juli";
                    break;
                case 8:
                    monthInText = "augusti";
                    break;
                case 9:
                    monthInText = "september";
                    break;
                case 10:
                    monthInText = "oktober";
                    break;
                case 11:
                    monthInText = "november";
                    break;
                case 12:
                    monthInText = "december";
                    break;
            }

            if (dateTime.DayOfWeek.ToString().Equals("Monday")) {
                dayinText = "Måndag";

            }
            else if (dateTime.DayOfWeek.ToString().Equals("Tuesday")) {
                dayinText = "Tisdag";

            } else if (dateTime.DayOfWeek.ToString().Equals("Wednesday")) {
                dayinText = "Onsdag";

            } else if (dateTime.DayOfWeek.ToString().Equals("Thursday")) {
                dayinText = "Torsdag";

            } else if (dateTime.DayOfWeek.ToString().Equals("Friday")) {
                dayinText = "Fredag";

            } else if (dateTime.DayOfWeek.ToString().Equals("Saturday")) {
                dayinText = "Lördag";

            } else if (dateTime.DayOfWeek.ToString().Equals("Sunday")) {
                dayinText = "Söndag";

            }
            string fullDate = dayinText + ", " + day + " " + monthInText + " " + year;


            return fullDate;
        }
        public ActionResult Index()
        {

            List<string> ct = new List<string>();
            foreach (FormalBlogPostCategory category in db.FormalBlogPostCategories)
            {
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
            else
            {
                try
                {
                    using (var context = new ApplicationDbContext())
                    {
                        var currentUser = User.Identity.GetUserId();
                        var postId = id.Value;
                        var postType = PostType.Formal;
                        var exists = context.ViewedNotifications
                            .Any(x => x.PostId == postId &&
                                      x.PostType == postType &&
                                      x.UserId == currentUser);
                        if(!exists)
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
        //public ActionResult Create([Bind(Include = "id,postText,title,category")] FormalBlogPost formalBlogPost)
        //{
        //    var categories = db.FormalBlogPostCategories.ToList();
        //    List<string> categorylist = new List<string>();
        //    foreach (FormalBlogPostCategory ct in categories)
        //    {
        //        categorylist.Add(ct.name);
        //    }
        //    ViewBag.CategoryList = categorylist;
        //    if (ModelState.IsValid)
        //    {
        //        var test = formalBlogPost.category;


        //        formalBlogPost.creator = User.Identity.Name;
        //        formalBlogPost.dateTime = DateTime.Now;

        //        db.BlogPosts.Add(formalBlogPost);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //           //   return View(formalBlogPost);
        //        }

            //GET: FormalBlogPosts/Edit/5




        //[HttpPost]
        //[ValidateAntiForgeryToken]
        // Endast om en fil tas med i uppladdningen
        public ActionResult Create([Bind(Include = "id,postText,title,category,fileName")] FormalBlogPost formalBlogPost, HttpPostedFileBase file) {
            var categories = db.FormalBlogPostCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach (FormalBlogPostCategory ct in categories) {
                categorylist.Add(ct.name);
            }
            ViewBag.CategoryList = categorylist;
            formalBlogPost.creator = User.Identity.Name;
            formalBlogPost.dateTime = DateTime.Now;
         
               
           
            if (file != null) {
                string fileName = Path.GetFileName(file.FileName);
                string fileToSave = Path.Combine(Server.MapPath("~/FormalBlogPostUploads"), fileName);
                file.SaveAs(fileToSave);
                formalBlogPost.fileName = fileName;
            }

            db.BlogPosts.Add(formalBlogPost);
            db.SaveChanges();
            return RedirectToAction("Index");
           
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
        public ActionResult Edit([Bind(Include = "id,postText,title,creator,category,fileName")] FormalBlogPost formalBlogPost)
        {
            formalBlogPost.creator = User.Identity.Name;
            formalBlogPost.dateTime = DateTime.Now;

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
