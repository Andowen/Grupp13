namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anothercommentrename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Comments", newName: "FormalBlogPostComments");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FormalBlogPostComments", newName: "Comments");
        }
    }
}
