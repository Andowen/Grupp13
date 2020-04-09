using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;

namespace WebApplicationGrupp13.Models {
    public class FormalBlogPost {
        [Key]
        public int id { get; set; }
        public string postText { get; set; }
        public string title { get; set; }
       

    }
}