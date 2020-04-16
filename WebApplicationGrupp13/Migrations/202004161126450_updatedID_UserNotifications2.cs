namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedID_UserNotifications2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserNotifications");
            AddColumn("dbo.UserNotifications", "UserNotiId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserNotifications", "UserNotiId");
            DropColumn("dbo.UserNotifications", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserNotifications", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UserNotifications");
            DropColumn("dbo.UserNotifications", "UserNotiId");
            AddPrimaryKey("dbo.UserNotifications", "Id");
        }
    }
}
