using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SurveySite.Models;

namespace SurveySite.ViewModels
{
    public class Survey
    {
        public Question SurveyQuestion { get; set; }
        public List<AnswerVariant> SurveyAnswers { get; set; }

        public int ChoosenAnswer { get; set; }
        public int QuestId { get; set; }
        
        public List<Answer> Answers { get; set; }
    }
}