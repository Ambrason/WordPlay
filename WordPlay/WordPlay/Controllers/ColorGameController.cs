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
    public class ColorGameController : Controller
    {
        private ColorGameRepository rep = new ColorGameRepository();

        // GET: ColorGame
        public ActionResult Index()
        {
            //return View(db.ColorQueries.ToList());
            return RedirectToAction("Play");
        }

        public ActionResult Play()
        {
            ViewBag.Score = 0;
            return View(rep.GetRandomColor());
        }

        [HttpPost]
        public ActionResult Play(int Id, int? score, string answer)
        {
            var model = rep.GetColor(Id);
            score = score == null ? 0 : score;
            if (answer.ToLower() == model.ColorName.ToLower())
            {
                ViewBag.Message = "You were correct!";
                ViewBag.Score = score + 1;

                return View(rep.GetRandomColor());
            }
            else
            {
                ViewBag.Message = "You were wrong, please try again.";
                ViewBag.Score = score;
                return View(model);
            }
        }

        //// GET: ColorGame/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ColorQuery colorQuery = db.ColorQueries.Find(id);
        //    if (colorQuery == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(colorQuery);
        //}

        //// GET: ColorGame/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ColorGame/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ColorCode,ColorName,ColorText")] ColorQuery colorQuery)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ColorQueries.Add(colorQuery);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(colorQuery);
        //}

        //// GET: ColorGame/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ColorQuery colorQuery = db.ColorQueries.Find(id);
        //    if (colorQuery == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(colorQuery);
        //}

        //// POST: ColorGame/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,ColorCode,ColorName,ColorText")] ColorQuery colorQuery)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(colorQuery).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(colorQuery);
        //}

        //// GET: ColorGame/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ColorQuery colorQuery = db.ColorQueries.Find(id);
        //    if (colorQuery == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(colorQuery);
        //}

        //// POST: ColorGame/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ColorQuery colorQuery = db.ColorQueries.Find(id);
        //    db.ColorQueries.Remove(colorQuery);
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
