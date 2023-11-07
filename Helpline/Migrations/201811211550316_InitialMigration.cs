namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Addresses",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            StreetNumber = c.String(),
            //            StreetName = c.String(),
            //            AptNumber = c.String(),
            //            Subdivision = c.String(),
            //            City = c.String(),
            //            State = c.String(),
            //            Zip = c.String(),
            //            CountyId = c.Int(nullable: false),
            //            AddressTypeId = c.Int(nullable: false),
            //            ContactId = c.Int(nullable: false),
            //            Latitude = c.Double(nullable: false),
            //            Longitude = c.Double(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AddressTypes", t => t.AddressTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
            //    .ForeignKey("dbo.Counties", t => t.CountyId, cascadeDelete: true)
            //    .Index(t => t.CountyId)
            //    .Index(t => t.AddressTypeId)
            //    .Index(t => t.ContactId);
            
            //CreateTable(
            //    "dbo.AddressTypes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Contacts",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            FirstName = c.String(),
            //            LastName = c.String(),
            //            ContactTypeId = c.Int(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId, cascadeDelete: true)
            //    .Index(t => t.ContactTypeId);
            
            //CreateTable(
            //    "dbo.ContactTypes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Counties",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.CommunicationTypes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Emails",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            EmailAddress = c.String(),
            //            ContactId = c.Int(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
            //    .Index(t => t.ContactId);
            
            //CreateTable(
            //    "dbo.Users",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Number = c.Int(nullable: false),
            //            UserName = c.String(),
            //            Password = c.String(),
            //            FirstName = c.String(),
            //            LastName = c.String(),
            //            RoleId = c.Int(nullable: false),
            //            OfficeLocationId = c.Int(nullable: false),
            //            IsActive = c.Boolean(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //            Email = c.String(),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            Role_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.OfficeLocations", t => t.OfficeLocationId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetRoles", t => t.Role_Id)
            //    .Index(t => t.OfficeLocationId)
            //    .Index(t => t.Role_Id);
            
            //CreateTable(
            //    "dbo.AspNetUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetUserLogins",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
            //    .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.OfficeLocations",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            CloseDate = c.DateTime(),
            //            IsActive = c.Boolean(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 256),
            //            CreatedBy_UserId = c.Int(),
            //            CreationDate = c.DateTime(),
            //            LastModifiedBy_UserId = c.Int(),
            //            ModifiedDate = c.DateTime(),
            //            Discriminator = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.RoleId })
            //    .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId)
            //    .Index(t => t.RoleId);
            
            //CreateTable(
            //    "dbo.Notes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            CallerRemarks = c.String(),
            //            Comments = c.String(),
            //            Resolution = c.String(),
            //            TicketId = c.Int(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
            //    .Index(t => t.TicketId);
            
            //CreateTable(
            //    "dbo.Tickets",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.Int(nullable: false),
            //            StatusId = c.Int(nullable: false),
            //            RequestTypeId = c.Int(nullable: false),
            //            CommunicationTypeId = c.Int(nullable: false),
            //            MailedInfo = c.Boolean(nullable: false),
            //            ParentTicketId = c.Int(),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.CommunicationTypes", t => t.CommunicationTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.Tickets", t => t.ParentTicketId)
            //    .ForeignKey("dbo.RequestTypes", t => t.RequestTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
            //    .Index(t => t.StatusId)
            //    .Index(t => t.RequestTypeId)
            //    .Index(t => t.CommunicationTypeId)
            //    .Index(t => t.ParentTicketId);
            
            //CreateTable(
            //    "dbo.RequestTypes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            IsActive = c.Boolean(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Status",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            IsActive = c.Boolean(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.PhoneNumbers",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Number = c.String(),
            //            PhoneTypeId = c.Int(nullable: false),
            //            ContactId = c.Int(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
            //    .ForeignKey("dbo.PhoneTypes", t => t.PhoneTypeId, cascadeDelete: true)
            //    .Index(t => t.PhoneTypeId)
            //    .Index(t => t.ContactId);
            
            //CreateTable(
            //    "dbo.PhoneTypes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PhoneTypeName = c.String(),
            //            IsActive = c.Boolean(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Programs",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            LongName = c.String(nullable: false),
            //            ShortName = c.String(nullable: false),
            //            IsActive = c.Boolean(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Routes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            RoutingCategoryId = c.Int(nullable: false),
            //            TicketId = c.Int(nullable: false),
            //            ProgramId = c.Int(nullable: false),
            //            ContactId = c.Int(nullable: false),
            //            IsActive = c.Boolean(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
            //    .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
            //    .ForeignKey("dbo.RoutingCategories", t => t.RoutingCategoryId, cascadeDelete: true)
            //    .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
            //    .Index(t => t.RoutingCategoryId)
            //    .Index(t => t.TicketId)
            //    .Index(t => t.ProgramId)
            //    .Index(t => t.ContactId);
            
            //CreateTable(
            //    "dbo.RoutingCategories",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            Email = c.String(),
            //            IsActive = c.Boolean(nullable: false),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Routes", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Routes", "RoutingCategoryId", "dbo.RoutingCategories");
            DropForeignKey("dbo.Routes", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Routes", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PhoneNumbers", "PhoneTypeId", "dbo.PhoneTypes");
            DropForeignKey("dbo.PhoneNumbers", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Notes", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Tickets", "RequestTypeId", "dbo.RequestTypes");
            DropForeignKey("dbo.Tickets", "ParentTicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "CommunicationTypeId", "dbo.CommunicationTypes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.Users", "OfficeLocationId", "dbo.OfficeLocations");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Emails", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Addresses", "CountyId", "dbo.Counties");
            DropForeignKey("dbo.Addresses", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.Addresses", "AddressTypeId", "dbo.AddressTypes");
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Routes", new[] { "ContactId" });
            DropIndex("dbo.Routes", new[] { "ProgramId" });
            DropIndex("dbo.Routes", new[] { "TicketId" });
            DropIndex("dbo.Routes", new[] { "RoutingCategoryId" });
            DropIndex("dbo.PhoneNumbers", new[] { "ContactId" });
            DropIndex("dbo.PhoneNumbers", new[] { "PhoneTypeId" });
            DropIndex("dbo.Tickets", new[] { "ParentTicketId" });
            DropIndex("dbo.Tickets", new[] { "CommunicationTypeId" });
            DropIndex("dbo.Tickets", new[] { "RequestTypeId" });
            DropIndex("dbo.Tickets", new[] { "StatusId" });
            DropIndex("dbo.Notes", new[] { "TicketId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.Users", new[] { "OfficeLocationId" });
            DropIndex("dbo.Emails", new[] { "ContactId" });
            DropIndex("dbo.Contacts", new[] { "ContactTypeId" });
            DropIndex("dbo.Addresses", new[] { "ContactId" });
            DropIndex("dbo.Addresses", new[] { "AddressTypeId" });
            DropIndex("dbo.Addresses", new[] { "CountyId" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.RoutingCategories");
            DropTable("dbo.Routes");
            DropTable("dbo.Programs");
            DropTable("dbo.PhoneTypes");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Status");
            DropTable("dbo.RequestTypes");
            DropTable("dbo.Tickets");
            DropTable("dbo.Notes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OfficeLocations");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Emails");
            DropTable("dbo.CommunicationTypes");
            DropTable("dbo.Counties");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
            DropTable("dbo.AddressTypes");
            DropTable("dbo.Addresses");
        }
    }
}
