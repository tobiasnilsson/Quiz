﻿using System.Collections.Generic;

namespace Quiz.Domain
{
    public class Question
    {
        public virtual string Text { get; set; }
        public virtual ICollection<Answer> PossibleAnswers { get; set; }
        public virtual Answer CorrectAnswer { get; set; }
    }
}