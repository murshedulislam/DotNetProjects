namespace SmallBusinessManagementSystemApp.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        LoyaltyPoint = c.Double(nullable: false),
                        Contact = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CustomerSales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        LoyaltyPoint = c.Double(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        GrandTotal = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        DiscountAmount = c.Double(nullable: false),
                        PayableAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.ProductSales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CustomerSaleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CustomerSales", t => t.CustomerSaleId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerSaleId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        ReorderLevel = c.Int(nullable: false),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
                        ManufacturedDate = c.DateTime(nullable: false, storeType: "date"),
                        ExpireDate = c.DateTime(nullable: false, storeType: "date"),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        NewMRP = c.Double(nullable: false),
                        Remarks = c.String(),
                        PurchaseSupplierId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseSuppliers", t => t.PurchaseSupplierId, cascadeDelete: true)
                .Index(t => t.PurchaseSupplierId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PurchaseSuppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        InvoiceNumber = c.String(),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 30),
                        ContactPerson = c.String(nullable: false, maxLength: 30),
                        Contact = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "PurchaseSupplierId", "dbo.PurchaseSuppliers");
            DropForeignKey("dbo.PurchaseSuppliers", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Purchases", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductSales", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductSales", "CustomerSaleId", "dbo.CustomerSales");
            DropForeignKey("dbo.CustomerSales", "CustomerId", "dbo.Customers");
            DropIndex("dbo.PurchaseSuppliers", new[] { "SupplierId" });
            DropIndex("dbo.Purchases", new[] { "ProductId" });
            DropIndex("dbo.Purchases", new[] { "PurchaseSupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.ProductSales", new[] { "CustomerSaleId" });
            DropIndex("dbo.ProductSales", new[] { "ProductId" });
            DropIndex("dbo.CustomerSales", new[] { "CustomerId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.PurchaseSuppliers");
            DropTable("dbo.Purchases");
            DropTable("dbo.Products");
            DropTable("dbo.ProductSales");
            DropTable("dbo.CustomerSales");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
        }
    }
}
