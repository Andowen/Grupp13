using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var currentUser = User.Identity.GetUserId();
                var roleId = context.Roles.FirstOrDefault(r => r.Name == "Admin").Id;
                var role = "User";
                var userAdminList = new List<AdminViewModel>();
                var users = context.Users
                    .Where(x => x.Id != currentUser && x.UserName != "admin@admin.com")
                    .ToList();

                foreach (var item in users)
                {
                    if (item.Roles.Any(r => r.RoleId == roleId))
                    {
                        role = "Admin";
                    }
                    else
                    {
                        role = "User";
                    }
                    var userAdmin = new AdminViewModel
                    {
                        UserId = item.Id,
                        Name = $"{item.Firstname} {item.Lastname}",
                        Email = item.UserName,
                        Role = role

                    };
                    userAdminList.Add(userAdmin);
                }
                return View(userAdminList);
            }

        }

        // GET: Admin/Details/5
        public int CountAdmins(IEnumerable<AdminViewModel> userAdminList)
        {
            return userAdminList.Count(x => x.Role == "Admin");
        }

        public int CountUsers(IEnumerable<AdminViewModel> userAdminList)
        {
            return userAdminList.Count(x => x.Role == "User");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult MakeAdmin(string userId)
        {
            using(var context = new ApplicationDbContext())
            {
                var roleId = context.Roles.FirstOrDefault(r => r.Name == "User").Id;
                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                var user = userManager.FindById(userId);
                if (user.Roles.Any(r => r.RoleId == roleId))
                {
                    userManager.RemoveFromRole(userId, "User");
                    userManager.AddToRole(userId, "Admin");
                }
                else
                {
                    userManager.AddToRole(userId, "Admin");
                }
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RemoveAdmin(string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var roleId = context.Roles.FirstOrDefault(r => r.Name == "Admin").Id;
                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                var user = userManager.FindById(userId);
                if (user.Roles.Any(r => r.RoleId == roleId))
                {
                    userManager.RemoveFromRole(userId, "Admin");
                    userManager.AddToRole(userId, "User");
                }
                else
                {
                    userManager.AddToRole(userId, "User");
                }
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
