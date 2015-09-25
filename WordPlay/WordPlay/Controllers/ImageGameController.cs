using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordPlay.Models;
using WordPlay.Repositories;

namespace WordPlay.Controllers
{
    public class ImageGameController : Controller
    {
        private ImageGameRepository rep = new ImageGameRepository();


        // GET: ImageGame
        public ActionResult Index()
        {
            return RedirectToAction("Play");
        }

        public ActionResult Play(int? categoryId, int? score, int? questionNr)
        {
            score = score == null ? 0 : score;
            ViewBag.Score = score;
            ViewBag.CategoryId = categoryId;
            ViewBag.QuestionNr = questionNr;
            return View(rep.GetRandomImage());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Play(int Id, int? score, string answer, int? categoryId, int? questionNr)
        {
            if (questionNr != null)
            {
                var model = rep.GetImage(Id);
                score = score == null ? 0 : score;
                questionNr = questionNr == null ? 0 : questionNr + 1;
                if (answer.ToLower() == model.Word.ToLower())
                {
                    score += 1;
                }
                
                if (categoryId == null)
                {
                    return RedirectToAction("Play", "Challenge", new { });
                }
                else 
                {
                    if (questionNr > 5)
                    {
                        return RedirectToAction("Play", "Result", new { });
                    }

                    ViewBag.Score = score;
                    ViewBag.CategoryId = categoryId;
                    ViewBag.QuestionNr = questionNr;
                    return View(rep.GetRandomImage());
                }
            }
            else 
            {
                var model = rep.GetImage(Id);
                score = score == null ? 0 : score;
                if (answer.ToLower() == model.Word.ToLower())
                {
                    ViewBag.Message = "You were correct!";
                    ViewBag.Score = score + 1;

                    return View(rep.GetRandomImage());
                }
                else
                {
                    ViewBag.Message = "You were wrong, please try again.";
                    ViewBag.Score = score;
                    return View(model);
                }
            }

        }
    }
}