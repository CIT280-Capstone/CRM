namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewClasses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            RenameColumn(table: "dbo.Orders", name: "CustomerID", newName: "CustomerID_ID");
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSubProduct = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Customers", "FirstName", c => c.String());
            AddColumn("dbo.Customers", "LastName", c => c.String());
            AddColumn("dbo.Customers", "TaxExempt", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "DeliveryAddress_ID", c => c.Int());
            AddColumn("dbo.Customers", "MailiingAddress_ID", c => c.Int());
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "IsDelivery", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "DeliveryAddress_ID", c => c.Int());
            AddColumn("dbo.Promotions", "StatrtTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Promotions", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Promotions", "ProductID_ID", c => c.Int());
            AlterColumn("dbo.Orders", "CustomerID_ID", c => c.Int());
            CreateIndex("dbo.Customers", "DeliveryAddress_ID");
            CreateIndex("dbo.Customers", "MailiingAddress_ID");
            CreateIndex("dbo.Orders", "CustomerID_ID");
            CreateIndex("dbo.Orders", "DeliveryAddress_ID");
            CreateIndex("dbo.Promotions", "ProductID_ID");
            AddForeignKey("dbo.Customers", "DeliveryAddress_ID", "dbo.Addresses", "ID");
            AddForeignKey("dbo.Customers", "MailiingAddress_ID", "dbo.Addresses", "ID");
            AddForeignKey("dbo.Orders", "DeliveryAddress_ID", "dbo.Addresses", "ID");
            AddForeignKey("dbo.Promotions", "ProductID_ID", "dbo.Products", "ID");
            AddForeignKey("dbo.Orders", "CustomerID_ID", "dbo.Customers", "ID");
            DropColumn("dbo.Customers", "CFN");
            DropColumn("dbo.Customers", "CLN");
            DropColumn("dbo.Customers", "email");
            DropColumn("dbo.Orders", "PromotionID");
            DropColumn("dbo.Orders", "StrAddress");
            DropColumn("dbo.Orders", "City");
            DropColumn("dbo.Orders", "ZipCode");
            DropColumn("dbo.Orders", "SubTotal");
            DropColumn("dbo.Orders", "PromoUsed");
            DropColumn("dbo.Promotions", "BeginDate");
            DropColumn("dbo.Promotions", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Promotions", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Promotions", "BeginDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "PromoUsed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "SubTotal", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "City", c => c.String());
            AddColumn("dbo.Orders", "StrAddress", c => c.String());
            AddColumn("dbo.Orders", "PromotionID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "email", c => c.String());
            AddColumn("dbo.Customers", "CLN", c => c.String());
            AddColumn("dbo.Customers", "CFN", c => c.String());
            DropForeignKey("dbo.Orders", "CustomerID_ID", "dbo.Customers");
            DropForeignKey("dbo.Promotions", "ProductID_ID", "dbo.Products");
            DropForeignKey("dbo.Orders", "DeliveryAddress_ID", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "MailiingAddress_ID", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "DeliveryAddress_ID", "dbo.Addresses");
            DropIndex("dbo.Promotions", new[] { "ProductID_ID" });
            DropIndex("dbo.Orders", new[] { "DeliveryAddress_ID" });
            DropIndex("dbo.Orders", new[] { "CustomerID_ID" });
            DropIndex("dbo.Customers", new[] { "MailiingAddress_ID" });
            DropIndex("dbo.Customers", new[] { "DeliveryAddress_ID" });
            AlterColumn("dbo.Orders", "CustomerID_ID", c => c.Int(nullable: false));
            DropColumn("dbo.Promotions", "ProductID_ID");
            DropColumn("dbo.Promotions", "EndTime");
            DropColumn("dbo.Promotions", "StatrtTime");
            DropColumn("dbo.Orders", "DeliveryAddress_ID");
            DropColumn("dbo.Orders", "IsDelivery");
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Customers", "MailiingAddress_ID");
            DropColumn("dbo.Customers", "DeliveryAddress_ID");
            DropColumn("dbo.Customers", "TaxExempt");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "FirstName");
            DropTable("dbo.Products");
            DropTable("dbo.Addresses");
            RenameColumn(table: "dbo.Orders", name: "CustomerID_ID", newName: "CustomerID");
            CreateIndex("dbo.Orders", "CustomerID");
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
        }
    }
}
