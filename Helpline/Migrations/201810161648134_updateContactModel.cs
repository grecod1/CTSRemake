namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateContactModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Contacts", "PhoneNumberId", "dbo.PhoneNumbers");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropIndex("dbo.Contacts", new[] { "PhoneNumberId" });
            DropIndex("dbo.Contacts", new[] { "AddressId" });
            DropIndex("dbo.Contacts", new[] { "UserId" });
            CreateTable(
                "dbo.TicketPhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        PhoneNumberId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhoneNumbers", t => t.PhoneNumberId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.PhoneNumberId);
            
            DropColumn("dbo.Contacts", "PhoneNumberId");
            DropColumn("dbo.Contacts", "AddressId");
            DropColumn("dbo.Contacts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "PhoneNumberId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TicketPhoneNumbers", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketPhoneNumbers", "PhoneNumberId", "dbo.PhoneNumbers");
            DropIndex("dbo.TicketPhoneNumbers", new[] { "PhoneNumberId" });
            DropIndex("dbo.TicketPhoneNumbers", new[] { "TicketId" });
            DropTable("dbo.TicketPhoneNumbers");
            CreateIndex("dbo.Contacts", "UserId");
            CreateIndex("dbo.Contacts", "AddressId");
            CreateIndex("dbo.Contacts", "PhoneNumberId");
            AddForeignKey("dbo.Contacts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "PhoneNumberId", "dbo.PhoneNumbers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
