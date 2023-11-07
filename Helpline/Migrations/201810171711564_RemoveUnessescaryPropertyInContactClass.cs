namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnessescaryPropertyInContactClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Email", c => c.String());
        }
    }
}
