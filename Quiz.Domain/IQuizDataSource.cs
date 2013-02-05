using System.Data.Entity;
using System.Linq;

namespace Quiz.Domain
{
    public interface IQuizDataSource
    {
        IQueryable<Question> Questions { get; }
        IQueryable<Answer> Answers { get; }

        void Save();

        void Add(Question question);
        void Add(Answer answer);

        void Update(Question question);

        void Delete(int questionId);
    }
}
