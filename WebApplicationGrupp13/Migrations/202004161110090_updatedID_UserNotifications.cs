namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedID_UserNotifications : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserNotifications");
            AlterColumn("dbo.UserNotifications", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserNotifications", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserNotifications");
            AlterColumn("dbo.UserNotifications", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserNotifications", "ID");
        }
    }
}
