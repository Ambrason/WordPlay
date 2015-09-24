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

        //public QuizQuestion GetRandomQuestion()
        //{
        //    var list = db.QuizQuestions.ToList();

        //    Random random = new Random();
        //    int r = random.Next(list.Count);

        //    return list[r];
        //}

        public QuizQuestion GetRandomQuestion(ICollection<int> alreadyAnswered, int? categoryId)
        {
            List<QuizQuestion> list;
            if (alreadyAnswered == null)
            {
                list = db.QuizQuestions.ToList();
            }
            else{
                list = db.QuizQuestions.Where(q => !alreadyAnswered.Contains(q.Id)).Where(q => categoryId == null || categoryId == 0 || q.CategoryId == categoryId).ToList();
            }

            Random random = new Random();
            int r = random.Next(list.Count);

            return list[r];
        }

        public QuizCategory GetQuizCategory(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return db.QuizCategories.Find(id);
        }

        public void CreateHighscore(QuizHighscore item)
        {
            db.QuizHighscores.Add(item);
            db.SaveChanges();
        }

        public IEnumerable<QuizHighscore> GetHighscores()
        {
            return db.QuizHighscores;
        }
    }
}