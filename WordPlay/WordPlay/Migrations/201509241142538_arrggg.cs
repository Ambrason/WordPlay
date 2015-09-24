namespace WordPlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arrggg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PgTasks", "PgTaskAnswer", c => c.String());
            AlterColumn("dbo.QuizHighscores", "Name", c => c.String());
            DropColumn("dbo.PgTasks", "PbTaskAnswer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PgTasks", "PbTaskAnswer", c => c.String());
            AlterColumn("dbo.QuizHighscores", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.PgTasks", "PgTaskAnswer");
        }
    }
}
