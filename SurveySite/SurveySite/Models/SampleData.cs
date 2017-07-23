using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SurveySite.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<SurveySiteEntities>
    {
        protected override void Seed(SurveySiteEntities context)
        {
            var questions = new List<Question>
            {
                new Question { Text = "Test question 1" },
                new Question { Text = "Test question 2" },
                new Question { Text = "Test question 3" }
            };
            questions.ForEach(s => context.Questions.Add(s));
            context.SaveChanges();

            var answervariants = new List<AnswerVariant>
            {
                new AnswerVariant { QuestionId = 1, Text = "1 answer for 1 survey" },
                new AnswerVariant { QuestionId = 1, Text = "2 answer for 1 survey" },
                new AnswerVariant { QuestionId = 2, Text = "1 answer for 2 survey" },
                new AnswerVariant { QuestionId = 2, Text = "2 answer for 2 survey" },
                new AnswerVariant { QuestionId = 3, Text = "1 answer for 3 survey" },
                new AnswerVariant { QuestionId = 3, Text = "2 answer for 3 survey" },
                new AnswerVariant { QuestionId = 3, Text = "3 answer for 3 survey" },
            };
            answervariants.ForEach(s => context.AnswerVariants.Add(s));
            context.SaveChanges();

        }
    }
}