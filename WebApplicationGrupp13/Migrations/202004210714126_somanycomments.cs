namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somanycomments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationalBlogPostComments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        author = c.String(),
                        commentText = c.String(),
                        dateTime = c.DateTime(nullable: false),
                        blogPostId = c.Int(nullable: false),
                        blogPostType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.InformalBlogPostComments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        author = c.String(),
                        commentText = c.String(),
                        dateTime = c.DateTime(nullable: false),
                        blogPostId = c.Int(nullable: false),
                        blogPostType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ResearchBlogPostComments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        author = c.String(),
                        commentText = c.String(),
                        dateTime = c.DateTime(nullable: false),
                        blogPostId = c.Int(nullable: false),
                        blogPostType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResearchBlogPostComments");
            DropTable("dbo.InformalBlogPostComments");
            DropTable("dbo.EducationalBlogPostComments");
        }
    }
}
