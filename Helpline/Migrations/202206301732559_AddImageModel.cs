namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterSet = c.Binary(),
                        TicketId = c.Int(nullable: false),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Images");
        }
    }
}
