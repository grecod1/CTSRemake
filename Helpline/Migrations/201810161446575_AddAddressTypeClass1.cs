namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressTypeClass1 : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Addresses");

            CreateTable(
                "dbo.AddressTypes",
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
            
            AddColumn("dbo.Addresses", "AddressTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "AddressTypeId");
            AddForeignKey("dbo.Addresses", "AddressTypeId", "dbo.AddressTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "AddressTypeId", "dbo.AddressTypes");
            DropIndex("dbo.Addresses", new[] { "AddressTypeId" });
            DropColumn("dbo.Addresses", "AddressTypeId");
            DropTable("dbo.AddressTypes");
        }
    }
}
