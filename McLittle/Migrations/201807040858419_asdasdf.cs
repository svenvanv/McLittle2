namespace McLittle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "EAN", c => c.Long(nullable: false));
            AddColumn("dbo.OrderDetails", "EAN", c => c.Long(nullable: false));
            DropColumn("dbo.Carts", "AlbumId");
            DropColumn("dbo.OrderDetails", "AlbumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "AlbumId", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "AlbumId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "EAN");
            DropColumn("dbo.Carts", "EAN");
        }
    }
}
