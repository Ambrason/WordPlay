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

        public ICollection<UnscrambledSentence> GetItems()
        {
            
        }
    }
}