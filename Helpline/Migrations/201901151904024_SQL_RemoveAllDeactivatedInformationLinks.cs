namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_RemoveAllDeactivatedInformationLinks : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM InformationLinks WHERE IsActive = 'false'");
        }
        
        public override void Down()
        {
        }
    }
}
