namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormalBlogpostCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormalBlogPostCategories",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FormalBlogPostCategories");
        }
    }
}
