namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormalBlogpost_creator_dateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormalBlogPosts", "creator", c => c.String());
            AddColumn("dbo.FormalBlogPosts", "dateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FormalBlogPosts", "dateTime");
            DropColumn("dbo.FormalBlogPosts", "creator");
        }
    }
}
