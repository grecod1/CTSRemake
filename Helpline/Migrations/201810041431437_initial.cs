namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoutingCategoryId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .ForeignKey("dbo.RoutingCategories", t => t.RoutingCategoryId, cascadeDelete: true)
                .Index(t => t.RoutingCategoryId)
                .Index(t => t.ProgramId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PhoneNumberId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.PhoneNumbers", t => t.PhoneNumberId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PhoneNumberId)
                .Index(t => t.AddressId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetNumber = c.String(),
                        StreetDirection = c.String(),
                        StreetName = c.String(),
                        LotNumber = c.String(),
                        Subdivision = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        CountyId = c.Int(nullable: false),
                        RegionId = c.Int(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Counties", t => t.CountyId, cascadeDelete: true)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .Index(t => t.CountyId)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
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
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhoneTypes", t => t.PhoneTypeId, cascadeDelete: true)
                .Index(t => t.PhoneTypeId);
            
            CreateTable(
                "dbo.PhoneTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneTypeName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RoleId = c.Int(nullable: false),
                        OfficeLocationId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OfficeLocations", t => t.OfficeLocationId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.OfficeLocationId);
            
            CreateTable(
                "dbo.OfficeLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LongName = c.String(),
                        ShortName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoutingCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCategoryId = c.Int(nullable: false),
                        Email = c.String(),
                        Shift = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoutingCategories", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        RouteId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        RequestTypeId = c.Int(nullable: false),
                        CommunicationTypeId = c.Int(nullable: false),
                        RegionId = c.Int(nullable: false),
                        FirstTimeCaller = c.Boolean(nullable: false),
                        Comments = c.String(),
                        ParentTicketId = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommunicationTypes", t => t.CommunicationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.ParentTicketId)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .ForeignKey("dbo.RequestTypes", t => t.RequestTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId)
                .Index(t => t.ProgramId)
                .Index(t => t.RequestTypeId)
                .Index(t => t.CommunicationTypeId)
                .Index(t => t.RegionId)
                .Index(t => t.ParentTicketId);
            
            CreateTable(
                "dbo.CommunicationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
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
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Tickets", "RequestTypeId", "dbo.RequestTypes");
            DropForeignKey("dbo.Tickets", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Tickets", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Tickets", "ParentTicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "CommunicationTypeId", "dbo.CommunicationTypes");
            DropForeignKey("dbo.Routes", "RoutingCategoryId", "dbo.RoutingCategories");
            DropForeignKey("dbo.RoutingCategories", "ParentCategoryId", "dbo.RoutingCategories");
            DropForeignKey("dbo.Routes", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Routes", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "OfficeLocationId", "dbo.OfficeLocations");
            DropForeignKey("dbo.Contacts", "PhoneNumberId", "dbo.PhoneNumbers");
            DropForeignKey("dbo.PhoneNumbers", "PhoneTypeId", "dbo.PhoneTypes");
            DropForeignKey("dbo.Contacts", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Addresses", "CountyId", "dbo.Counties");
            DropIndex("dbo.Tickets", new[] { "ParentTicketId" });
            DropIndex("dbo.Tickets", new[] { "RegionId" });
            DropIndex("dbo.Tickets", new[] { "CommunicationTypeId" });
            DropIndex("dbo.Tickets", new[] { "RequestTypeId" });
            DropIndex("dbo.Tickets", new[] { "ProgramId" });
            DropIndex("dbo.Tickets", new[] { "StatusId" });
            DropIndex("dbo.RoutingCategories", new[] { "ParentCategoryId" });
            DropIndex("dbo.Users", new[] { "OfficeLocationId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.PhoneNumbers", new[] { "PhoneTypeId" });
            DropIndex("dbo.Addresses", new[] { "RegionId" });
            DropIndex("dbo.Addresses", new[] { "CountyId" });
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.Contacts", new[] { "AddressId" });
            DropIndex("dbo.Contacts", new[] { "PhoneNumberId" });
            DropIndex("dbo.Routes", new[] { "ContactId" });
            DropIndex("dbo.Routes", new[] { "ProgramId" });
            DropIndex("dbo.Routes", new[] { "RoutingCategoryId" });
            DropTable("dbo.Status");
            DropTable("dbo.RequestTypes");
            DropTable("dbo.CommunicationTypes");
            DropTable("dbo.Tickets");
            DropTable("dbo.RoutingCategories");
            DropTable("dbo.Programs");
            DropTable("dbo.Roles");
            DropTable("dbo.OfficeLocations");
            DropTable("dbo.Users");
            DropTable("dbo.PhoneTypes");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Regions");
            DropTable("dbo.Counties");
            DropTable("dbo.Addresses");
            DropTable("dbo.Contacts");
            DropTable("dbo.Routes");
        }
    }
}
