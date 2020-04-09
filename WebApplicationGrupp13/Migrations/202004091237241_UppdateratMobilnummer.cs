namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UppdateratMobilnummer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Mobilenumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Mobilenumber");
        }
    }
}
