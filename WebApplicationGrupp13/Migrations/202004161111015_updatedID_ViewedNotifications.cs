namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedID_ViewedNotifications : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ViewedNotifications");
            AlterColumn("dbo.ViewedNotifications", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ViewedNotifications", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ViewedNotifications");
            AlterColumn("dbo.ViewedNotifications", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ViewedNotifications", "ID");
        }
    }
}
