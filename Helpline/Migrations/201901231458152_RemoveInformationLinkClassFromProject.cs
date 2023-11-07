namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveInformationLinkClassFromProject : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.InformationLinks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InformationLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        URL = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreateBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
