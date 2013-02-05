using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Quiz.Domain;

namespace Quiz.Web.Infrastructure
{
    public class QuizContext : DbContext, IQuizDataSource
    {
        public QuizContext() : base("OneDBToRuleThemAll")
        {
            
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        void IQuizDataSource.Save()
        {
            SaveChanges();
        }

        public void Add(Question question)
        {
            Questions.Add(question);
        }

        public void Add(Answer answer)
        {
            Answers.Add(answer);
        }

        public void Update(Question question)
        {
            var currentQuestion = Questions.Find(question.Id);
            Entry(currentQuestion).CurrentValues.SetValues(question);

            foreach (var answer in question.PossibleAnswers)
            {
                var currentAnswer = Answers.Find(answer.Id);
                Entry(currentAnswer).CurrentValues.SetValues(answer);
            }
        }

        public void Delete(int questionId)
        {
            throw new NotImplementedException("Delete");
            //var question = Questions.Single(q => q.Id == questionId);
            //Questions.Remove(question);

            //var currentQuestion = Questions.Find(questionId);
            //Entry(currentQuestion).State = EntityState.Deleted;

        }
        
        IQueryable<Question> IQuizDataSource.Questions
        {
            get { return Questions; }
        }

        IQueryable<Answer> IQuizDataSource.Answers
        {
            get { return Answers; }
        }
    }
}
