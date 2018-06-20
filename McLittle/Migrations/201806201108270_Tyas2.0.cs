namespace McLittle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tyas20 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Blogs");
        }
        
        public override void Down()
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
    }
}
