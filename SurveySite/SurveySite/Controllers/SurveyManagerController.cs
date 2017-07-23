using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurveySite.Models;
using SurveySite.ViewModels;

namespace SurveySite.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SurveyManagerController : Controller
    {
        private SurveySiteEntities db = new SurveySiteEntities();


        // GET: SurveyManager
        public ActionResult Index()
        {
            return View(db.Questions.ToList());
        }


        // GET: SurveyManager/Details/5
        public ActionResult Details(int? id)
        {
            //if request is incorrect
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }



            List<AnswerVariant> answervariants = db.AnswerVariants.Where
                                            (a => a.QuestionId == id).ToList();

            List<Answer> answers = db.Answers.Where(a => a.QuestionId == id).ToList();
            var survey = new Survey
            {
                SurveyQuestion = db.Questions.Single(q => q.QuestionId == id),
                SurveyAnswers = answervariants,
                Answers = answers
            };


            return View(survey);
        }


        //clear history of survey
        public ActionResult ClearAnswers(int? id)
        {
            //if request is incorrect
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }


            List<Answer> deletedAnswers = db.Answers.Where(a => a.QuestionId == id).ToList();
            foreach(Answer answ in deletedAnswers)
            {
                db.Answers.Remove(answ);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        // GET: SurveyManager/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: SurveyManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(FormCollection values)
        {
            var survey = new SurveyCreate();
            TryUpdateModel(survey);

            try
            {
                Question newQuestion = new Question();
                newQuestion.Text = survey.QuestionText;

                db.Questions.Add(newQuestion);
                db.SaveChanges();


                //костыли
                int newQestId = db.Questions.Single(q => q.Text == survey.QuestionText).QuestionId;

                AnswerVariant newAW = new AnswerVariant { QuestionId = newQestId,  Text = survey.AnsverVariant1};
                db.AnswerVariants.Add(newAW); db.SaveChanges();
                newAW.Text = survey.AnsverVariant2;
                db.AnswerVariants.Add(newAW); db.SaveChanges();


                if (!String.IsNullOrEmpty(survey.AnsverVariant3)
                    && !String.IsNullOrWhiteSpace(survey.AnsverVariant3))
                {
                    newAW.Text = survey.AnsverVariant3;
                    db.AnswerVariants.Add(newAW); db.SaveChanges();
                }

                if (!String.IsNullOrEmpty(survey.AnsverVariant4)
                    && !String.IsNullOrWhiteSpace(survey.AnsverVariant4))
                {
                    newAW.Text = survey.AnsverVariant4;
                    db.AnswerVariants.Add(newAW); db.SaveChanges();
                }

                if (!String.IsNullOrEmpty(survey.AnsverVariant5)
                    && !String.IsNullOrWhiteSpace(survey.AnsverVariant5))
                {
                    newAW.Text = survey.AnsverVariant5;
                    db.AnswerVariants.Add(newAW); db.SaveChanges();
                }

                if (!String.IsNullOrEmpty(survey.AnsverVariant6)
                    && !String.IsNullOrWhiteSpace(survey.AnsverVariant6))
                {
                    newAW.Text = survey.AnsverVariant6;
                    db.AnswerVariants.Add(newAW); db.SaveChanges();
                }

                if (!String.IsNullOrEmpty(survey.AnsverVariant7)
                    && !String.IsNullOrWhiteSpace(survey.AnsverVariant7))
                {
                    newAW.Text = survey.AnsverVariant7;
                    db.AnswerVariants.Add(newAW); db.SaveChanges();
                }

                if (!String.IsNullOrEmpty(survey.AnsverVariant8)
                    && !String.IsNullOrWhiteSpace(survey.AnsverVariant8))
                {
                    newAW.Text = survey.AnsverVariant8;
                    db.AnswerVariants.Add(newAW); db.SaveChanges();
                }

                if (!String.IsNullOrEmpty(survey.AnsverVariant9)
                    && !String.IsNullOrWhiteSpace(survey.AnsverVariant9))
                {
                    newAW.Text = survey.AnsverVariant9;
                    db.AnswerVariants.Add(newAW); db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(survey);
            }
        }


        // GET: SurveyManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }


        // POST: SurveyManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();


            //deleting answer variants for deleted question
            List<AnswerVariant> answervariants = db.AnswerVariants.Where
                                            (a => a.QuestionId == id).ToList();

            foreach(AnswerVariant deleteAW in answervariants)
            {
                db.AnswerVariants.Remove(deleteAW);
                db.SaveChanges();
            }

            //deleting answers
            ClearAnswers(id);

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
