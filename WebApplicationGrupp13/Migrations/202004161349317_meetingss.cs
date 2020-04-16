namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meetingss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        meetingName = c.String(),
                        date1 = c.DateTime(nullable: false),
                        date2 = c.DateTime(nullable: false),
                        date3 = c.DateTime(nullable: false),
                        creator = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Meetings");
        }
    }
}
