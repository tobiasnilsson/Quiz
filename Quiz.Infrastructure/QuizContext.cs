using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Domain;

namespace Quiz.Infrastructure
{
    public class QuizContext : DbContext, IQuizDataSource
    {
        public QuizContext() : base("OneDBToRuleThemAll")
        {
            
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

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
