namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCreatorToCalendar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalenderViewModels", "Creator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CalenderViewModels", "Creator");
        }
    }
}
