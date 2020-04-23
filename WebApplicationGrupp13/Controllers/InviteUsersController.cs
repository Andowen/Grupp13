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
                    Value = user.Id.ToString()
                    //Selected = user.IsSelected
                };
                listSelectListItems.Add(selectList);
            }

            InviteUserModel inteviteUserModel = new InviteUserModel() {
                AllUsers = listSelectListItems
            };

            return View(inteviteUserModel);
        }
        [HttpPost]
        public List<ApplicationUser> AddInvitedUsersToList(IEnumerable<string> selectedUsers) {
            
            List<ApplicationUser>mySelectedUsers = new List<ApplicationUser>();
            ApplicationDbContext db = new ApplicationDbContext();
            var allUsersInDb = db.Users.ToList();
            //var firstname = "";


            foreach (string value in selectedUsers) {
                foreach (ApplicationUser user in allUsersInDb)
                    if (user.Id.Equals(value)) {
                        mySelectedUsers.Add(user);
                    }
            }
            //foreach (ApplicationUser user in mySelectedUsers) {
            //    return (user.Firstname);
            //}
            //if (selectedUsers == null) {
            //} else {
               
            //    //StringBuilder sb = new StringBuilder();
            //    //sb.Append("You selected – " + string.Join(",", selectedUsers));
            //    //return sb.ToString();
            //}
            return mySelectedUsers;
        }


    }
}