namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTicketName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketAddresses", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.TicketAddresses", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketNames", "NameId", "dbo.Names");
            DropForeignKey("dbo.TicketNames", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketPhoneNumbers", "PhoneNumberId", "dbo.PhoneNumbers");
            DropForeignKey("dbo.TicketPhoneNumbers", "TicketId", "dbo.Tickets");
            DropIndex("dbo.TicketAddresses", new[] { "TicketId" });
            DropIndex("dbo.TicketAddresses", new[] { "AddressId" });
            DropIndex("dbo.TicketNames", new[] { "TicketId" });
            DropIndex("dbo.TicketNames", new[] { "NameId" });
            DropIndex("dbo.TicketPhoneNumbers", new[] { "TicketId" });
            DropIndex("dbo.TicketPhoneNumbers", new[] { "PhoneNumberId" });
            DropTable("dbo.TicketAddresses");
            DropTable("dbo.TicketNames");
            DropTable("dbo.TicketPhoneNumbers");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        NameId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TicketPhoneNumbers", "PhoneNumberId");
            CreateIndex("dbo.TicketPhoneNumbers", "TicketId");
            CreateIndex("dbo.TicketNames", "NameId");
            CreateIndex("dbo.TicketNames", "TicketId");
            CreateIndex("dbo.TicketAddresses", "AddressId");
            CreateIndex("dbo.TicketAddresses", "TicketId");
            AddForeignKey("dbo.TicketPhoneNumbers", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketPhoneNumbers", "PhoneNumberId", "dbo.PhoneNumbers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketNames", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketNames", "NameId", "dbo.Names", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketAddresses", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketAddresses", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
