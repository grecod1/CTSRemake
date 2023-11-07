namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_RemoveIlegitimateRequestType : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM RequestTypes WHERE Id = 101");
        }
        
        public override void Down()
        {
        }
    }
}
