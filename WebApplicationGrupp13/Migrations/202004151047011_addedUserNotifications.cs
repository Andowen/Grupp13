namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserNotifications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        SelectedNotification = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserNotifications");
        }
    }
}
