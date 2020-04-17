using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Extensions
{

    public static class CalenderViewModelExtensions
    {
        public static NotificationViewModel ToDto(this CalenderViewModel entity, bool isNew)
        {
            var dto = new NotificationViewModel
            {
                PostId = entity.EventId,
                //Author = entity.creator,
                IsNew = isNew,
                PostType = Enums.PostType.Calender,
                Title = entity.Subject,
                //Date = entity.dateTime
            };

            return dto;
        }
    }
}