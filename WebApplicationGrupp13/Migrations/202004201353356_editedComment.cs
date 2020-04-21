namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedComment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "blogPostType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "blogPostType", c => c.Int(nullable: false));
        }
    }
}
