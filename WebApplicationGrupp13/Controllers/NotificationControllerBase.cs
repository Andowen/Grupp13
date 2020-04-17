using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationGrupp13.Controllers
{
    public class NotificationControllerBase : Controller
    {
        public NotificationControllerBase()
        {
            //Mock-up notisräknare
            //  ViewBag.Notifications = DateTime.Now.Second;
            ViewBag.Notifications = 0; 
        }
    }
}