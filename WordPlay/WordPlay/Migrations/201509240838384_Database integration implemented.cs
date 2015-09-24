namespace WordPlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Databaseintegrationimplemented : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PgTasks",
                c => new
                    {
                        k = c.Int(nullable: false, identity: true),
                        PgTaskString = c.String(),
                        PgTaskOut = c.String(),
                        PgTaskScore = c.Int(nullable: false),
                        PbTaskAnswer = c.String(),
                    })
                .PrimaryKey(t => t.k);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PgTasks");
        }
    }
}