using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationGrupp13.Enums;
using WebApplicationGrupp13.Extensions;
using WebApplicationGrupp13.Models;
using WebApplicationGrupp13.Services;


namespace WebApplicationGrupp13.Controllers
{
    public class NotificationController : NotificationControllerBase
    {
        private NotificationService service = new NotificationService();

        // GET: NotificationViewModels
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            var userName = User.Identity.GetUserName();
            var notifications = service.GetNotifications(currentUser, userName);

            return View(notifications);
        }

        public ActionResult NotificationSettings()
        {
            using (var context = new ApplicationDbContext())
            {
                var currentUser = User.Identity.GetUserId();
                var user = context.UserNotifications
                    .FirstOrDefault(x => x.UserId == currentUser);


                return View(user.ToDto());
            }
        }
        [HttpPost]
        public ActionResult EditSettings(NotificationSettingViewModel model)
        {
            
            using(var context = new ApplicationDbContext())
            {
                var currentUser = User.Identity.GetUserId();
                var entity = model.ToEntity(currentUser);

                var dbEntity = context.UserNotifications
                    .FirstOrDefault(x => x.UserNotiId == entity.UserNotiId);

                dbEntity.UpdatedDate = entity.UpdatedDate;
                dbEntity.SelectedNotification = entity.SelectedNotification;

                context.SaveChanges();
            }

            return View("NotificationSettings", model);
        }
    }
}
