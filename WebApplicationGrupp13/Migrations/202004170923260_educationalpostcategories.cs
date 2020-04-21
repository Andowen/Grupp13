namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class educationalpostcategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationalPostCategories",
                c => new
                    {
                        category = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.category);
            
            AddColumn("dbo.EducationalPosts", "category", c => c.String());
            DropColumn("dbo.EducationalPosts", "subject");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EducationalPosts", "subject", c => c.String());
            DropColumn("dbo.EducationalPosts", "category");
            DropTable("dbo.EducationalPostCategories");
        }
    }
}
