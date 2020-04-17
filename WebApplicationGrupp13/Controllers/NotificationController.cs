using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
    }
}
