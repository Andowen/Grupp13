using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationGrupp13.Models
{
    public class Meetings
    {
        [Key]
        public int id { get; set; }
        public string meetingName { get; set; }
        public DateTime date1 { get; set; }

        public DateTime date2 { get; set; }

        public DateTime date3 { get; set; }

        public string creator { get; set; }

    } }