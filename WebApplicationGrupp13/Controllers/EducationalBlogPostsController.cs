﻿using Microsoft.AspNet.Identity;
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
    [Authorize]
    public class EducationalBlogPostsController : NotificationControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EducationalBlogPosts
        [HttpPost]
        public List<String> GetCategories() {
            List<String> names = new List<string>();
            foreach (EducationalPostCategory category in db.EducationalPostCategories.ToList()) {
                names.Add(category.category);
            }
            return names;
        }
        public ActionResult Index(string searchString) {
            var blogPosts = from s in db.EduPosts
                            select s;
            if (!String.IsNullOrEmpty(searchString)) {
                blogPosts = blogPosts.Where(s => s.category.Equals(searchString));
            }
            return View(blogPosts);

        }
    


        public static string GetDateFromDateTime(DateTime dateTime) {

            string year = dateTime.Year.ToString();
            string month = dateTime.Month.ToString();
            string day = dateTime.Day.ToString();
            string day2 = dateTime.DayOfWeek.ToString();
            string monthInText = "";
            string dayinText = "";



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

            } else if (dateTime.DayOfWeek.ToString().Equals("Tuesday")) {
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

        // GET: EducationalBlogPosts/Details/5
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
                        var postType = PostType.Education;
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
            EducationalPost educationalPost = db.EduPosts.Find(id);
            if (educationalPost == null)
            {
                return HttpNotFound();
            }
            return View(educationalPost);
        }

        // GET: EducationalBlogPosts/Create
        public ActionResult Create()
        {
            var categories = db.EducationalPostCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach (EducationalPostCategory ct in categories) {
                categorylist.Add(ct.category);
            }
            ViewBag.CategoryList = categorylist;

            return View();
        }

        // POST: EducationalBlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,postText,title,category,fileName")] EducationalPost educationalPost, HttpPostedFileBase file)
        {
            var categories = db.EducationalPostCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach (EducationalPostCategory ct in categories) {
                categorylist.Add(ct.category);
            }
            ViewBag.CategoryList = categorylist;
            educationalPost.creator = User.Identity.Name;
            educationalPost.dateTime = DateTime.Now;
            if (file != null) {
                string fileName = Path.GetFileName(file.FileName);
                string fileToSave = Path.Combine(Server.MapPath("~/FormalBlogPostUploads"), fileName);
                file.SaveAs(fileToSave);
                educationalPost.fileName = fileName;
            }
            db.EduPosts.Add(educationalPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: EducationalBlogPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalPost educationalPost = db.EduPosts.Find(id);
            if (educationalPost == null)
            {
                return HttpNotFound();
            }
            return View(educationalPost);
        }

        // POST: EducationalBlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,postText,title,category")] EducationalPost educationalPost)
        {
            educationalPost.creator = User.Identity.Name;
            educationalPost.dateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(educationalPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educationalPost);
        }

        // GET: EducationalBlogPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalPost educationalPost = db.EduPosts.Find(id);
            if (educationalPost == null)
            {
                return HttpNotFound();
            }
            return View(educationalPost);
        }

        // POST: EducationalBlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationalPost educationalPost = db.EduPosts.Find(id);
            db.EduPosts.Remove(educationalPost);
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
