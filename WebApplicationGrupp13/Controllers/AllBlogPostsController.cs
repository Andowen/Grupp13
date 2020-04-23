using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationGrupp13.Models;

namespace WebApplicationGrupp13.Controllers
{
    public  class AllBlogPostsController : Controller
    {
        // GET: AllBlogPosts
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public List<FormalBlogPost> GetAllFormalBlogPostFromAuthor(string author) {
            
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var listOfMatchingBlogPosts = new List<FormalBlogPost>();
            var listOfAllBlogPosts = dbContext.BlogPosts.ToList();

            foreach(FormalBlogPost formalBlogPost in listOfAllBlogPosts) {
                if (formalBlogPost.creator.Equals(author)) {
                    listOfMatchingBlogPosts.Add(formalBlogPost);
                }
                
            }
            return listOfMatchingBlogPosts;

        }
        public List<InformalBlogPost> GetAllInformalBlogPostFromAuthor(string author) {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var listOfMatchingBlogPosts = new List<InformalBlogPost>();
            var listOfAllBlogPosts = dbContext.InformalBlogPosts.ToList();

            foreach (InformalBlogPost informalBlogPost in listOfAllBlogPosts) {
                if (informalBlogPost.creator.Equals(author)) {
                    listOfMatchingBlogPosts.Add(informalBlogPost);
                }

            }
            return listOfMatchingBlogPosts;

        }
        public List<EducationalPost> GetAllEducationalBlogPostFromAuthor(string author) {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var listOfMatchingBlogPosts = new List<EducationalPost>();
            var listOfAllBlogPosts = dbContext.EduPosts.ToList();

            foreach (EducationalPost educationalBlogPost in listOfAllBlogPosts) {
                if (educationalBlogPost.creator.Equals(author)) {
                    listOfMatchingBlogPosts.Add(educationalBlogPost);
                }

            }
            return listOfMatchingBlogPosts;

        }
        public List<ResearchBlogPost> GetAllResearchBlogPostFromAuthor(string author) {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var listOfMatchingBlogPosts = new List<ResearchBlogPost>();
            var listOfAllBlogPosts = dbContext.ResearchBlogPosts.ToList();

            foreach (ResearchBlogPost researchBlogPost in listOfAllBlogPosts) {
                if (researchBlogPost.creator.Equals(author)) {
                    listOfMatchingBlogPosts.Add(researchBlogPost);
                }

            }
            return listOfMatchingBlogPosts;

        }

    }
}