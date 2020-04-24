namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class votes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetings", "vote1", c => c.Int(nullable: false));
            AddColumn("dbo.Meetings", "vote2", c => c.Int(nullable: false));
            AddColumn("dbo.Meetings", "vote3", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetings", "vote3");
            DropColumn("dbo.Meetings", "vote2");
            DropColumn("dbo.Meetings", "vote1");
        }
    }
}
