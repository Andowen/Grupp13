namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bytte_filtyp_i_formalblogpost : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FormalBlogPosts", "fileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormalBlogPosts", "fileName", c => c.String());
        }
    }
}
