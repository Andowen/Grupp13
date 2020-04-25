using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int vote1 { get; set; }

        public int vote2 { get; set; }

        public int vote3 { get; set; }

     

    } 

public class MeetingsUsers
    {
        [Key]
        public int id { get; set; }

        [ForeignKey ("meeting")]
        public int meetingId { get; set; }

        public Meetings meeting { get; set; }

        [ForeignKey("user")]
        public string userId { get; set; }

        public ApplicationUser user { get; set; }

        public bool hasVoted { get; set; }

        public int votedOn { get; set; }

    }
}