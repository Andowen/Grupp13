using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Enums;

namespace WebApplicationGrupp13.Models
{
    public class UserNotifications
    {
        [Key]
        public string ID { get; set; }
        public string UserId { get; set; }
        public NotificationType SelectedNotification { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}