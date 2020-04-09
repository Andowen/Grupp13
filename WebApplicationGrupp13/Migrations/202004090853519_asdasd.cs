namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormalBlogPosts",
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
            DropTable("dbo.FormalBlogPosts");
        }
    }
}
