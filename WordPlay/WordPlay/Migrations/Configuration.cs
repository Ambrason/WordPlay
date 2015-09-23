namespace WordPlay.Migrations
{
    using System;
    using System.Collections.Generic;
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

            //QuizGame
            QuizCategory cat1 = new QuizCategory() { Id = 1, Category = "History" };


            QuizQuestion q1 = new QuizQuestion() { Id = 1, Question = "AAAAA", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q2 = new QuizQuestion() { Id = 2, Question = "BBBBB", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q3 = new QuizQuestion() { Id = 3, Question = "CCCCC", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q4 = new QuizQuestion() { Id = 4, Question = "DDDDD", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q5 = new QuizQuestion() { Id = 5, Question = "EEEEE", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q6 = new QuizQuestion() { Id = 6, Question = "FFFFF", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q7 = new QuizQuestion() { Id = 7, Question = "GGGGG", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q8 = new QuizQuestion() { Id = 8, Question = "HHHHH", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q9 = new QuizQuestion() { Id = 9, Question = "IIIII", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q10 = new QuizQuestion() { Id = 10, Question = "JJJJJ", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q11 = new QuizQuestion() { Id = 11, Question = "KKKKK", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q12 = new QuizQuestion() { Id = 12, Question = "LLLLL", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q13 = new QuizQuestion() { Id = 13, Question = "MMMMM", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q14 = new QuizQuestion() { Id = 14, Question = "NNNNN", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q15 = new QuizQuestion() { Id = 15, Question = "OOOOO", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q16 = new QuizQuestion() { Id = 16, Question = "PPPPP", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q17 = new QuizQuestion() { Id = 17, Question = "QQQQQ", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q18 = new QuizQuestion() { Id = 18, Question = "RRRRR", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q19 = new QuizQuestion() { Id = 19, Question = "SSSSS", Category = cat1, CategoryId = cat1.Id };
            QuizQuestion q20 = new QuizQuestion() { Id = 20, Question = "TTTTT", Category = cat1, CategoryId = cat1.Id };
            var questions = new List<QuizQuestion>() { q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13, q14, q15, q16, q17, q18, q19, q20 };
            var answers = new List<QuizAnswer>();
            var answerId = 0;
            foreach (var q in questions)
            {
                q.Answers = new List<QuizAnswer>();
                answerId += 1;
                var correctAnswer = new QuizAnswer() { Id = answerId, Answer = q.Question.ToLower(), Question = q, QuestionId = q.Id };
                answers.Add(correctAnswer);
                q.Answers.Add(correctAnswer);
                q.CorrectAnswer = correctAnswer.Answer;

                for (int i = 0; i < 4; i++)
                {
                    answerId += 1;
                    var a = new QuizAnswer() { Id = answerId, Answer = "Fel." + String.Concat(Enumerable.Repeat((" " + i), 5)), Question = q, QuestionId = q.Id };
                    answers.Add(a);
                    q.Answers.Add(a);
                }
            }

            context.QuizCategories.AddOrUpdate(
                q => q.Id,
                cat1
                );

            context.QuizQuestions.AddOrUpdate(
                q => q.Id,
                questions.ToArray()
                );

            context.QuizAnswers.AddOrUpdate(
                q => q.Id,
                answers.ToArray()
                );

        }
    }
}
