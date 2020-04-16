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
    public class NotificationController : NotificationControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NotificationViewModels
        public ActionResult Index(Guid? userId)
        {
            var notifications = new List<NotificationViewModel>();

            //foreach (var item in posts)
            //{
            //    var notification = new NotificationViewModel();
            //    notification.Id = item.Id;
            //    notification.Title = item.Title;
            //    notification.Author = item.Creator;


            //    notifications.Add(notification);
            //}
            return View(notifications);
        }
    }
}
