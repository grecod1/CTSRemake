namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "CallersRemark", c => c.String());            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "CallersRemark");
        }
    }
}
