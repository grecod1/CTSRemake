namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_ChangeUserNameForAuthor : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AspNetUsers SET UserName = 'Author'");
        }
        
        public override void Down()
        {
        }
    }
}
