namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedUserNotifications : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserNotifications");
            AddColumn("dbo.UserNotifications", "ID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.UserNotifications", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserNotifications");
            DropColumn("dbo.UserNotifications", "ID");
            AddPrimaryKey("dbo.UserNotifications", "UserId");
        }
    }
}
