using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Enums;

namespace WebApplicationGrupp13.Models
{
    public class NotificationViewModel
    {
        public Guid Id { get; set; }
        public PostType PostType { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsNew { get; set; }
    }
}