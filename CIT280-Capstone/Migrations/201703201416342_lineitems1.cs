namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lineitems1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LineItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        IsSubItem = c.Boolean(nullable: false),
                        OrderID_ID = c.Int(),
                        ProductID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID_ID)
                .ForeignKey("dbo.Products", t => t.ProductID_ID)
                .Index(t => t.OrderID_ID)
                .Index(t => t.ProductID_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineItems", "ProductID_ID", "dbo.Products");
            DropForeignKey("dbo.LineItems", "OrderID_ID", "dbo.Orders");
            DropIndex("dbo.LineItems", new[] { "ProductID_ID" });
            DropIndex("dbo.LineItems", new[] { "OrderID_ID" });
            DropTable("dbo.LineItems");
        }
    }
}
