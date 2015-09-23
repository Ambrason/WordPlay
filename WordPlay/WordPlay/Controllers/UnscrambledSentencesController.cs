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
    [Authorize]
    public class UnscrambledSentencesController : Controller
    {

        private UnscrambleGameRepository rep = new UnscrambleGameRepository();

        [AllowAnonymous]
        public ActionResult Play()
        {
            var entity = rep.GetRandomSentence();

            var model = new UnscrambleGameViewmodel(entity);

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Play(UnscrambleGameViewmodel model)
        {
            return RedirectToAction("Result", model);
        }

        [AllowAnonymous]
        public ActionResult Result(UnscrambleGameViewmodel model)
        {
            return View(model);
        }


        //// GET: UnscrambledSentences
        //public ActionResult Index()
        //{
        //    return View(db.UnscrambledSentences.ToList());
        //}

        //// GET: UnscrambledSentences/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UnscrambledSentence unscrambledSentence = db.UnscrambledSentences.Find(id);
        //    if (unscrambledSentence == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(unscrambledSentence);
        //}

        //// GET: UnscrambledSentences/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: UnscrambledSentences/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Sentence")] UnscrambledSentence unscrambledSentence)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.UnscrambledSentences.Add(unscrambledSentence);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(unscrambledSentence);
        //}

        //// GET: UnscrambledSentences/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UnscrambledSentence unscrambledSentence = db.UnscrambledSentences.Find(id);
        //    if (unscrambledSentence == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(unscrambledSentence);
        //}

        //// POST: UnscrambledSentences/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Sentence")] UnscrambledSentence unscrambledSentence)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(unscrambledSentence).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(unscrambledSentence);
        //}

        //// GET: UnscrambledSentences/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UnscrambledSentence unscrambledSentence = db.UnscrambledSentences.Find(id);
        //    if (unscrambledSentence == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(unscrambledSentence);
        //}

        //// POST: UnscrambledSentences/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    UnscrambledSentence unscrambledSentence = db.UnscrambledSentences.Find(id);
        //    db.UnscrambledSentences.Remove(unscrambledSentence);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
