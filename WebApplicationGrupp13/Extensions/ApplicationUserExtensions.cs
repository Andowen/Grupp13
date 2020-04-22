using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Extensions
{
    public static class ApplicationUserExtensions
    {
        public static AdminViewModel ToDto(this ApplicationUser entity, string role)
        {
            var dto = new AdminViewModel
            {
                UserId = entity.Id,
                Name = $"{entity.Firstname} {entity.Lastname}",
                Email = entity.Email,
                Role = role,
                Image = entity.Img
            };

            return dto;
        }
    }
}