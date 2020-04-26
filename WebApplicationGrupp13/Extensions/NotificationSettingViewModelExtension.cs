using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Enums;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Extensions
{
    public static class NotificationSettingViewModelExtension
    {
        public static NotificationSettingViewModel ToDto(this UserNotifications user)
        {
            bool formal = false;
            bool informal = false;
            bool education = false;
            bool research = false;
            bool calender = false;

            foreach (NotificationType notification in Enum.GetValues(typeof(NotificationType)))
            {
                if ((user.SelectedNotification & notification) == notification)
                {
                    switch (notification)
                    {
                        case NotificationType.Formal:
                            formal = true;
                            break;
                        case NotificationType.Informal:
                            informal = true;
                            break;
                        case NotificationType.Education:
                            education = true;
                            break;
                        case NotificationType.Research:
                            research = true;
                            break;
                        case NotificationType.Calender:
                            calender = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            var notificationSettings = new NotificationSettingViewModel()
            {
                UserNotiId = user.UserNotiId,
                Formal = formal,
                Informal = informal,
                Education = education,
                Research = research,
                Calender = calender
            };

            return notificationSettings;
        }

        public static UserNotifications ToEntity (this NotificationSettingViewModel model, string userId)
        {
            var entity = new UserNotifications
            {
                UserNotiId = model.UserNotiId,
                UpdatedDate = DateTime.Now,
                UserId = userId,
            };

            entity.SelectedNotification =
                model.Formal ? NotificationType.Formal : 0;

            entity.SelectedNotification |=
              model.Informal ? NotificationType.Informal : 0;

            entity.SelectedNotification |=
                model.Education ? NotificationType.Education : 0;

            entity.SelectedNotification |=
                model.Research ? NotificationType.Research : 0;
            
            entity.SelectedNotification |=
                model.Calender ? NotificationType.Calender : 0;

            return entity;
        }
    }
}