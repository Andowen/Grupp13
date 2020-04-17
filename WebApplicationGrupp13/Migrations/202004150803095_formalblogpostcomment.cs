namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class formalblogpostcomment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormalBlogPostComments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comment = c.String(),
                        author = c.String(),
                        dateTime = c.DateTime(nullable: false),
                        formalBlogPost_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.FormalBlogPosts", t => t.formalBlogPost_id)
                .Index(t => t.formalBlogPost_id);
            
           
         
        }
        
        public override void Down()
        {
           
            DropForeignKey("dbo.FormalBlogPostComments", "formalBlogPost_id", "dbo.FormalBlogPosts");
            DropIndex("dbo.FormalBlogPostComments", new[] { "formalBlogPost_id" });
           
            DropTable("dbo.FormalBlogPostComments");
        }
    }
}
