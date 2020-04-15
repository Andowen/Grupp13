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
    public class NotificationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NotificationViewModels
        public ActionResult Index()
        {
            var notifications = new List<NotificationViewModel>();

            //foreach (var item in posts)
            //{
            //    var notification = new NotificationViewModel();
            //    notification.Id = item.Id;
            //    notification.Title = item.Title;
            //    notification.Author = item.Creator;


            //    notifications.Add(notification);
            //}
            return View(notifications);
        }

        // GET: NotificationViewModels/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    NotificationViewModel notificationViewModel = db.NotificationViewModels.Find(id);
        //    if (notificationViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(notificationViewModel);
        //}

        //// GET: NotificationViewModels/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: NotificationViewModels/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,PostType,Title,Author,IsNew")] NotificationViewModel notificationViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        notificationViewModel.Id = Guid.NewGuid();
        //        db.NotificationViewModels.Add(notificationViewModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(notificationViewModel);
        //}

        //// GET: NotificationViewModels/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    NotificationViewModel notificationViewModel = db.NotificationViewModels.Find(id);
        //    if (notificationViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(notificationViewModel);
        //}

        //// POST: NotificationViewModels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,PostType,Title,Author,IsNew")] NotificationViewModel notificationViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(notificationViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(notificationViewModel);
        //}

        //// GET: NotificationViewModels/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    NotificationViewModel notificationViewModel = db.NotificationViewModels.Find(id);
        //    if (notificationViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(notificationViewModel);
        //}

        //// POST: NotificationViewModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    NotificationViewModel notificationViewModel = db.NotificationViewModels.Find(id);
        //    db.NotificationViewModels.Remove(notificationViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
