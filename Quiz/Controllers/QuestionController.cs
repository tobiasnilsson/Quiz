using System.Data.Entity;
using System.Linq;
using Quiz.Domain;
using System.Collections.Generic;
using System.Web.Mvc;
using Quiz.Web.Models;
using System;

namespace Quiz.Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuizDataSource _quizContext;

        public QuestionController(IQuizDataSource quizContext)
        {
            _quizContext = quizContext;
        }

        //
        // GET: /Question/

        public ActionResult Index()
        {
            var allQuestions = _quizContext.Questions;

            return View(allQuestions);
        }

        //
        // GET: /Question/Details/5
        public ActionResult Details(int id)
        {
            var question = _quizContext.Questions
                                       .Include(q => q.PossibleAnswers)
                                       .Single(q => q.Id.Equals(id));

            var questionViewModel = new CreateQuestionViewModel
                {
                    CorrectAnswer = new CreateAnswerViewModel
                        {
                            Id = question.CorrectAnswer.Id,
                            Text = question.CorrectAnswer.Text
                        },
                    FaultyAnswers = question.PossibleAnswers
                        .Where(a => a.Id != question.CorrectAnswer.Id)
                        .Select(a => new CreateAnswerViewModel { Id = a.Id, Text = a.Text })
                        .ToList(),
                    Text = question.Text
                };

            return View(questionViewModel);
        }

        //
        // GET: /Question/Create
        public ActionResult Create()
        {
            return View(new CreateQuestionViewModel());
        }

        //
        // POST: /Question/Create
        [HttpPost]
        public ActionResult Create(CreateQuestionViewModel questionViewModel)
        {
            if (!ModelState.IsValid)
                return View(questionViewModel);

            var correctAnswer = new Answer { Text = questionViewModel.CorrectAnswer.Text };
            var possibleAnswers = new List<Answer>(questionViewModel.FaultyAnswers.Select(a =>
                                                                                          new Answer { Text = a.Text }))
                {
                    correctAnswer
                };

            // Step 1 - sätt in alla svar
            possibleAnswers.ForEach(a => _quizContext.Add(a));
            _quizContext.Save();

            var question = new Question
                {
                    CorrectAnswer = correctAnswer,
                    PossibleAnswers = possibleAnswers,
                    Text = questionViewModel.Text,
                    UpdateStamp = DateTime.Now
                };

            _quizContext.Add(question);

            try
            {
                _quizContext.Save();
            }
            catch (Exception e)
            {
                return View(questionViewModel);
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Question/Edit/5

        public ActionResult Edit(int id)
        {
            var question = _quizContext.Questions.Single(q => q.Id.Equals(id));

            var questionViewModel = new CreateQuestionViewModel
            {
                CorrectAnswer = new CreateAnswerViewModel
                    {
                        Text = question.CorrectAnswer.Text,
                        Id = question.CorrectAnswer.Id
                    },
                FaultyAnswers = question.PossibleAnswers
                    .Where(a => a.Id != question.CorrectAnswer.Id)
                    .Select(a => new CreateAnswerViewModel { Id = a.Id, Text = a.Text })
                    .ToList(),
                Text = question.Text
            };

            return View(questionViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CreateQuestionViewModel questionViewModel)
        {
            if (!ModelState.IsValid)
                return View("Edit", questionViewModel);

            var possibleAnswers = questionViewModel.FaultyAnswers
                                                   .Select(a =>
                                                       new Answer { Id = a.Id, Text = a.Text }).ToList();

            possibleAnswers.Add(
                new Answer
                {
                    Id = questionViewModel.CorrectAnswer.Id,
                    Text = questionViewModel.CorrectAnswer.Text
                });

            var question = new Question
                {
                    CorrectAnswer = new Answer
                        {
                            Id = questionViewModel.CorrectAnswer.Id,
                            Text = questionViewModel.CorrectAnswer.Text
                        },
                    Id = questionViewModel.Id,
                    PossibleAnswers = possibleAnswers,
                    Text = questionViewModel.Text,
                    UpdateStamp = DateTime.Now
                };

            _quizContext.Update(question);

            try
            {
                _quizContext.Save();
            }
            catch (Exception e)
            {
                return View("Edit", questionViewModel);
            }

            return RedirectToAction("Index");

        }

        //
        // DELETE: /Question/Delete/5
        [HttpDelete]
        public void Delete(int id)
        {
            _quizContext.Delete(id);

            try
            {
                _quizContext.Save();
            }
            catch (Exception e)
            {
                //Log?
            }

        }
    }
}
