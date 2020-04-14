namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class formalblogpost_added_category_field : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormalBlogPosts", "category_name", c => c.String(maxLength: 128));
            CreateIndex("dbo.FormalBlogPosts", "category_name");
            AddForeignKey("dbo.FormalBlogPosts", "category_name", "dbo.FormalBlogPostCategories", "name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FormalBlogPosts", "category_name", "dbo.FormalBlogPostCategories");
            DropIndex("dbo.FormalBlogPosts", new[] { "category_name" });
            DropColumn("dbo.FormalBlogPosts", "category_name");
        }
    }
}
