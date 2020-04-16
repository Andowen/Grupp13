namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedViewedNotifications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViewedNotifications",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PostID = c.Guid(nullable: false),
                        PostType = c.Int(nullable: false),
                        UserID = c.Guid(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ViewedNotifications");
        }
    }
}
