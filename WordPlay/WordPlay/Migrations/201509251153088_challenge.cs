namespace WordPlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class challenge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChallengeCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChallengeHighscores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Name = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChallengeCategories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChallengeHighscores", "CategoryId", "dbo.ChallengeCategories");
            DropIndex("dbo.ChallengeHighscores", new[] { "CategoryId" });
            DropTable("dbo.ChallengeHighscores");
            DropTable("dbo.ChallengeCategories");
        }
    }
}
