namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namechange2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FormalBlogPosts", name: "category_name_name", newName: "category_name");
            RenameIndex(table: "dbo.FormalBlogPosts", name: "IX_category_name_name", newName: "IX_category_name");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.FormalBlogPosts", name: "IX_category_name", newName: "IX_category_name_name");
            RenameColumn(table: "dbo.FormalBlogPosts", name: "category_name", newName: "category_name_name");
        }
    }
}
