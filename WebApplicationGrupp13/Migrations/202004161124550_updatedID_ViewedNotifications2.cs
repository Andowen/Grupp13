namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedID_ViewedNotifications2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ViewedNotifications");
            AddColumn("dbo.ViewedNotifications", "ViewedId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ViewedNotifications", "ViewedId");
            DropColumn("dbo.ViewedNotifications", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ViewedNotifications", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ViewedNotifications");
            DropColumn("dbo.ViewedNotifications", "ViewedId");
            AddPrimaryKey("dbo.ViewedNotifications", "ID");
        }
    }
}
