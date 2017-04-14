namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "DeliveryAddress_ID", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "CustomerID_ID", "dbo.Customers");
            DropForeignKey("dbo.Promotions", "ProductID_ID", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "CustomerID_ID" });
            DropIndex("dbo.Orders", new[] { "DeliveryAddress_ID" });
            DropIndex("dbo.Promotions", new[] { "ProductID_ID" });
            RenameColumn(table: "dbo.Orders", name: "DeliveryAddress_ID", newName: "DeliveryAddressID");
            RenameColumn(table: "dbo.Orders", name: "CustomerID_ID", newName: "CustomerID");
            RenameColumn(table: "dbo.Promotions", name: "ProductID_ID", newName: "ProductID");
            AlterColumn("dbo.Orders", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "DeliveryAddressID", c => c.Int(nullable: false));
            AlterColumn("dbo.Promotions", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CustomerID");
            CreateIndex("dbo.Orders", "DeliveryAddressID");
            CreateIndex("dbo.Promotions", "ProductID");
            AddForeignKey("dbo.Orders", "DeliveryAddressID", "dbo.Addresses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Promotions", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Promotions", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "DeliveryAddressID", "dbo.Addresses");
            DropIndex("dbo.Promotions", new[] { "ProductID" });
            DropIndex("dbo.Orders", new[] { "DeliveryAddressID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            AlterColumn("dbo.Promotions", "ProductID", c => c.Int());
            AlterColumn("dbo.Orders", "DeliveryAddressID", c => c.Int());
            AlterColumn("dbo.Orders", "CustomerID", c => c.Int());
            RenameColumn(table: "dbo.Promotions", name: "ProductID", newName: "ProductID_ID");
            RenameColumn(table: "dbo.Orders", name: "CustomerID", newName: "CustomerID_ID");
            RenameColumn(table: "dbo.Orders", name: "DeliveryAddressID", newName: "DeliveryAddress_ID");
            CreateIndex("dbo.Promotions", "ProductID_ID");
            CreateIndex("dbo.Orders", "DeliveryAddress_ID");
            CreateIndex("dbo.Orders", "CustomerID_ID");
            AddForeignKey("dbo.Promotions", "ProductID_ID", "dbo.Products", "ID");
            AddForeignKey("dbo.Orders", "CustomerID_ID", "dbo.Customers", "ID");
            AddForeignKey("dbo.Orders", "DeliveryAddress_ID", "dbo.Addresses", "ID");
        }
    }
}
