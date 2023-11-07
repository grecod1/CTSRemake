namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_MakeAllUserEmailsConfirmed : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AspNetUsers SET EmailConfirmed = 'true' WHERE UserName = 'tester'");
        }
        
        public override void Down()
        {
        }
    }
}
