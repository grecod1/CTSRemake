namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserIdToUserNameInRadioFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "CreatedBy_UserName", c => c.String());
            AddColumn("dbo.Addresses", "LastModifiedBy_UserName", c => c.String());
            AddColumn("dbo.Contacts", "CreatedBy_UserName", c => c.String());
            AddColumn("dbo.Contacts", "LastModifiedBy_UserName", c => c.String());
            AddColumn("dbo.Emails", "CreatedBy_UserName", c => c.String());
            AddColumn("dbo.Emails", "LastModifiedBy_UserName", c => c.String());
            AddColumn("dbo.Notes", "CreatedBy_UserName", c => c.String());
            AddColumn("dbo.Notes", "LastModifiedBy_UserName", c => c.String());
            AddColumn("dbo.Tickets", "CreatedBy_UserName", c => c.String());
            AddColumn("dbo.Tickets", "LastModifiedBy_UserName", c => c.String());
            AddColumn("dbo.PhoneNumbers", "CreatedBy_UserName", c => c.String());
            AddColumn("dbo.PhoneNumbers", "LastModifiedBy_UserName", c => c.String());
            AddColumn("dbo.Routes", "CreatedBy_UserName", c => c.String());
            AddColumn("dbo.Routes", "LastModifiedBy_UserName", c => c.String());
            AlterColumn("dbo.Tickets", "UserId", c => c.String());
            DropColumn("dbo.Addresses", "CreatedBy_UserId");
            DropColumn("dbo.Addresses", "LastModifiedBy_UserId");
            DropColumn("dbo.Contacts", "CreatedBy_UserId");
            DropColumn("dbo.Contacts", "LastModifiedBy_UserId");
            DropColumn("dbo.Emails", "CreatedBy_UserId");
            DropColumn("dbo.Emails", "LastModifiedBy_UserId");
            DropColumn("dbo.Notes", "CreatedBy_UserId");
            DropColumn("dbo.Notes", "LastModifiedBy_UserId");
            DropColumn("dbo.Tickets", "CreatedBy_UserId");
            DropColumn("dbo.Tickets", "LastModifiedBy_UserId");
            DropColumn("dbo.PhoneNumbers", "CreatedBy_UserId");
            DropColumn("dbo.PhoneNumbers", "LastModifiedBy_UserId");
            DropColumn("dbo.Routes", "CreatedBy_UserId");
            DropColumn("dbo.Routes", "LastModifiedBy_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routes", "LastModifiedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Routes", "CreatedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.PhoneNumbers", "LastModifiedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.PhoneNumbers", "CreatedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "LastModifiedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "CreatedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Notes", "LastModifiedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Notes", "CreatedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Emails", "LastModifiedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Emails", "CreatedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "LastModifiedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "CreatedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "LastModifiedBy_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "CreatedBy_UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Routes", "LastModifiedBy_UserName");
            DropColumn("dbo.Routes", "CreatedBy_UserName");
            DropColumn("dbo.PhoneNumbers", "LastModifiedBy_UserName");
            DropColumn("dbo.PhoneNumbers", "CreatedBy_UserName");
            DropColumn("dbo.Tickets", "LastModifiedBy_UserName");
            DropColumn("dbo.Tickets", "CreatedBy_UserName");
            DropColumn("dbo.Notes", "LastModifiedBy_UserName");
            DropColumn("dbo.Notes", "CreatedBy_UserName");
            DropColumn("dbo.Emails", "LastModifiedBy_UserName");
            DropColumn("dbo.Emails", "CreatedBy_UserName");
            DropColumn("dbo.Contacts", "LastModifiedBy_UserName");
            DropColumn("dbo.Contacts", "CreatedBy_UserName");
            DropColumn("dbo.Addresses", "LastModifiedBy_UserName");
            DropColumn("dbo.Addresses", "CreatedBy_UserName");
        }
    }
}
