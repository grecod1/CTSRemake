namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_RemoveExtraAuthorEntry : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Users WHERE Id = 306");
        }
        
        public override void Down()
        {
        }
    }
}
