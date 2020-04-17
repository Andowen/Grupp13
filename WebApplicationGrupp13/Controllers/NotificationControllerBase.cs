using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationGrupp13.Enums;
using WebApplicationGrupp13.Extensions;
using WebApplicationGrupp13.Models;
using WebApplicationGrupp13.Services;

namespace WebApplicationGrupp13.Controllers
{
    public class NotificationControllerBase : Controller
    {

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(User.Identity.IsAuthenticated)
            {
                //ViewBag.Notifications = DateTime.Now.Second;
                var count = CountNotifications();
                ViewBag.Notifications = count;
                
            }
            base.OnActionExecuted(filterContext);
        }

        private int CountNotifications()
        {
            var currentUser = User.Identity.GetUserId();
            var userName = User.Identity.GetUserName();
            var service = new NotificationService();
            var result = service.GetNotifications(currentUser, userName);

            return result.Select(x => x.IsNew).Count();
        }
    }
}