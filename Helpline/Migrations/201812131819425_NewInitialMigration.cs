namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewInitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetNumber = c.String(),
                        StreetName = c.String(),
                        AptNumber = c.String(),
                        Subdivision = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        CountyId = c.Int(nullable: false),
                        AddressTypeId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressTypes", t => t.AddressTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Callers", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Counties", t => t.CountyId, cascadeDelete: true)
                .Index(t => t.CountyId)
                .Index(t => t.AddressTypeId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Callers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactTypeId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.ContactTypeId)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignedUser = c.String(),
                        StatusId = c.Int(nullable: false),
                        RequestTypeId = c.Int(nullable: false),
                        CommunicationTypeId = c.Int(nullable: false),
                        MailedInfo = c.Boolean(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommunicationTypes", t => t.CommunicationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.RequestTypes", t => t.RequestTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId)
                .Index(t => t.RequestTypeId)
                .Index(t => t.CommunicationTypeId);
            
            CreateTable(
                "dbo.CommunicationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        ContactId = c.Int(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Callers", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CallerRemarks = c.String(),
                        Comments = c.String(),
                        Resolution = c.String(),
                        TicketId = c.Int(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.OfficeLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CloseDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        PhoneTypeId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Callers", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.PhoneTypes", t => t.PhoneTypeId, cascadeDelete: true)
                .Index(t => t.PhoneTypeId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.PhoneTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneTypeName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LongName = c.String(nullable: false),
                        ShortName = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoutingCategoryId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .ForeignKey("dbo.RoutingCategories", t => t.RoutingCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.RoutingCategoryId)
                .Index(t => t.TicketId)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.RoutingCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RoleId = c.Int(nullable: false),
                        OfficeLocationId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OfficeLocations", t => t.OfficeLocationId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.OfficeLocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "OfficeLocationId", "dbo.OfficeLocations");
            DropForeignKey("dbo.Routes", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Routes", "RoutingCategoryId", "dbo.RoutingCategories");
            DropForeignKey("dbo.Routes", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.PhoneNumbers", "PhoneTypeId", "dbo.PhoneTypes");
            DropForeignKey("dbo.PhoneNumbers", "ContactId", "dbo.Callers");
            DropForeignKey("dbo.Notes", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Emails", "ContactId", "dbo.Callers");
            DropForeignKey("dbo.Addresses", "CountyId", "dbo.Counties");
            DropForeignKey("dbo.Addresses", "ContactId", "dbo.Callers");
            DropForeignKey("dbo.Callers", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Tickets", "RequestTypeId", "dbo.RequestTypes");
            DropForeignKey("dbo.Tickets", "CommunicationTypeId", "dbo.CommunicationTypes");
            DropForeignKey("dbo.Callers", "ContactTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.Addresses", "AddressTypeId", "dbo.AddressTypes");
            DropIndex("dbo.Users", new[] { "OfficeLocationId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Routes", new[] { "ProgramId" });
            DropIndex("dbo.Routes", new[] { "TicketId" });
            DropIndex("dbo.Routes", new[] { "RoutingCategoryId" });
            DropIndex("dbo.PhoneNumbers", new[] { "ContactId" });
            DropIndex("dbo.PhoneNumbers", new[] { "PhoneTypeId" });
            DropIndex("dbo.Notes", new[] { "TicketId" });
            DropIndex("dbo.Emails", new[] { "ContactId" });
            DropIndex("dbo.Tickets", new[] { "CommunicationTypeId" });
            DropIndex("dbo.Tickets", new[] { "RequestTypeId" });
            DropIndex("dbo.Tickets", new[] { "StatusId" });
            DropIndex("dbo.Callers", new[] { "TicketId" });
            DropIndex("dbo.Callers", new[] { "ContactTypeId" });
            DropIndex("dbo.Addresses", new[] { "ContactId" });
            DropIndex("dbo.Addresses", new[] { "AddressTypeId" });
            DropIndex("dbo.Addresses", new[] { "CountyId" });
            DropTable("dbo.Users");
            DropTable("dbo.RoutingCategories");
            DropTable("dbo.Routes");
            DropTable("dbo.Roles");
            DropTable("dbo.Programs");
            DropTable("dbo.PhoneTypes");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.OfficeLocations");
            DropTable("dbo.Notes");
            DropTable("dbo.Emails");
            DropTable("dbo.Counties");
            DropTable("dbo.Status");
            DropTable("dbo.RequestTypes");
            DropTable("dbo.CommunicationTypes");
            DropTable("dbo.Tickets");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Callers");
            DropTable("dbo.AddressTypes");
            DropTable("dbo.Addresses");
        }
    }
}
