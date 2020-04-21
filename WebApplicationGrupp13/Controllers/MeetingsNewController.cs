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
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Controllers
{
    public class MeetingsNewController : NotificationControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public MeetingsNewController()
        {

        }
        // GET: MeetingsNew
        public ActionResult Index()
        {
            return View(db.Meeting.ToList());
        }

        // GET: MeetingsNew/Details/5
        public ActionResult Details(string id)
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

        // GET: MeetingsNew/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeetingsNew/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,meetingName,date1,date2,date3,creator")] Meetings meetings)
        {
            meetings.creator = User.Identity.Name;
           

            if (ModelState.IsValid)
            {
                //string iDate = "date1";
                //DateTime oDate = DateTime.Parse(iDate);

                //string zDate = "date2";
                //DateTime oDaten = DateTime.Parse(zDate);

                //string yDate = "date3";
                //DateTime oDater = DateTime.Parse(yDate);

                db.Meeting.Add(meetings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meetings);
        }

        // GET: MeetingsNew/Edit/5
        public ActionResult Edit(string id)
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

        // POST: MeetingsNew/Edit/5
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

        // GET: MeetingsNew/Delete/5
        public ActionResult Delete(string id)
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

        // POST: MeetingsNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
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
