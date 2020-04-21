namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profilBild : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Img", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Img");
        }
    }
}
