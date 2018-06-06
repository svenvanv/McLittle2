namespace McLittle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectbasis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        EAN = c.Long(nullable: false),
                        title = c.String(),
                        brand = c.String(),
                        shortDesc = c.String(),
                        fullDesc = c.String(),
                        imageLink = c.String(),
                        weight = c.String(),
                        price = c.Single(nullable: false),
                        category = c.String(),
                        subCategory = c.String(),
                        subsubCategory = c.String(),
                    })
                .PrimaryKey(t => t.productId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.SubSubCategories",
                c => new
                    {
                        SubSubCategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.SubSubCategoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubSubCategories");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
