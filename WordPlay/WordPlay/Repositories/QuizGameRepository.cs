using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordPlay.Models;

namespace WordPlay.Repositories
{
    public class QuizGameRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public QuizQuestion GetQuizQuestion(int id)
        {
            return db.QuizQuestions.Find(id);
        }

        public QuizQuestion GetRandomQuestion()
        {
            var list = db.QuizQuestions.ToList();

            Random random = new Random();
            int r = random.Next(list.Count);

            return list[r];
        }
    }
}