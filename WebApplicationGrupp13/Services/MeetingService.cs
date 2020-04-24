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
        public MeetingVotesViewModel GetMeeting(int? meetingId)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = context.MeetingsUsers
                    .Include(x => x.user)
                    .Include(x => x.meeting)
                    .FirstOrDefault(x => x.meetingId == meetingId);

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

        public IEnumerable<MeetingVotesViewModel> GetMyMeetings(string currentUser)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = context.MeetingsUsers
                    .Include(x => x.user)
                    .Include(x => x.meeting)
                    .Where(x => x.meeting.creator == currentUser)
                    .ToList();

                return result.Select(x => x.ToDto());
            }
        }
    }
}