using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationGrupp13.Models {
    public class EducationalPostCategory {
        [Key]
        public string category { get; set; }
    }
}