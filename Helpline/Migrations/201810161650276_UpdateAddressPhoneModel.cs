namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddressPhoneModel : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM PhoneNumbers");
            Sql("DELETE FROM Addresses");

            AddColumn("dbo.Addresses", "ContactId", c => c.Int(nullable: false));
            AddColumn("dbo.PhoneNumbers", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "ContactId");
            CreateIndex("dbo.PhoneNumbers", "ContactId");
            AddForeignKey("dbo.Addresses", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PhoneNumbers", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Addresses", "ContactId", "dbo.Contacts");
            DropIndex("dbo.PhoneNumbers", new[] { "ContactId" });
            DropIndex("dbo.Addresses", new[] { "ContactId" });
            DropColumn("dbo.PhoneNumbers", "ContactId");
            DropColumn("dbo.Addresses", "ContactId");
        }
    }
}
