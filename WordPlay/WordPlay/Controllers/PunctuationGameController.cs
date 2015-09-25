using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WordPlay.Models;
using WordPlay.Repositories;

namespace WordPlay.Controllers
{
    public class PunctuationGameController : Controller
    {
        private PunctuationGameRepository rep = new PunctuationGameRepository();

        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PunctuationGame
        public ActionResult Index()
        {
            var l = rep.GetAllPgTasks();

            //List<string> list = new List<string>();

            return View(l);
        }

        // GET: PunctuationGame/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PgTask pgTask = rep.GetPgTask(id);
            if (pgTask == null)
            {
                return HttpNotFound();
            }
            return View(pgTask);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(PgTask pgTask)
        {
            //if (ModelState.IsValid)
            //{
                

            //    return RedirectToAction("Index");
            //}
            pgTask.EncodeText(pgTask.PgTaskAnswer);
            return View(pgTask);
        }
        // GET: PunctuationGame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PunctuationGame/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "k,PgTaskString,PgTaskOut,PgTaskScore,PbTaskAnswer")] PgTask pgTask)
        {
            if (ModelState.IsValid)
            {
                rep.AddPgTask(pgTask);
                
                return RedirectToAction("Index");
            }

            return View(pgTask);
        }

        

        // GET: PunctuationGame/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PgTask pgTask = rep.GetPgTask(id);
            if (pgTask == null)
            {
                return HttpNotFound();
            }
            return View(pgTask);
        }

        // POST: PunctuationGame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            rep.RemovePgTask(id);
            
            return RedirectToAction("Index");
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
         */
    }
}
