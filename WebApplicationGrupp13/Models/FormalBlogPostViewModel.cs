using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationGrupp13.Models {
    public class FormalBlogPostViewModel {
        public List<FormalBlogPost> formalBlogPosts { get; set; }
        public List<FormalBlogPostComment> formalBlogPostComments { get; set; }
    }
}