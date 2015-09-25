using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordPlay.Models;

namespace WordPlay.Repositories
{
    public class ImageGameRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ImageQuery GetImage(int id)
        {
            return db.ImageQueries.Find(id);
        }

        public ImageQuery GetRandomImage()
        {
            var list = db.ImageQueries.ToList();

            Random random = new Random();
            int r = random.Next(list.Count);

            return list[r];
        }
    }
}