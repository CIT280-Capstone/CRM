namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addresschange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Promo_id", "dbo.Promotions");
            DropForeignKey("dbo.Orders", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Promo_id" });
            DropIndex("dbo.Orders", new[] { "Customer_ID" });
            RenameColumn(table: "dbo.Orders", name: "Customer_ID", newName: "CustomerID");
            AddColumn("dbo.Orders", "PromotionID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "StrAddress", c => c.String());
            AddColumn("dbo.Orders", "City", c => c.String());
            AddColumn("dbo.Orders", "ZipCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CustomerID");
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
            DropColumn("dbo.Customers", "StrAddress");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "ZipCode");
            DropColumn("dbo.Orders", "Promo_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Promo_id", c => c.Int());
            AddColumn("dbo.Customers", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "StrAddress", c => c.String());
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            AlterColumn("dbo.Orders", "CustomerID", c => c.Int());
            DropColumn("dbo.Orders", "ZipCode");
            DropColumn("dbo.Orders", "City");
            DropColumn("dbo.Orders", "StrAddress");
            DropColumn("dbo.Orders", "PromotionID");
            RenameColumn(table: "dbo.Orders", name: "CustomerID", newName: "Customer_ID");
            CreateIndex("dbo.Orders", "Customer_ID");
            CreateIndex("dbo.Orders", "Promo_id");
            AddForeignKey("dbo.Orders", "Customer_ID", "dbo.Customers", "ID");
            AddForeignKey("dbo.Orders", "Promo_id", "dbo.Promotions", "id");
        }
    }
}
