using Quiz.Domain;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Quiz.Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        //
        // GET: /Question/

        public ActionResult Index()
        {
            var allQuestions = new List<Question>
                {
                    new Question
                    {
                        Id=1,
                        Text = "What animal?",
                        PossibleAnswers = new List<Answer>
                            {
                                new Answer {Text = "cat"},
                                new Answer {Text = "dog"}
                            }
                    },
                    new Question
                    {
                        Id = 2,
                        Text = "What car?",
                        PossibleAnswers = new List<Answer>
                            {
                                new Answer {Text = "Jaguar"},
                                new Answer {Text = "Tata"}
                            }
                    }
                };

            return View(allQuestions);
        }

        //
        // GET: /Question/Details/5
        public ActionResult Details(int id)
        {
            var question = new Question
                {
                    Id = 2,
                    Text = "What car?",
                    PossibleAnswers = new List<Answer>
                        {
                            new Answer {Text = "Jaguar"},
                            new Answer {Text = "Tata"}
                        }
                };

            return View(question);
        }

        //
        // GET: /Question/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Question/Create
        [HttpPost]
        public ActionResult Create(Question question)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Question/Edit/5

        public ActionResult Edit(int id)
        {
            var question = new Question
                {
                    Id = id, 
                    Text = "What up?"
                };

            return View(question);
        }
        
        [HttpDelete]
        public ActionResult Update(Question question)
        {
            //Update question and redirect to listing

            return RedirectToAction("Index");

        }

        //
        // DELETE: /Question/Delete/5
        [HttpDelete]
        public void Delete(int id)
        {
            //Delete question


        }
    }
}
