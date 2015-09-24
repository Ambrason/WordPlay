namespace WordPlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnscrambleInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnscrambledSentences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sentence = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UnscrambledSentences");
        }
    }
}
