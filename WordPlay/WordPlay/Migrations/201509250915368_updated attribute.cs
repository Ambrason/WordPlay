namespace WordPlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedattribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PgTasks", "PgTaskAnswer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PgTasks", "PgTaskAnswer", c => c.String());
        }
    }
}
