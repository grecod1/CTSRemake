namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_RemoveTestingUsers : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Users WHERE Id =639");
            Sql("DELETE FROM Users WHERE Id =640");
        }
        
        public override void Down()
        {
        }
    }
}
