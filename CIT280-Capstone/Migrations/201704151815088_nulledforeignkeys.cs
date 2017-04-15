namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nulledforeignkeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "DeliveryAddressID", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "MailingAddressID", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "DeliveryAddressID" });
            DropIndex("dbo.Customers", new[] { "MailingAddressID" });
            AlterColumn("dbo.Customers", "DeliveryAddressID", c => c.Int());
            AlterColumn("dbo.Customers", "MailingAddressID", c => c.Int());
            CreateIndex("dbo.Customers", "DeliveryAddressID");
            CreateIndex("dbo.Customers", "MailingAddressID");
            AddForeignKey("dbo.Customers", "DeliveryAddressID", "dbo.Addresses", "ID");
            AddForeignKey("dbo.Customers", "MailingAddressID", "dbo.Addresses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MailingAddressID", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "DeliveryAddressID", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "MailingAddressID" });
            DropIndex("dbo.Customers", new[] { "DeliveryAddressID" });
            AlterColumn("dbo.Customers", "MailingAddressID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "DeliveryAddressID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MailingAddressID");
            CreateIndex("dbo.Customers", "DeliveryAddressID");
            AddForeignKey("dbo.Customers", "MailingAddressID", "dbo.Addresses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "DeliveryAddressID", "dbo.Addresses", "ID", cascadeDelete: true);
        }
    }
}
