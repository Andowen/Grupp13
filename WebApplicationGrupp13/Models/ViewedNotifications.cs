using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Enums;

namespace WebApplicationGrupp13.Models
{
    public class ViewedNotifications
    {
        [Key]
        public int ViewedId { get; set; }
        public int PostId { get; set; }
        public PostType PostType { get; set; }
        public string UserId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}