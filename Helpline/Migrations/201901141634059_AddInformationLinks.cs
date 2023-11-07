namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInformationLinks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InformationLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        URL = c.String(),
                        CreateBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InformationLinks");
        }
    }
}
