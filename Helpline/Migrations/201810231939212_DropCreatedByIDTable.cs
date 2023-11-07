namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropCreatedByIDTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CreatedByID");
        }
        
        public override void Down()
        {
        }
    }
}
