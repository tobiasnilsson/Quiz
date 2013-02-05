using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Quiz.Web.Models
{
    public class CreateAnswerViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
    }
}