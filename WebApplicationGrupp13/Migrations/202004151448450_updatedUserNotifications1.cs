namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedUserNotifications1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserNotifications");
            AlterColumn("dbo.UserNotifications", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserNotifications", "UserId", c => c.String());
            AddPrimaryKey("dbo.UserNotifications", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserNotifications");
            AlterColumn("dbo.UserNotifications", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserNotifications", "ID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.UserNotifications", "ID");
        }
    }
}
