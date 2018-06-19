namespace McLittle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoriess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        discountId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        EAN = c.Long(nullable: false),
                        price = c.Double(nullable: false),
                        validUntil = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.discountId);
            
            AddColumn("dbo.SubCategories", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.SubSubCategories", "SubCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubCategories", "CategoryId");
            CreateIndex("dbo.SubSubCategories", "SubCategoryId");
            AddForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.SubSubCategories", "SubCategoryId", "dbo.SubCategories", "SubCategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubSubCategories", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SubSubCategories", new[] { "SubCategoryId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropColumn("dbo.SubSubCategories", "SubCategoryId");
            DropColumn("dbo.SubCategories", "CategoryId");
            DropTable("dbo.Discounts");
        }
    }
}
