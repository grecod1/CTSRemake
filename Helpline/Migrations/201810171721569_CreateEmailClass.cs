namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmailClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "CreationTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "CreationTime", c => c.DateTime(nullable: false));
        }
    }
}
