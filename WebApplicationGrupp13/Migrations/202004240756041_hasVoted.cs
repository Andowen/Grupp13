namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hasVoted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MeetingsUsers", "hasVoted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MeetingsUsers", "hasVoted");
        }
    }
}
