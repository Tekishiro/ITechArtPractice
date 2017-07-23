using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SurveySite.Models
{
    public class SurveySiteEntities: DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerVariant> AnswerVariants { get; set; }

        public DbSet<Answer> Answers { get; set; }
    }
}