namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_foreignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FormalBlogPosts", "category_name", "dbo.FormalBlogPostCategories");
            DropIndex("dbo.FormalBlogPosts", new[] { "category_name" });
            AddColumn("dbo.FormalBlogPosts", "category", c => c.String());
            DropColumn("dbo.FormalBlogPosts", "category_name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormalBlogPosts", "category_name", c => c.String(maxLength: 128));
            DropColumn("dbo.FormalBlogPosts", "category");
            CreateIndex("dbo.FormalBlogPosts", "category_name");
            AddForeignKey("dbo.FormalBlogPosts", "category_name", "dbo.FormalBlogPostCategories", "name");
        }
    }
}
