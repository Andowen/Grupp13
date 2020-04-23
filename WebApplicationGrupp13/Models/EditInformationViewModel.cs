using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApplicationGrupp13.Models
{
    public class EditInformationViewModel
    {
        [Display(Name = "Förnamn")]
        public string Firstname { get; set; }

        [Display(Name = "Efternamn")]
        public string Lastname { get; set; }

        [Display(Name = "Telefonnummer")]
        public string Mobilenumber { get; set; }
        [Display(Name = "Profilbild")]
        public string Img { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}