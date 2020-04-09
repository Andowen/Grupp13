namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogpost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationalPosts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        postText = c.String(),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EducationalPosts");
        }
    }
}
