using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Extensions
{
    public static class FormalBlogPostExtensions
    {
        public static NotificationViewModel ToDto(this FormalBlogPost entity, bool isNew)
        {
            var dto = new NotificationViewModel
            {
                PostId = entity.id,
                Author = entity.creator,
                IsNew = isNew,
                PostType = Enums.PostType.Formal,
                Title = entity.title,
                Date = entity.dateTime
            };

            return dto;
        }
    }
}