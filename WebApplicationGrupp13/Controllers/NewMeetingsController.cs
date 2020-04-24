using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationGrupp13.Models;
using WebApplicationGrupp13.Services;
using WebApplicationGrupp13.Extensions;

namespace WebApplicationGrupp13.Controllers
{
    public class NewMeetingsController : NotificationControllerBase
    {
        public MeetingService service = new MeetingService();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewMeetings
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            var meetings = service.GetMeetingInvites(currentUser);

            return View(meetings);
        }

        // GET: NewMeetings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var meeting = service.GetMeeting(id);

            return View(meeting);
        }

        public ActionResult VoteOnMeeting(MeetingVotesViewModel model)
        {

            using (var context = new ApplicationDbContext())
            {
                var entity = model.ToEntity();

                var dbEntity = context.Meeting
                    .FirstOrDefault(x => x.id == entity.id);

                dbEntity.vote1 = entity.vote1;
                dbEntity.vote2 = entity.vote2;
                dbEntity.vote3 = entity.vote3;

                var meetUserEntity = context.MeetingsUsers
                    .FirstOrDefault(x => x.meetingId == entity.id && x.userId == model.UserId);

                meetUserEntity.hasVoted = true;

                context.SaveChanges();
            }

            return RedirectToAction("Details", new { model.MeetingId });
        }



        // GET: NewMeetings/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: NewMeetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,meetingName,date1,date2,date3,creator")] Meetings meetings)
        {
            if (ModelState.IsValid)
            {
                meetings.creator = User.Identity.Name;
                db.Meeting.Add(meetings);
                db.SaveChanges();
                return RedirectToAction("InviteUsers", "InviteUsers", new { meetingId = meetings.id });
            }

            return View(meetings);
        }

        public ActionResult MeetingVotes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var meeting = service.GetMeeting(id);

            return View(meeting);
        }

        // GET: NewMeetings/Edit/5
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

        // POST: NewMeetings/Edit/5
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

        // GET: NewMeetings/Delete/5
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

        // POST: NewMeetings/Delete/5
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
        [HttpGet]
        public ActionResult CreatedMeetings() {

            var currentUser = User.Identity.Name;
            //var createdMeetings = new Meetings();
            var createdMeetingsList = new List<Meetings>();
            var meetingList = db.Meeting.ToList();
            foreach(var item in meetingList) {
                if (currentUser.Equals(item.creator)) {
                    //createdMeetings = db.Meeting.Add(item);
                    createdMeetingsList.Add(item);

                    
                }
            }
            return View(createdMeetingsList);
        }
    }
}
