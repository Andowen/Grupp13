namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedViewedNotifications : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ViewedNotifications");
            AlterColumn("dbo.ViewedNotifications", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ViewedNotifications", "PostID", c => c.String());
            AlterColumn("dbo.ViewedNotifications", "UserID", c => c.String());
            AddPrimaryKey("dbo.ViewedNotifications", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ViewedNotifications");
            AlterColumn("dbo.ViewedNotifications", "UserID", c => c.Guid(nullable: false));
            AlterColumn("dbo.ViewedNotifications", "PostID", c => c.Guid(nullable: false));
            AlterColumn("dbo.ViewedNotifications", "ID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.ViewedNotifications", "ID");
        }
    }
}
