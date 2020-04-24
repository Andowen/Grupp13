using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationGrupp13.Models;
using System.Text;
using Microsoft.AspNet.Identity;

namespace WebApplicationGrupp13.Controllers
{
    [Authorize]
    public class InviteUsersController : NotificationControllerBase
    {
        // GET: InviteUsers
        [HttpGet]
        public ActionResult InviteUsers(int meetingId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var currentUser = User.Identity.GetUserId();
                var users = db.Users.Where(x => x.Id != currentUser && x.UserName != "admin@admin.com").ToList();
                List<SelectListItem> listSelectListItems = new List<SelectListItem>();

                foreach (ApplicationUser user in users)
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = user.Firstname + " " + user.Lastname,
                        Value = $"{user.Id.ToString()} , {meetingId}"
                        //Selected = user.IsSelected
                    };
                    listSelectListItems.Add(selectList);
                }

                InviteUserModel inteviteUserModel = new InviteUserModel()
                {
                    AllUsers = listSelectListItems,
                   // MeetingId = meetingId
                };

                return View(inteviteUserModel);
            }
        }
        [HttpPost]
        public ActionResult AddInvitedUsersToList([Bind(Include = "id,meetingId,userId")]IEnumerable<string> selectedUsers)
        {
            using (var db = new ApplicationDbContext())
            {
                foreach (var user in selectedUsers)
                {
                    
                    string [] splitArray = user.Split(',');
                    var id = splitArray[0];
                    var meetIdString = splitArray[1];
                    var meetId = Int32.Parse(meetIdString);

                    var meetingUser = new MeetingsUsers
                    {
                        userId = id,
                        meetingId = meetId
                    };
                    db.MeetingsUsers.Add(meetingUser);
                    db.SaveChanges();

                }
                return RedirectToAction ("Index", "NewMeetings");
            }
        }
        [HttpPost]
        public ActionResult ReturnToCreate()
        {
            return RedirectToAction("Create", "NewMeetings");
        }


    }
}