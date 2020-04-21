namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filuppladdning_informel_utbildning : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EducationalPosts", "fileName", c => c.String());
            AddColumn("dbo.InformalBlogPosts", "fileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InformalBlogPosts", "fileName");
            DropColumn("dbo.EducationalPosts", "fileName");
        }
    }
}
