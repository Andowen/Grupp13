namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class educationalpost_properties_change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EducationalPosts", "creator", c => c.String());
            AddColumn("dbo.EducationalPosts", "dateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.EducationalPosts", "subject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EducationalPosts", "subject");
            DropColumn("dbo.EducationalPosts", "dateTime");
            DropColumn("dbo.EducationalPosts", "creator");
        }
    }
}
