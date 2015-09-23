using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WordPlay.Models;
using WordPlay.Repositories;

namespace WordPlay.Controllers
{
    public class ImageGameModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ImageGameRepository repo = new ImageGameRepository();


        // GET: ImageGameModels
        public ActionResult Index()
        {
            return View(db.ImageGameModels.ToList());
        }


        public ActionResult Play() {
            return View();

        }

        [HttpPost]
        public ActionResult Play(string[] strAnswers)
        {
            return View();
        }
//        // GET: ImageGameModels/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ImageGameModel imageGameModel = db.ImageGameModels.Find(id);
//            if (imageGameModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(imageGameModel);
//        }

//        // GET: ImageGameModels/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: ImageGameModels/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "ID,Word,Point")] ImageGameModel imageGameModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.ImageGameModels.Add(imageGameModel);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(imageGameModel);
//        }

//        // GET: ImageGameModels/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ImageGameModel imageGameModel = db.ImageGameModels.Find(id);
//            if (imageGameModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(imageGameModel);
//        }

//        // POST: ImageGameModels/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "ID,Word,Point")] ImageGameModel imageGameModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(imageGameModel).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(imageGameModel);
//        }

//        // GET: ImageGameModels/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ImageGameModel imageGameModel = db.ImageGameModels.Find(id);
//            if (imageGameModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(imageGameModel);
//        }

//        // POST: ImageGameModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            ImageGameModel imageGameModel = db.ImageGameModels.Find(id);
//            db.ImageGameModels.Remove(imageGameModel);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
    }
}
