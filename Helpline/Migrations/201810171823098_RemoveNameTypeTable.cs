namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNameTypeTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Names", new[] { "NameTypeId" });
            //DropColumn("dbo.Names", "NameTypeId");
            //DropTable("dbo.NameTypes");
        }

        public override void Down()
        {
        }
    }
}
