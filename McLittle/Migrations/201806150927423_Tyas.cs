namespace McLittle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tyas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ShortDiscription = c.String(),
                        ImagePath = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Blogs");
        }
    }
}
