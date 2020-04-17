using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationGrupp13.Enums;
using WebApplicationGrupp13.Extensions;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Services
{
    public class NotificationService
    {
        public IEnumerable<NotificationViewModel> GetNotifications(string currentUser, string userName)
        {
            var result = new List<NotificationViewModel>();

            using (var context = new ApplicationDbContext())
            {
                var user = context.UserNotifications
                    .FirstOrDefault(x => x.UserId == currentUser);

                if (user.SelectedNotification != NotificationType.None)
                {
                    foreach (NotificationType notification in Enum.GetValues(typeof(NotificationType)))
                    {
                        if ((user.SelectedNotification & notification) == notification)
                        {
                            switch (notification)
                            {
                                case NotificationType.Formal:
                                    result.AddRange(AddFormalBlogPosts(currentUser, user.UpdatedDate, userName));
                                    break;
                                case NotificationType.Informal:
                                    result.AddRange(AddInformalBlogPosts(currentUser, user.UpdatedDate, userName));
                                    break;
                                case NotificationType.Education:
                                    result.AddRange(AddEducationalBlogPosts(currentUser, user.UpdatedDate, userName));
                                    break;
                                case NotificationType.Research:
                                    result.AddRange(AddResearchBlogPosts(currentUser, user.UpdatedDate, userName));
                                    break;
                                //case NotificationType.Calender:
                                //    result.AddRange(AddCalenderPost(currentUser, user.UpdatedDate, userName));
                                //    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

            }
            var sortedResult = result.OrderByDescending(x => x.Date);
            return sortedResult;
        }
        private IEnumerable<NotificationViewModel> AddFormalBlogPosts(string userId, DateTime timeStamp, string userName)
        {
            using (var context = new ApplicationDbContext())
            {
                var data = context.BlogPosts
                    .Where(m => m.dateTime > timeStamp && m.creator != userName)
                    .OrderByDescending(m => m.dateTime)
                    .Take(10)
                    .ToList();

                return data.Select(x => x.ToDto(IsPostNew(x.id, PostType.Formal, userId)));
            }
        }

        private IEnumerable<NotificationViewModel> AddInformalBlogPosts(string userId, DateTime timeStamp, string userName)
        {
            using (var context = new ApplicationDbContext())
            {
                var data = context.InformalBlogPosts
                    .Where(m => m.dateTime > timeStamp && m.creator != userName)
                    .OrderByDescending(m => m.dateTime)
                    .Take(10)
                    .ToList();

                return data.Select(x => x.ToDto(IsPostNew(x.id, PostType.Informal, userId)));
            }
        }

        private IEnumerable<NotificationViewModel> AddEducationalBlogPosts(string userId, DateTime timeStamp, string userName)
        {
            using (var context = new ApplicationDbContext())
            {
                var data = context.EduPosts
                    .Where(m => m.dateTime > timeStamp && m.creator != userName)
                    .OrderByDescending(m => m.dateTime)
                    .Take(10)
                    .ToList();

                return data.Select(x => x.ToDto(IsPostNew(x.id, PostType.Education, userId)));
            }
        }

        private IEnumerable<NotificationViewModel> AddResearchBlogPosts(string userId, DateTime timeStamp, string userName)
        {
            using (var context = new ApplicationDbContext())
            {
                var data = context.ResearchBlogPosts
                    .Where(m => m.dateTime > timeStamp && m.creator != userName)
                    .OrderByDescending(m => m.dateTime)
                    .Take(10)
                    .ToList();

                return data.Select(x => x.ToDto(IsPostNew(x.id, PostType.Research, userId)));
            }
        }

        //private IEnumerable<NotificationViewModel> AddCalenderPost(string userId, DateTime timeStamp, string userName)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        var data = context.Calender
        //            .Where(m => m.dateTime > timeStamp && m.creator != userName)
        //            .OrderByDescending(m => m.dateTime)
        //            .Take(10)
        //            .ToList();

        //        return data.Select(x => x.ToDto(IsPostNew(x.id, PostType.Calender, userId)));
        //    }
        //}
        private bool IsPostNew(int id, PostType postType, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return !context.ViewedNotifications.Any(x =>
                    x.PostId == id &&
                    x.PostType == postType &&
                    x.UserId == userId);
            }
        }
    }
}