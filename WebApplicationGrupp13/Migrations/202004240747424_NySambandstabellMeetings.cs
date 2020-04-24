namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NySambandstabellMeetings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeetingsUsers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        meetingId = c.Int(nullable: false),
                        userId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Meetings", t => t.meetingId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.meetingId)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeetingsUsers", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MeetingsUsers", "meetingId", "dbo.Meetings");
            DropIndex("dbo.MeetingsUsers", new[] { "userId" });
            DropIndex("dbo.MeetingsUsers", new[] { "meetingId" });
            DropTable("dbo.MeetingsUsers");
        }
    }
}
