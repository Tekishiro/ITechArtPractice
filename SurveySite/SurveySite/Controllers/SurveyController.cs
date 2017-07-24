using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurveySite.Models;
using SurveySite.ViewModels;
using PagedList;

namespace SurveySite.Controllers
{
    [Authorize(Roles = "User, Administrator")]
    public class SurveyController : Controller
    {

        SurveySiteEntities surveyDb = new SurveySiteEntities();

        //List of surveys, divided into pages
        // GET: Survey
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            List<Question> questions = surveyDb.Questions.ToList();
            
            return View(questions.ToPagedList(pageNumber, pageSize));
        }
        

 
        public ActionResult Details(int? id)
        {
            //if request is incorrect
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = surveyDb.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }


            //searching for answers - if user already passed this survey
            List<AnswerVariant> answervariants;
            Answer userAnswer = surveyDb.Answers.SingleOrDefault(a => a.QuestionId == id && a.Username == User.Identity.Name);

            //if not - sending to view list of answers
            if(userAnswer == null)
            {
                answervariants = surveyDb.AnswerVariants.Where
                                            (a => a.QuestionId == id).ToList();
            }
            //if user passed this survey already - sending choosen answer to view
            else
            {
                answervariants = surveyDb.AnswerVariants.Where(a => a.AnswerVariantId == userAnswer.AnswerVariantId).ToList();
            }
            
            var survey = new Survey {
                SurveyQuestion = surveyDb.Questions.Single(q => q.QuestionId == id),
                SurveyAnswers = answervariants };

            return View(survey);
        }


        [HttpPost]
        public ActionResult Details(Survey answeredSurvey)
        {
            int questId = answeredSurvey.QuestId;

            //just in case if user hasn't choose answer
            try
            {
                int id = answeredSurvey.ChoosenAnswer;
                Answer choosenAnswer = new Answer { AnswerVariantId = id,
                    QuestionId = questId, Username = User.Identity.Name };
                surveyDb.Answers.Add(choosenAnswer);
                surveyDb.SaveChanges();
            }
            catch
            {
                //return error status code
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //else - return to survey page
            //should view just choosen answer
            return RedirectToAction("Details", new { id = questId });
        }
    }
}