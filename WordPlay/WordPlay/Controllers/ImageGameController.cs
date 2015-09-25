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
            return View();
        }

        public ActionResult Play()
        {
            return View(rep.GetRandomImage());
        }

        [HttpPost]
        public ActionResult Play(ImageQuery model, string answer, int score)
        {
            if (answer == model.Word)
            {
                ViewBag.Message = "You were correct!";
                ViewBag.Score = score + 1;

                return View(rep.GetRandomImage());
            }
            else {
                ViewBag.Message = "You were wrong, please try again.";
                ViewBag.Score = score;
                return View(model);
            }
        }
    }
}