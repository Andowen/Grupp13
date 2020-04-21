namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class giulia : DbMigration
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
            

        }
        
        public override void Down()
        {
         
            DropTable("dbo.Meetings");

        }
    }
}
