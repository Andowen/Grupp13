using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationGrupp13.Models;
using System.Text;

namespace WebApplicationGrupp13.Controllers
{
    public class InviteUsersController : NotificationControllerBase
    {
        // GET: InviteUsers
        [HttpGet]
        public ActionResult InviteUsers()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();


            foreach (ApplicationUser user in db.Users.ToList()) {
                SelectListItem selectList = new SelectListItem() {
                    Text = user.Firstname + " " + user.Lastname,
                    Value = user.Id.ToString(),
                    Selected = user.IsSelected
                };
                listSelectListItems.Add(selectList);
            }

            InviteUserModel inteviteUserModel = new InviteUserModel() {
                InvitedUsers = listSelectListItems
            };

            return View(inteviteUserModel);
        }
        [HttpPost]
        public string InviteUsers(IEnumerable<string> selectedUsers) {
            if (selectedUsers == null) {
                return "Ingen användare är vald.";
            } else {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected – " + string.Join(",", selectedUsers));
                return sb.ToString();
            }
        }

    }
}