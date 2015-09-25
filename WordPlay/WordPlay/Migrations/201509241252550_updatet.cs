namespace WordPlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PgTasks", "PgTaskScore", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PgTasks", "PgTaskScore", c => c.Int(nullable: false));
        }
    }
}
