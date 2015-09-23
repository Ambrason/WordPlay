using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordPlay.Models;

namespace WordPlay.Repositories
{
    public class UnscrambleGameRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //public ICollection<UnscrambledSentence> GetItems()
        //{
        //    return db.UnscrambledSentences.ToList();
        //}

        public UnscrambledSentence GetRandomSentence()
        {
            var list = db.UnscrambledSentences.ToList();

            Random random = new Random();
            int r = random.Next(list.Count);

            return list[r];
        }

        public UnscrambledSentence GetSentence(int id)
        {
            return db.UnscrambledSentences.Find(id);
        }
    }
}