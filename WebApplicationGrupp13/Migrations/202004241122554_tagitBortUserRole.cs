namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagitBortUserRole : DbMigration
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
                        hasVoted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Meetings", t => t.meetingId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.meetingId)
                .Index(t => t.userId);
            
            AddColumn("dbo.Meetings", "vote1", c => c.Int(nullable: false));
            AddColumn("dbo.Meetings", "vote2", c => c.Int(nullable: false));
            AddColumn("dbo.Meetings", "vote3", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeetingsUsers", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MeetingsUsers", "meetingId", "dbo.Meetings");
            DropIndex("dbo.MeetingsUsers", new[] { "userId" });
            DropIndex("dbo.MeetingsUsers", new[] { "meetingId" });
            DropColumn("dbo.Meetings", "vote3");
            DropColumn("dbo.Meetings", "vote2");
            DropColumn("dbo.Meetings", "vote1");
            DropTable("dbo.MeetingsUsers");
        }
    }
}
