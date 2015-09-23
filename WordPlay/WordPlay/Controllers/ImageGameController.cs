using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordPlay.Repositories;

namespace WordPlay.Controllers
{
    public class ImageGameController : Controller
    {

        //call on ImageGameRepository
        private ImageGameRepository repo = new ImageGameRepository();


        // GET: ImageGame
        public ActionResult Index()
        {
            return View();
        }
    }
}