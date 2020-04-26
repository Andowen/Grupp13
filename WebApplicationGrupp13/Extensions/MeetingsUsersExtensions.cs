using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Extensions
{

    public static class MeetingsUsersExtensions
    {
        public static NotificationViewModel ToDto(this MeetingsUsers entity, bool isNew)
        {
            string authorName = null;
            using (var context = new ApplicationDbContext())
            {
                var author = context.Users
                    .FirstOrDefault(x => x.UserName == entity.meeting.creator);

                authorName = $"{author.Firstname} {author.Lastname}";
            };

            var dto = new NotificationViewModel
            {
                PostId = entity.meetingId,
                Author = authorName,
                IsNew = isNew,
                PostType = Enums.PostType.Calender,
                Title = entity.meeting.meetingName,
                Date = entity.meeting.date1
            };

            return dto;
        }
    }
}