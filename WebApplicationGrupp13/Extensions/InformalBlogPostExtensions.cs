using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Extensions
{

    public static class InformalBlogPostExtensions
    {
        public static NotificationViewModel ToDto(this InformalBlogPost entity, bool isNew)
        {
            var dto = new NotificationViewModel
            {
                PostId = entity.id,
                Author = entity.creator,
                IsNew = isNew,
                PostType = Enums.PostType.Informal,
                Title = entity.title,
                Date = entity.dateTime
            };

            return dto;
        }
    }
}