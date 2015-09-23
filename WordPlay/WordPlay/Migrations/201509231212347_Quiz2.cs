namespace WordPlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quiz2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuizQuestions", "CorrectAnswerId", "dbo.QuizAnswers");
            DropIndex("dbo.QuizQuestions", new[] { "CorrectAnswerId" });
            AddColumn("dbo.QuizQuestions", "CorrectAnswer", c => c.String());
            DropColumn("dbo.QuizQuestions", "CorrectAnswerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuizQuestions", "CorrectAnswerId", c => c.Int(nullable: false));
            DropColumn("dbo.QuizQuestions", "CorrectAnswer");
            CreateIndex("dbo.QuizQuestions", "CorrectAnswerId");
            AddForeignKey("dbo.QuizQuestions", "CorrectAnswerId", "dbo.QuizAnswers", "Id", cascadeDelete: true);
        }
    }
}
