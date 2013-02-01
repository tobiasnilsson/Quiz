using System.Linq;

namespace Quiz.Domain
{
    public interface IQuestionDataSource
    {
        IQueryable<Question> Questions { get; set; }
        IQueryable<Answer> Answers { get; set; } 
    }
}
