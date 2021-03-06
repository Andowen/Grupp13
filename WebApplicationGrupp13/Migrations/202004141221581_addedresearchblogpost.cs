namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedresearchblogpost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResearchBlogPosts",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    postText = c.String(),
                    title = c.String(),
                    creator = c.String(),
                    dateTime = c.DateTime(nullable: false),
                    category = c.String(),
                })
                .PrimaryKey(t => t.id);

        }

        public override void Down()
        {
            DropTable("dbo.ResearchBlogPosts");
        }
    }
}
