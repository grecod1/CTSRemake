namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveInnerMessagePropertyOnErrorLog : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ErrorLogs", "InnerMessage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ErrorLogs", "InnerMessage", c => c.String());
        }
    }
}
