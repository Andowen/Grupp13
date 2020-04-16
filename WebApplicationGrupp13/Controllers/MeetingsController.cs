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
    public class MeetingsController : NotificationControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Meetings
        public ActionResult Index()
        {
            return View(db.Meeting.ToList());
        }

        // GET: Meetings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meetings meetings = db.Meeting.Find(id);
            if (meetings == null)
            {
                return HttpNotFound();
            }
            return View(meetings);
        }

        // GET: Meetings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,meetingName,date1,date2,date3,creator")] Meetings meetings)
        {
            if (ModelState.IsValid)
            {
                db.Meeting.Add(meetings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meetings);
        }

        // GET: Meetings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meetings meetings = db.Meeting.Find(id);
            if (meetings == null)
            {
                return HttpNotFound();
            }
            return View(meetings);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,meetingName,date1,date2,date3,creator")] Meetings meetings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meetings);
        }

        // GET: Meetings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meetings meetings = db.Meeting.Find(id);
            if (meetings == null)
            {
                return HttpNotFound();
            }
            return View(meetings);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meetings meetings = db.Meeting.Find(id);
            db.Meeting.Remove(meetings);
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
