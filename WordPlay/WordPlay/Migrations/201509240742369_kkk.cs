namespace WordPlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ColorModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Counter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ImageGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Word = c.String(),
                        Point = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizQuestions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.QuizQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        CorrectAnswer = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.QuizCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizHighscores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Name = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizCategories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuizHighscores", "CategoryId", "dbo.QuizCategories");
            DropForeignKey("dbo.QuizQuestions", "CategoryId", "dbo.QuizCategories");
            DropForeignKey("dbo.QuizAnswers", "QuestionId", "dbo.QuizQuestions");
            DropIndex("dbo.QuizHighscores", new[] { "CategoryId" });
            DropIndex("dbo.QuizQuestions", new[] { "CategoryId" });
            DropIndex("dbo.QuizAnswers", new[] { "QuestionId" });
            DropTable("dbo.QuizHighscores");
            DropTable("dbo.QuizCategories");
            DropTable("dbo.QuizQuestions");
            DropTable("dbo.QuizAnswers");
            DropTable("dbo.ImageGames");
            DropTable("dbo.ColorModels");
        }
    }
}
