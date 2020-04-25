namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedColumnToMeetingsUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MeetingsUsers", "votedOn", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MeetingsUsers", "votedOn");
        }
    }
}
