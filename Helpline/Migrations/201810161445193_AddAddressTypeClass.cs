namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressTypeClass : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketAddresses", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketAddresses", "AddressId", "dbo.Addresses");
            DropIndex("dbo.TicketAddresses", new[] { "AddressId" });
            DropIndex("dbo.TicketAddresses", new[] { "TicketId" });
            DropTable("dbo.TicketAddresses");
        }
    }
}
