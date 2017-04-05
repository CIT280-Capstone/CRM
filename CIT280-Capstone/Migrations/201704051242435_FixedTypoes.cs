namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedTypoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotions", "StartTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Promotions", "StatrtTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Promotions", "StatrtTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Promotions", "StartTime");
        }
    }
}
