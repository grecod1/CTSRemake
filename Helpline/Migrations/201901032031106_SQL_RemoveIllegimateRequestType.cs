namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_RemoveIllegimateRequestType : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM RequestTypes WHERE Id = 102");
        }
        
        public override void Down()
        {
        }
    }
}
