namespace McLittle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tyas4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubCategories", "ImageUrl", c => c.String());
            AddColumn("dbo.SubSubCategories", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubSubCategories", "ImageUrl");
            DropColumn("dbo.SubCategories", "ImageUrl");
        }
    }
}
