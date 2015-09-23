using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WordPlay.Models;

namespace WordPlay.Controllers
{
    public class ColorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Color
        public ActionResult Index()
        {
            return View(db.ColorModel.ToList());
        }

        // GET: Color/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorModel colorModel = db.ColorModel.Find(id);
            if (colorModel == null)
            {
                return HttpNotFound();
            }
            return View(colorModel);
        }

        // GET: Color/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Color/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Color,Counter")] ColorModel colorModel)
        {
            if (ModelState.IsValid)
            {
                db.ColorModel.Add(colorModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colorModel);
        }

        // GET: Color/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorModel colorModel = db.ColorModel.Find(id);
            if (colorModel == null)
            {
                return HttpNotFound();
            }
            return View(colorModel);
        }

        // POST: Color/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Color,Counter")] ColorModel colorModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colorModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colorModel);
        }

        // GET: Color/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorModel colorModel = db.ColorModel.Find(id);
            if (colorModel == null)
            {
                return HttpNotFound();
            }
            return View(colorModel);
        }

        // POST: Color/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ColorModel colorModel = db.ColorModel.Find(id);
            db.ColorModel.Remove(colorModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
