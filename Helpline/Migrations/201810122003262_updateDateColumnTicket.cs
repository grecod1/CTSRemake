namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDateColumnTicket : DbMigration
    {
        public override void Up()
        {
            //Sql("ALTER TABLE Tickets ALTER COLUMN CreationDate DateTime2 ");
            //Sql("ALTER TABLE Tickets ALTER COLUMN ModifiedDate DateTime2 ");
        }
        
        public override void Down()
        {
        }
    }
}
