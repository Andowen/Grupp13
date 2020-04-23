using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Extensions;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Services
{
    public class AdminService
    {
        public IEnumerable<AdminViewModel> GetUsers(string currentUser, string roleType)
        {
            using (var context = new ApplicationDbContext())
            {
                var AdminId = context.Roles.FirstOrDefault(r => r.Name == "Admin").Id;
                var roles = context.Roles.ToList();

                var users = context.Users
                    .Where(x =>
                        (x.Id != currentUser && x.UserName != "admin@admin.com") &&
                        (roleType == "Admin") || (x.Roles.Any(r => r.RoleId != AdminId))
                        )
                    .ToList();

                return GetUserRoles(roles, users);
            }


        }

        private IEnumerable<AdminViewModel> GetUserRoles(List<IdentityRole> roles, List<ApplicationUser> users)
        {
            var result = new List<AdminViewModel>();
            foreach(var user in users)
            {
                var userRoleIds = user.Roles.Select(x => x.RoleId);
                var userRoles = roles.Where(x => userRoleIds.Contains(x.Id)).Select(x => x.Name);

                result.Add(user.ToDto(String.Join(", ", userRoles)));
            }

            return result;
        }

      
    }
}