using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordPlay.Models;

namespace WordPlay.Controllers
{
    public class ChallengeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Challenge
        public ActionResult Index()
        {
            return View(db.ChallengeCategories.ToList());
        }

        public ActionResult Play(int? categoryId)
        {
            if (categoryId == null)
            {

            }
            else
            { 
                
            }
            RedirectToAction("Play", db.ChallengeCategories.Find(categoryId).Category, new {  });
            return View();
        }
    }
}