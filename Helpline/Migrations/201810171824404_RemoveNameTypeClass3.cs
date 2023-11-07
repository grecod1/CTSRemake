namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNameTypeClass3 : DbMigration
    {
        public override void Up()
        {            
            //DropColumn("dbo.Names", "NameTypeId");
            //DropTable("dbo.NameTypes");
        }

        public override void Down()
        {
        }
    }
}
