namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fileupload_formalblogpost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormalBlogPosts", "fileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FormalBlogPosts", "fileName");
        }
    }
}
