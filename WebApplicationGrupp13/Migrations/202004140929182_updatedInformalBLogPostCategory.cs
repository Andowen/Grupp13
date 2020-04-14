namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedInformalBLogPostCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InformalBlogPostCategories",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InformalBlogPostCategories");
        }
    }
}
