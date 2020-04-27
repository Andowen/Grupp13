using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationGrupp13.Models
{
    public class MeetingVotesViewModel
    {
        public int MeetingId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Description { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public DateTime Date3 { get; set; }
        public int Votes1 { get; set; }
        public int Votes2 { get; set; }
        public int Votes3 { get; set; }
        public int VoteOn { get; set; }
        public bool HasVoted { get; set; }
        public int Selected { get; set; }
    }

    public class MeetingCreatorViewModel
    {
        public int MeetingId { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Description { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public DateTime Date3 { get; set; }
        public int Votes1 { get; set; }
        public int Votes2 { get; set; }
        public int Votes3 { get; set; }
        public bool HasScheduled { get; set; }
        public int Selected { get; set; }
        public int EventId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public MeetingCreatorViewModel()
        {
            Start = DateTime.Now;
            End = DateTime.Now;
        }
    }
}