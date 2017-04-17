namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderaddress2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "DeliveryAddressID", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "DeliveryAddressID" });
            AlterColumn("dbo.Orders", "DeliveryAddressID", c => c.Int());
            CreateIndex("dbo.Orders", "DeliveryAddressID");
            AddForeignKey("dbo.Orders", "DeliveryAddressID", "dbo.Addresses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "DeliveryAddressID", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "DeliveryAddressID" });
            AlterColumn("dbo.Orders", "DeliveryAddressID", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "DeliveryAddressID");
            AddForeignKey("dbo.Orders", "DeliveryAddressID", "dbo.Addresses", "ID", cascadeDelete: true);
        }
    }
}
