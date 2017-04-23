namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postalcode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "ZipCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "ZipCode", c => c.Int(nullable: false));
        }
    }
}
