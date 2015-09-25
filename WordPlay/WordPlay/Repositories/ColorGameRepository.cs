using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordPlay.Models;

namespace WordPlay.Repositories
{
    public class ColorGameRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ColorQuery GetColor(int id)
        {
            return db.ColorQueries.Find(id);
        }

        public ColorQuery GetRandomColor()
        {
            var list = db.ColorQueries.ToList();

            Random random = new Random();
            int r = random.Next(list.Count);

            return list[r];
        }
    }
}