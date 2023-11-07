namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropNameTypeTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.NameTypes");
        }

        public override void Down()
        {
        }
    }
}
