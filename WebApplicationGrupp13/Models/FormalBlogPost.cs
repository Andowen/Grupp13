﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.DataAnnotations;

namespace WebApplicationGrupp13.Models {
    public class FormalBlogPost {
        [Key]
        public int id { get; set; }
        public string postText { get; set; }
        public string title { get; set; }
        public string creator { get; set; }
        public DateTime dateTime {get; set;}
        
        public string category { get; set; }

        public string fileName { get; set; }
        public FormalBlogPost() {

        }
    }
    
       
}
   
