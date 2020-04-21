namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fåbortpending : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ViewedNotifications", "PostId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ViewedNotifications", "PostId", c => c.String());
        }
    }
}
