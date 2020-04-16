namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meetMeetings : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserNotifications");
            DropPrimaryKey("dbo.ViewedNotifications");
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        meetingName = c.String(),
                        date1 = c.DateTime(nullable: false),
                        date2 = c.DateTime(nullable: false),
                        date3 = c.DateTime(nullable: false),
                        creator = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.UserNotifications", "UserNotiId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ViewedNotifications", "ViewedId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserNotifications", "UserNotiId");
            AddPrimaryKey("dbo.ViewedNotifications", "ViewedId");
            DropColumn("dbo.UserNotifications", "ID");
            DropColumn("dbo.ViewedNotifications", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ViewedNotifications", "ID", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UserNotifications", "ID", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.ViewedNotifications");
            DropPrimaryKey("dbo.UserNotifications");
            DropColumn("dbo.ViewedNotifications", "ViewedId");
            DropColumn("dbo.UserNotifications", "UserNotiId");
            DropTable("dbo.Meetings");
            AddPrimaryKey("dbo.ViewedNotifications", "ID");
            AddPrimaryKey("dbo.UserNotifications", "ID");
        }
    }
}
