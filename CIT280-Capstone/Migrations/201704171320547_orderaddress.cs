namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderaddress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "IsDelivery");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "IsDelivery", c => c.Boolean(nullable: false));
        }
    }
}
