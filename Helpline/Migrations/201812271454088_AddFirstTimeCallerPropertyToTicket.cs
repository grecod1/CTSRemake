namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstTimeCallerPropertyToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "FirstTimeCaller", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "FirstTimeCaller");
        }
    }
}
