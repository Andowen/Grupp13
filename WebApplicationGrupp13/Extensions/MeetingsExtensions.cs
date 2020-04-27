using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Extensions
{
    public static class MeetingsExtensions
    {
        public static MeetingCreatorViewModel ToDto(this Meetings result, bool hasScheduled)
        {
            var dto = new MeetingCreatorViewModel()
            {
                MeetingId = result.id,
                Title = result.meetingName,
                Description = result.meetingDescription,
                Creator = result.creator,
                Date1 = result.date1,
                Date2 = result.date2,
                Date3 = result.date3,
                Votes1 = result.vote1,
                Votes2 = result.vote2,
                Votes3 = result.vote3,
                HasScheduled = hasScheduled
            };
            return dto;
        }

        public static MeetingCreatorViewModel ToDto(this Meetings result, CalenderViewModel calenderResult, bool hasScheduled)
        {
            var dto = new MeetingCreatorViewModel()
            {
                MeetingId = result.id,
                Title = result.meetingName,
                Description = result.meetingDescription,
                Creator = result.creator,
                Date1 = result.date1,
                Date2 = result.date2,
                Date3 = result.date3,
                Votes1 = result.vote1,
                Votes2 = result.vote2,
                Votes3 = result.vote3,
                HasScheduled = hasScheduled,
                Start = calenderResult.Start,
                End = calenderResult.End
            };
            return dto;
        }
    }
}