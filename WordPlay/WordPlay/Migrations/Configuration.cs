namespace WordPlay.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WordPlay.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WordPlay.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WordPlay.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //UnscrambleGame
            context.UnscrambledSentences.AddOrUpdate(
                q => q.Id,
                new UnscrambledSentence() { Id = 1, Sentence = "My pen is in a goat" },
                new UnscrambledSentence() { Id = 2, Sentence = "There are pink elephants in my garden" }

                );


        }
    }
}
