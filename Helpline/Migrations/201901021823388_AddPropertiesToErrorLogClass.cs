namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToErrorLogClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ErrorLogs", "Task", c => c.String());
            AddColumn("dbo.ErrorLogs", "UserName", c => c.String());
            AddColumn("dbo.ErrorLogs", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ErrorLogs", "Time");
            DropColumn("dbo.ErrorLogs", "UserName");
            DropColumn("dbo.ErrorLogs", "Task");
        }
    }
}
