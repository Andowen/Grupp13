using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplicationGrupp13.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Förnamn")]
        public string Firstname { get; set; }
        [Display(Name = "Efternamn")]
        public string Lastname { get; set; }
        [Display(Name = "Mobilnummer")]
        public string Mobilenumber { get; set; }
        [Display(Name = "Profilbild")]
        public string Img { get; set; }
  
      


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<FormalBlogPost> BlogPosts { get; set; }
        public DbSet<CalenderViewModel> Calender { get; set; }
        public DbSet<EducationalPost> EduPosts { get; set; }
        public DbSet<EducationalPostCategory> EducationalPostCategories { get; set; }

        public DbSet<FormalBlogPostCategory> FormalBlogPostCategories { get; set; }

        public DbSet<InformalBlogPost> InformalBlogPosts { get; set; }
        public DbSet<InformalBlogPostCategory> InformalBlogPostCategories { get; set; }

        public DbSet<ResearchBlogPost> ResearchBlogPosts { get; set; }

        public DbSet<ResearchBlogPostCategory> ResearchBlogPostCategories { get; set; }
      //  public DbSet<FormalBlogPostComment> FormalBlogPostComments { get; set; }

        public DbSet<UserNotifications> UserNotifications { get; set; }
        public DbSet<ViewedNotifications> ViewedNotifications { get; set; }

      //  public System.Data.Entity.DbSet<WebApplicationGrupp13.Models.Meetings> Meetings { get; set; }
        public DbSet<Meetings> Meeting { get; set; }



        public DbSet<FormalBlogPostComment> FormalBlogPostComments { get; set; }

        public DbSet<EducationalBlogPostComment> EducationalBlogPostComments { get; set; }

        public DbSet<InformalBlogPostComment> InformalBlogPostComments { get; set; }

        public DbSet<ResearchBlogPostComment> ResearchBlogPostComments { get; set; }

        public DbSet<MeetingsUsers> MeetingsUsers { get; set; }
    }
}