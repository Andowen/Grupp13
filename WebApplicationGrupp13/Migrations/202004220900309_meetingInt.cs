namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meetingInt : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Meetings");
            AlterColumn("dbo.Meetings", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Meetings", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Meetings");
            AlterColumn("dbo.Meetings", "id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Meetings", "id");
        }
    }
}
