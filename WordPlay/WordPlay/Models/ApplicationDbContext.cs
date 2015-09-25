using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WordPlay.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<UnscrambledSentence> UnscrambledSentences { get; set; }

        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuizAnswer> QuizAnswers { get; set; }
        public DbSet<QuizCategory> QuizCategories { get; set; }
        public DbSet<QuizHighscore> QuizHighscores { get; set; }

        public DbSet<ColorModel> ColorModel { get; set; }
        public DbSet<ImageGame> ImageGameModels { get; set; }
        public DbSet<PgTask> PgTasks { get; set; }

        public DbSet<ImageQuery> ImageQueries { get; set; }

        public DbSet<ColorQuery> ColorQueries { get; set; }

        public DbSet<ChallengeHighscore> ChallengeHighscores { get; set; }
        public DbSet<ChallengeCategory> ChallengeCategories { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        

    }
}