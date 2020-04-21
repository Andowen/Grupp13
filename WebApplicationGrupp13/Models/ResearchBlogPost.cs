using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;

namespace WebApplicationGrupp13.Models
{
    public class ResearchBlogPost
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Innehåll")]
        public string postText { get; set; }
        [Display(Name = "Titel")]
        public string title { get; set; }
        [Display(Name = "Författare")]
        public string creator { get; set; }
        [Display(Name = "Datum")]
        public DateTime dateTime { get; set; }
        [Display(Name = "Kategori")]
        public string category { get; set; }
        [Display(Name = "Fil")]
        public string fileName { get; set; }


    }


}

