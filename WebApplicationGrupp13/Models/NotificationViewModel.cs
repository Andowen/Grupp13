using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Enums;

namespace WebApplicationGrupp13.Models
{
    public class NotificationViewModel
    {
        public int PostId { get; set; }
        public PostType PostType { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public bool IsNew { get; set; }
    }

    public class NotificationSettingViewModel
    {
        public int UserNotiId { get; set; }
        public bool Formal { get; set; }
        public bool Informal { get; set; }
        public bool Education { get; set; }
        public bool Research { get; set; }
    }
}