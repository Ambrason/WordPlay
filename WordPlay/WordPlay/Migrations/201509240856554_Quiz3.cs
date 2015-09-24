namespace WordPlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quiz3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuizHighscores", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuizHighscores", "Name", c => c.Int(nullable: false));
        }
    }
}
