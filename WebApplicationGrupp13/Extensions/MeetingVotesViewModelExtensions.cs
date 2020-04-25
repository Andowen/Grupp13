using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Extensions
{
    public static class MeetingVotesViewModelExtensions
    {
        public static MeetingVotesViewModel ToDto(this MeetingsUsers result)
        {
            var dto = new MeetingVotesViewModel()
            {
                MeetingId = result.meetingId,
                UserId = result.userId,
                Title = result.meeting.meetingName,
                Creator = result.meeting.creator,
                Date1 = result.meeting.date1,
                Date2 = result.meeting.date2,
                Date3 = result.meeting.date3,
                Votes1 = result.meeting.vote1,
                Votes2 = result.meeting.vote2,
                Votes3 = result.meeting.vote3,
                HasVoted = result.hasVoted,
                Selected = result.votedOn
            };
            return dto;
        }
    }

}