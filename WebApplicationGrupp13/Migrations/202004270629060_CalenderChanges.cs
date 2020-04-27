namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CalenderChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CalenderViewModels", "Start", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.CalenderViewModels", "End", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CalenderViewModels", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CalenderViewModels", "Start", c => c.DateTime(nullable: false));
        }
    }
}
