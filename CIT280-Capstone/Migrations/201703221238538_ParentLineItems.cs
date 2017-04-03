namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParentLineItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LineItems", "ParentLineItem_ID", c => c.Int());
            CreateIndex("dbo.LineItems", "ParentLineItem_ID");
            AddForeignKey("dbo.LineItems", "ParentLineItem_ID", "dbo.LineItems", "ID");
            DropColumn("dbo.LineItems", "IsSubItem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LineItems", "IsSubItem", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.LineItems", "ParentLineItem_ID", "dbo.LineItems");
            DropIndex("dbo.LineItems", new[] { "ParentLineItem_ID" });
            DropColumn("dbo.LineItems", "ParentLineItem_ID");
        }
    }
}
