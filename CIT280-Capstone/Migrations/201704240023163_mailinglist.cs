namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mailinglist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Promotions", "ProductID", "dbo.Products");
            DropIndex("dbo.Promotions", new[] { "ProductID" });
            CreateTable(
                "dbo.MailingLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Customers", "Email", c => c.String());
            AddColumn("dbo.Customers", "MailingList_ID", c => c.Int());
            CreateIndex("dbo.Customers", "MailingList_ID");
            AddForeignKey("dbo.Customers", "MailingList_ID", "dbo.MailingLists", "ID");
            DropTable("dbo.Promotions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.Customers", "MailingList_ID", "dbo.MailingLists");
            DropIndex("dbo.Customers", new[] { "MailingList_ID" });
            DropColumn("dbo.Customers", "MailingList_ID");
            DropColumn("dbo.Customers", "Email");
            DropTable("dbo.MailingLists");
            CreateIndex("dbo.Promotions", "ProductID");
            AddForeignKey("dbo.Promotions", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
