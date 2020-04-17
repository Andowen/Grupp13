using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationGrupp13.Models {
    public class FormalBlogPostComment {
        [Key]
        public int id { get; set; }
        public string comment { get; set; }
        public string author { get; set; }
        public DateTime dateTime { get; set; }
        public virtual FormalBlogPost formalBlogPost { get; set; }

    }
}