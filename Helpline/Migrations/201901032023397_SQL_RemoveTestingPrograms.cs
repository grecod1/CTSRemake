namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_RemoveTestingPrograms : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Programs WHERE Id = 237");
            Sql("DELETE FROM Programs WHERE Id = 238");
        }
        
        public override void Down()
        {
        }
    }
}
