namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isSelected : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsSelected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsSelected");
        }
    }
}
