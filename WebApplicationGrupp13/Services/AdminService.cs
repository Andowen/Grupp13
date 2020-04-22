using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Extensions;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Services
{
    public class AdminService
    {
        public IEnumerable<AdminViewModel> GetUsers(string currentUser, string roleId, string roleType)
        {
            if (roleType == "Admin")
            {
                using (var context = new ApplicationDbContext())
                {
                    var users = context.Users
                        .Where(x => x.Id != currentUser && x.UserName != "admin@admin.com")
                        .ToList();
                    return users.Select(x => x.ToDto(GetUserRole(x.Id, roleId, roleType)));
                }
            }
            else
            {
                using (var context = new ApplicationDbContext())
                {
                  
                    var AdminId = context.Roles.FirstOrDefault(r => r.Name == "Admin").Id;
                    var users = context.Users
                        .Where(x => x.Id != currentUser && x.UserName != "admin@admin.com" && x.Roles.Any(r => r.RoleId != AdminId))
                        .ToList();
                    return users.Select(x => x.ToDto(GetUserRole(x.Id, roleId, roleType)));
                }
            }

        }

        public string GetUserRole(string userId, string roleId, string roleType)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users
                     .FirstOrDefault(x => x.Id == userId);

                var role = "";
                if (roleType == "Admin")
                {
                    if (user.Roles.Any(r => r.RoleId == roleId))
                    {
                        role = "Admin";
                    }
                    else
                    {
                        role = "User";
                    }
                }
                else
                {
                    if (user.Roles.Any(r => r.RoleId == roleId))
                    {
                        role = "Authorized";
                    }
                    else
                    {
                        role = "User";
                    }

                }

                return role;
            }
        }
    }
}