namespace WordPlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colorgame : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ColorQueries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorCode = c.String(),
                        ColorName = c.String(),
                        ColorText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ColorQueries");
        }
    }
}
