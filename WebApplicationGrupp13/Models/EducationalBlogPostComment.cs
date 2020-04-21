using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationGrupp13.Models {
    public class EducationalBlogPostComment {
        [Key]
        public int id { get; set; }
        public string author { get; set; }
        public string commentText { get; set; }
        public DateTime dateTime { get; set; }
        public int blogPostId { get; set; }
        public string blogPostType { get; set; }
    }
}