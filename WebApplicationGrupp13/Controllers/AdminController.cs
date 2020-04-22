﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationGrupp13.Extensions;
using WebApplicationGrupp13.Models;
using WebApplicationGrupp13.Services;

namespace WebApplicationGrupp13.Controllers
{
    public class AdminController : NotificationControllerBase
    {
        private AdminService service = new AdminService();
        
        // GET: Admin
        [CustomAuthorize(Roles ="Admin")]
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var currentUser = User.Identity.GetUserId();
                var roleType = "Admin";
                var roleId = context.Roles.FirstOrDefault(r => r.Name == roleType).Id;

                var userAdminList = service.GetUsers(currentUser, roleId, roleType);    

                return View(userAdminList);
            }

        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult UserAuthorization()
        {
            using (var context = new ApplicationDbContext())
            {
                var currentUser = User.Identity.GetUserId();
                var roleType = "AuthorizedUser";
                var roleId = context.Roles.FirstOrDefault(r => r.Name == roleType).Id;

                var userAdminList = service.GetUsers(currentUser, roleId, roleType);

                return View(userAdminList);
            }

        }

        // GET: Admin/Details/5
        public int CountAdmins(IEnumerable<AdminViewModel> userAdminList)
        {
            return userAdminList.Count(x => x.Role == "Admin");
        }

        public int CountAuthorizedUsers(IEnumerable<AdminViewModel> userAdminList)
        {
            return userAdminList.Count(x => x.Role == "AuthorizedUser");
        }

        [CustomAuthorize(Roles = "Admin")]
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

        [CustomAuthorize(Roles = "Admin")]
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

        public ActionResult UnAuthorized()
        {
            return View();
        }
    }
}