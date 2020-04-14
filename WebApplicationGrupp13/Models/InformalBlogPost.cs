using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationGrupp13.Models {
    public class InformalBlogPost {
        [Key]
        public int id { get; set; }
        public string postText { get; set; }
        public string title { get; set; }
        public string creator { get; set; }
        public DateTime dateTime { get; set; }

        public string category { get; set; }

    }
}