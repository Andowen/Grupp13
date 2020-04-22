namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fil_research : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResearchBlogPosts", "fileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResearchBlogPosts", "fileName");
        }
    }
}
