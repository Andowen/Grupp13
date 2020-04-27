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
using WebApplicationGrupp13.Enums;

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
            var currentUser = User.Identity.GetUserId();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var postId = id.Value;
                    var postType = PostType.Calender;
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

            var meeting = service.GetMeeting(id, currentUser);

            return View(meeting);
        }

        public ActionResult VoteOnMeeting(MeetingVotesViewModel model)
        {

            using (var context = new ApplicationDbContext())
            {

                var dbEntity = context.Meeting
                    .FirstOrDefault(x => x.id == model.MeetingId);

                dbEntity.vote1 =
                    model.VoteOn == 1 ? dbEntity.vote1 + 1 : dbEntity.vote1;
                dbEntity.vote2 =
                    model.VoteOn == 2 ? dbEntity.vote2 + 1 : dbEntity.vote2;
                dbEntity.vote3 =
                    model.VoteOn == 3 ? dbEntity.vote3 + 1 : dbEntity.vote3;

                var meetUserEntity = context.MeetingsUsers
                    .FirstOrDefault(x => x.meetingId == model.MeetingId && x.userId == model.UserId);

                meetUserEntity.hasVoted = true;
                meetUserEntity.votedOn = model.VoteOn;

                context.SaveChanges();
            }

            return RedirectToAction("Details", new {id = model.MeetingId });
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
        public ActionResult Create([Bind(Include = "id,meetingName,meetingDescription,date1,date2,date3,creator")] Meetings meetings)
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
            var createdMeetingsList = service.GetMyMeetings(currentUser);
            return View(createdMeetingsList);
        }

        public ActionResult CreatorDetails(int? id)
        {
            var currentUser = User.Identity.Name;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var createdMeetingsList = service.GetMyMeeting(id.Value, currentUser);
            return View(createdMeetingsList);
        }

        public ActionResult AddMeetingToCalender([Bind(Include = "MeetingId,Title,Description,Date 1,Date2,Date3,Start,End,Selected")] MeetingCreatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new CalenderViewModel()
                {
                    Subject = model.Title,
                    Description = model.Description,
                    Start = model.Start,
                    End = model.End,
                    Creator = User.Identity.GetUserId()
                };

                switch(model.Selected)
                {
                    case 1:
                        entity.Start = model.Date1;
                        break;
                    case 2:
                        entity.Start = model.Date2;
                        break;
                    case 3:
                        entity.Start = model.Date3;
                        break;
                    default:
                        break;
                }

                db.Calender.Add(entity);
                db.SaveChanges();
                return RedirectToAction("CreatorDetails", new { id = model.MeetingId });
            }

            return RedirectToAction("CreatedMeetings");
        }
    }
}
