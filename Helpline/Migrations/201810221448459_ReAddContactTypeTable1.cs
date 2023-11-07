namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddContactTypeTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Contacts");
            CreateTable(
                "dbo.ContactTypes",
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

            AddColumn("dbo.Contacts", "ContactTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "ContactTypeId");
            AddForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
        }
    }
}
