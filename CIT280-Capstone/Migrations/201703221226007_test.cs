namespace CIT280_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "MailiingAddress_ID", newName: "MailingAddress_ID");
            RenameIndex(table: "dbo.Customers", name: "IX_MailiingAddress_ID", newName: "IX_MailingAddress_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_MailingAddress_ID", newName: "IX_MailiingAddress_ID");
            RenameColumn(table: "dbo.Customers", name: "MailingAddress_ID", newName: "MailiingAddress_ID");
        }
    }
}
