namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latillmigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "IsSelected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsSelected", c => c.Boolean(nullable: false));
        }
    }
}
