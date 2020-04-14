using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationGrupp13.Models {
    public class FormalBlogPostCategory {
        [Key]
        public string name { get; set; }

    }
}