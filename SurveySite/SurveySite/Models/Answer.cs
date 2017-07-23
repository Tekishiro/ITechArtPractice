using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveySite.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }
        public int AnswerVariantId { get; set; }
        public string Username { get; set; }
    }
}