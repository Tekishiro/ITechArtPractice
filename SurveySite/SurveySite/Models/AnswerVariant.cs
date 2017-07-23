using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveySite.Models
{
    public class AnswerVariant
    {
        public int AnswerVariantId { get; set; }
        
        public int QuestionId { get; set; }

        public string Text { get; set; }
    }
}