using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Models;
using WebApplicationGrupp13.Extensions;

namespace WebApplicationGrupp13.Services
{
    public class MeetingService
    {
        public MeetingVotesViewModel GetMeeting(int? meetingId, string currentUser)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = context.MeetingsUsers
                    .Include(x => x.user)
                    .Include(x => x.meeting)
                    .FirstOrDefault(x => x.meetingId == meetingId && x.userId == currentUser);

                return result.ToDto();
            }
        }
        public IEnumerable<MeetingVotesViewModel> GetMeetingInvites(string currentUser)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = context.MeetingsUsers
                    .Include(x => x.user)
                    .Include(x => x.meeting)
                    .Where(x => x.userId == currentUser)
                    .ToList();

                return result.Select(x => x.ToDto());
            }
        }

        public IEnumerable<MeetingCreatorViewModel> GetMyMeetings(string currentUser)
        {

            using (var context = new ApplicationDbContext())
            {
                var result = context.Meeting
                    .Where(x => x.creator == currentUser)
                    .ToList();

                return result.Select(x => x.ToDto(IsPostScheduled(currentUser, x.date1, x.date2, x.date3)));
            }
        }

        public MeetingCreatorViewModel GetMyMeeting(int meetingId, string currentUser)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = context.Meeting
                    .FirstOrDefault(x => x.id == meetingId);
                var calenderResult = context.Calender.FirstOrDefault(x =>
                    x.Creator == result.creator &&
                    x.Start == result.date1 ||
                    x.Start == result.date2 ||
                    x.Start == result.date3);
                if (calenderResult != null)
                {
                    return result.ToDto(calenderResult, IsPostScheduled(currentUser, result.date1, result.date2, result.date3));
                }

                return result.ToDto(IsPostScheduled(currentUser, result.date1, result.date2, result.date3));
            }
        }

        public bool IsPostScheduled(string userId, DateTime date1, DateTime date2, DateTime date3)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Calender.Any(x =>
                    x.Creator == userId &&
                    x.Start == date1 ||
                    x.Start == date2 ||
                    x.Start == date3);
            }
        }
    }
}