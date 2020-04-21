namespace WebApplicationGrupp13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        author = c.String(),
                        commentText = c.String(),
                        dateTime = c.DateTime(nullable: false),
                        blogPostId = c.Int(nullable: false),
                        blogPostType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
          
        }
        
        public override void Down()
        {
            
        }
    }
}
