namespace SuiteProducts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Package_Id = c.Int(nullable: false, identity: true),
                        Package_Name = c.String(),
                        Price = c.Single(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Package_Id);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    Product_Id = c.Int(nullable: false, identity: true),
                    Product_Name = c.String(),
                    Price = c.Single(nullable: false),
                    Catagory = c.String(),
                    Description = c.String(),
                    Package_Id = c.Int(nullable: true),
                })
                .PrimaryKey(t => t.Product_Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id, cascadeDelete: true)
                .Index(t => t.Package_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Package_Id", "dbo.Packages");
            DropIndex("dbo.Products", new[] { "Package_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Packages");
        }
    }
}
