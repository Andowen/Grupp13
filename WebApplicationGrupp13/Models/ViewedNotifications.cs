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
        public string ID { get; set; }
        public string PostID { get; set; }
        public PostType PostType { get; set; }
        public string UserID { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}