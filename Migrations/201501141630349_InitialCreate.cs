namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeId = c.Int(nullable: false),
                        Description = c.String(),
                        SupplierId = c.Int(nullable: false),
                        Brand = c.String(),
                        Tags = c.String(),
                        WholesalePrice = c.Single(nullable: false),
                        RetailPrice = c.Single(nullable: false),
                        BuyPrice = c.Single(nullable: false),
                        InitialCostPrice = c.Single(nullable: false),
                        Stock = c.Int(nullable: false),
                        Taxable = c.Boolean(nullable: false),
                        ManageStock = c.Boolean(nullable: false),
                        KeepSelling = c.Boolean(nullable: false),
                        PublishOnline = c.Boolean(nullable: false),
                        OnlineOrdering = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
