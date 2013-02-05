using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Quiz.Domain;
using System.Web.Mvc;

namespace Quiz.Web.Models
{
    public class CreateQuestionViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [Display(Name="Question")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "Faulty answers")]
        public List<CreateAnswerViewModel> FaultyAnswers { get; set; }

        [Required]
        [Display(Name = "Correct answer")]
        public CreateAnswerViewModel CorrectAnswer { get; set; }
    }
}