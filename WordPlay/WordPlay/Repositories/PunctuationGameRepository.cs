using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordPlay.Models;

namespace WordPlay.Repositories
{
    public class PunctuationGameRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<PgTask>GetAllPgTasks()
        {
            return db.PgTasks.ToList<PgTask>();
        }

        public PgTask GetPgTask(int? id)
        {
            return db.PgTasks.Find(id);
        }

        public void AddPgTask(PgTask t)
        {
            db.PgTasks.Add(t);
            db.SaveChanges();
        }

        public void RemovePgTask(int? id)
        {
            PgTask t = new PgTask();
            t = db.PgTasks.Find(id);
            db.PgTasks.Remove(t);
            db.SaveChanges();
        }

        internal object Entry(PgTask pgTask)
        {
            throw new NotImplementedException();
        }
    }
}