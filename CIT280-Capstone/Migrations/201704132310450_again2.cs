namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class again2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "DeliveryAddress_ID", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "MailingAddress_ID", "dbo.Addresses");
            DropForeignKey("dbo.LineItems", "OrderID_ID", "dbo.Orders");
            DropForeignKey("dbo.LineItems", "ProductID_ID", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "DeliveryAddress_ID" });
            DropIndex("dbo.Customers", new[] { "MailingAddress_ID" });
            DropIndex("dbo.LineItems", new[] { "OrderID_ID" });
            DropIndex("dbo.LineItems", new[] { "ParentLineItem_ID" });
            DropIndex("dbo.LineItems", new[] { "ProductID_ID" });
            RenameColumn(table: "dbo.Customers", name: "DeliveryAddress_ID", newName: "DeliveryAddressID");
            RenameColumn(table: "dbo.Customers", name: "MailingAddress_ID", newName: "MailingAddressID");
            RenameColumn(table: "dbo.LineItems", name: "ParentLineItem_ID", newName: "ParentLineItemID");
            RenameColumn(table: "dbo.LineItems", name: "OrderID_ID", newName: "OrderID");
            RenameColumn(table: "dbo.LineItems", name: "ProductID_ID", newName: "ProductID");
            AlterColumn("dbo.Customers", "DeliveryAddressID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "MailingAddressID", c => c.Int(nullable: false));
            AlterColumn("dbo.LineItems", "OrderID", c => c.Int(nullable: false));
            AlterColumn("dbo.LineItems", "ParentLineItemID", c => c.Int(nullable: false));
            AlterColumn("dbo.LineItems", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "DeliveryAddressID");
            CreateIndex("dbo.Customers", "MailingAddressID");
            CreateIndex("dbo.LineItems", "OrderID");
            CreateIndex("dbo.LineItems", "ProductID");
            CreateIndex("dbo.LineItems", "ParentLineItemID");
            AddForeignKey("dbo.Customers", "DeliveryAddressID", "dbo.Addresses", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Customers", "MailingAddressID", "dbo.Addresses", "ID", cascadeDelete: false);
            AddForeignKey("dbo.LineItems", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.LineItems", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.LineItems", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Customers", "MailingAddressID", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "DeliveryAddressID", "dbo.Addresses");
            DropIndex("dbo.LineItems", new[] { "ParentLineItemID" });
            DropIndex("dbo.LineItems", new[] { "ProductID" });
            DropIndex("dbo.LineItems", new[] { "OrderID" });
            DropIndex("dbo.Customers", new[] { "MailingAddressID" });
            DropIndex("dbo.Customers", new[] { "DeliveryAddressID" });
            AlterColumn("dbo.LineItems", "ProductID", c => c.Int());
            AlterColumn("dbo.LineItems", "ParentLineItemID", c => c.Int());
            AlterColumn("dbo.LineItems", "OrderID", c => c.Int());
            AlterColumn("dbo.Customers", "MailingAddressID", c => c.Int());
            AlterColumn("dbo.Customers", "DeliveryAddressID", c => c.Int());
            RenameColumn(table: "dbo.LineItems", name: "ProductID", newName: "ProductID_ID");
            RenameColumn(table: "dbo.LineItems", name: "OrderID", newName: "OrderID_ID");
            RenameColumn(table: "dbo.LineItems", name: "ParentLineItemID", newName: "ParentLineItem_ID");
            RenameColumn(table: "dbo.Customers", name: "MailingAddressID", newName: "MailingAddress_ID");
            RenameColumn(table: "dbo.Customers", name: "DeliveryAddressID", newName: "DeliveryAddress_ID");
            CreateIndex("dbo.LineItems", "ProductID_ID");
            CreateIndex("dbo.LineItems", "ParentLineItem_ID");
            CreateIndex("dbo.LineItems", "OrderID_ID");
            CreateIndex("dbo.Customers", "MailingAddress_ID");
            CreateIndex("dbo.Customers", "DeliveryAddress_ID");
            AddForeignKey("dbo.LineItems", "ProductID_ID", "dbo.Products", "ID");
            AddForeignKey("dbo.LineItems", "OrderID_ID", "dbo.Orders", "ID");
            AddForeignKey("dbo.Customers", "MailingAddress_ID", "dbo.Addresses", "ID");
            AddForeignKey("dbo.Customers", "DeliveryAddress_ID", "dbo.Addresses", "ID");
        }
    }
}
