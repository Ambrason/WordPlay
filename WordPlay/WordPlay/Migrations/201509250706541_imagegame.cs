namespace WordPlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagegame : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageQueries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageQueries");
        }
    }
}
