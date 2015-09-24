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
    public class QuizGameController : Controller
    {
        private QuizGameRepository rep = new QuizGameRepository();

        public ActionResult Play(int? categoryId)
        {
            var model = new QuizPlayViewmodel(rep.GetQuizCategory(categoryId));

            return View(PlayHelper(model,null));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Play(QuizPlayViewmodel model, string answer)
        {
            int nrOfQuestions;

            //15 random questions
            if (model.CategoryId == null)
            {
                nrOfQuestions = 15;
            }
            //5 question of specified category
            else
            {
                nrOfQuestions = 5;
            }

            if (model.CurrentQuestionNr >= nrOfQuestions)
            {
                return RedirectToAction("Result", new QuizResultViewmodel() { CategoryId = model.CategoryId, CategoryName = model.CategoryName, Score = model.Score });
            }
            else
            {
                return View(PlayHelper(model,answer));
            }
        }

        public QuizPlayViewmodel PlayHelper(QuizPlayViewmodel model, string answer)
        {
            //If not first question
            if (model.CurrentQuestionNr != 0 && model.CurrentQuestionId != 0)
            {
                var currentQuestion = rep.GetQuizQuestion(model.CurrentQuestionId);

                //If right answer
                if (answer == currentQuestion.CorrectAnswer)
                {
                    model.Score += 1;
                    model.PreviousQuestionCorrect = true;
                }
                else
                {
                    model.PreviousQuestionCorrect = false;
                }

                model.PreviousQuestion = model.CurrentQuestion;
                model.PreviousGivenAnswer = answer;
                model.PreviousCorrectAnswer = currentQuestion.CorrectAnswer;

                if (model.AnsweredQuestions == null)
                {
                    model.AnsweredQuestions = new List<int>();
                }

                model.AnsweredQuestions.Add(model.CurrentQuestionId);
            }

            model.CurrentQuestionNr += 1;

            var nextQuestion = rep.GetRandomQuestion(model.AnsweredQuestions,model.CategoryId);

            model.CurrentQuestion = nextQuestion.Question;
            model.CurrentQuestionId = nextQuestion.Id;
            model.Answers = nextQuestion.Answers.Select(q => q.Answer).ToList();

            return model;
        }

        public ActionResult Result(QuizResultViewmodel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult Result(QuizResultViewmodel model, string nickname)
        {
            var highscore = new QuizHighscore() { CategoryId = model.CategoryId, DateTime = DateTime.Now, Name = nickname, Score = model.Score };
            rep.CreateHighscore(highscore);

            return RedirectToAction("Highscore", new { categoryId = model.CategoryId });
            //return View();
        }

        public ActionResult Highscore(int? categoryId)
        {
            var model = rep.GetHighscores()
                .Where(q => categoryId == null || q.CategoryId == categoryId)
                .OrderByDescending(q => q.Score)
                .ThenByDescending(q => q.DateTime)
                .Take(10);

            ViewBag.Category = model.FirstOrDefault() != null ? categoryId == null ? "All Categories" : model.First().Category.Category : "No highscores found!";
            return View(model);
        }

        // GET: QuizGame
        public ActionResult Index()
        {
            //var quizQuestions = db.QuizQuestions.Include(q => q.Category).Include(q => q.CorrectAnswer);
            //return View(quizQuestions.ToList());

            return View();
        }

        //// GET: QuizGame/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    QuizQuestion quizQuestion = db.QuizQuestions.Find(id);
        //    if (quizQuestion == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(quizQuestion);
        //}

        //// GET: QuizGame/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CategoryId = new SelectList(db.QuizCategories, "Id", "Category");
        //    ViewBag.CorrectAnswerId = new SelectList(db.QuizAnswers, "Id", "Answer");
        //    return View();
        //}

        //// POST: QuizGame/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Question,CorrectAnswerId,CategoryId")] QuizQuestion quizQuestion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.QuizQuestions.Add(quizQuestion);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoryId = new SelectList(db.QuizCategories, "Id", "Category", quizQuestion.CategoryId);
        //    ViewBag.CorrectAnswerId = new SelectList(db.QuizAnswers, "Id", "Answer", quizQuestion.CorrectAnswerId);
        //    return View(quizQuestion);
        //}

        //// GET: QuizGame/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    QuizQuestion quizQuestion = db.QuizQuestions.Find(id);
        //    if (quizQuestion == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CategoryId = new SelectList(db.QuizCategories, "Id", "Category", quizQuestion.CategoryId);
        //    ViewBag.CorrectAnswerId = new SelectList(db.QuizAnswers, "Id", "Answer", quizQuestion.CorrectAnswerId);
        //    return View(quizQuestion);
        //}

        //// POST: QuizGame/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Question,CorrectAnswerId,CategoryId")] QuizQuestion quizQuestion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(quizQuestion).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CategoryId = new SelectList(db.QuizCategories, "Id", "Category", quizQuestion.CategoryId);
        //    ViewBag.CorrectAnswerId = new SelectList(db.QuizAnswers, "Id", "Answer", quizQuestion.CorrectAnswerId);
        //    return View(quizQuestion);
        //}

        //// GET: QuizGame/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    QuizQuestion quizQuestion = db.QuizQuestions.Find(id);
        //    if (quizQuestion == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(quizQuestion);
        //}

        //// POST: QuizGame/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    QuizQuestion quizQuestion = db.QuizQuestions.Find(id);
        //    db.QuizQuestions.Remove(quizQuestion);
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
