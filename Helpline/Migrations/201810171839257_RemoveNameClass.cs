namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNameClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Names", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Names", new[] { "ContactId" });
            AddColumn("dbo.Contacts", "FirstName", c => c.String());
            AddColumn("dbo.Contacts", "LastName", c => c.String());
            DropTable("dbo.Names");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Names",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Prefix = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Suffix = c.String(),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Contacts", "LastName");
            DropColumn("dbo.Contacts", "FirstName");
            CreateIndex("dbo.Names", "ContactId");
            AddForeignKey("dbo.Names", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
    }
}
