using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Extensions
{

    public static class EducationalPostExtensions
    {
        public static NotificationViewModel ToDto(this EducationalPost entity, bool isNew)
        {
            string authorName = null;
            using(var context = new ApplicationDbContext())
            {
                var author = context.Users
                    .FirstOrDefault(x => x.UserName == entity.creator);

                authorName = $"{author.Firstname} {author.Lastname}";
            };
            var dto = new NotificationViewModel
            {
                PostId = entity.id,
                Author = authorName,
                IsNew = isNew,
                PostType = Enums.PostType.Education,
                Title = entity.title,
                Date = entity.dateTime
            };

            return dto;
        }
    }
}