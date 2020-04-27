namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDescriptionToMeeting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetings", "meetingDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetings", "meetingDescription");
        }
    }
}
