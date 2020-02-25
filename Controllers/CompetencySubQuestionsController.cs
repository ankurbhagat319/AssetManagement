using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetManagement.Models;

namespace AssetManagement.Controllers
{
    public class CompetencySubQuestionsController : Controller
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        // GET: CompetencySubQuestions
        public ActionResult Index()
        {
            var competencySubQuestions = db.CompetencySubQuestions.Include(c => c.CompetencyCategory).Include(c => c.CompetencyLevel).Include(c => c.CompetencyLevel1).Include(c => c.CompetencyQuestion).Include(c => c.CompetencySubCategory).Include(c => c.Project);
            return View(competencySubQuestions.ToList());
        }

        // GET: CompetencySubQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencySubQuestion competencySubQuestion = db.CompetencySubQuestions.Find(id);
            if (competencySubQuestion == null)
            {
                return HttpNotFound();
            }
            return View(competencySubQuestion);
        }

        // GET: CompetencySubQuestions/Create
        public ActionResult Create()
        {
            ViewBag.Category_Id = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName");
            ViewBag.Level_Id = new SelectList(db.CompetencyLevels, "Level_ID", "Level_Name");
            ViewBag.Level_Id = new SelectList(db.CompetencyLevels, "Level_ID", "Level_Name");
            ViewBag.Question_Id = new SelectList(db.CompetencyQuestions, "QuestionID", "QuestionText");
            ViewBag.SubCategory_Id = new SelectList(db.CompetencySubCategories, "SubCategory_ID", "SubCategory_Name");
            ViewBag.Project_Id = new SelectList(db.Projects, "ProjectID", "ProjectName");
            return View();
        }

        // POST: CompetencySubQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubQuestion_ID,Question_Id,Category_Id,SubCategory_Id,SubQuestionText,Project_Id,Level_Id,ModifiedBy,Modified_Date,IsActive,IsChecked")] CompetencySubQuestion competencySubQuestion)
        {
            if (ModelState.IsValid)
            {
                db.CompetencySubQuestions.Add(competencySubQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_Id = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName", competencySubQuestion.Category_Id);
            ViewBag.Level_Id = new SelectList(db.CompetencyLevels, "Level_ID", "Level_Name", competencySubQuestion.Level_Id);
            ViewBag.Level_Id = new SelectList(db.CompetencyLevels, "Level_ID", "Level_Name", competencySubQuestion.Level_Id);
            ViewBag.Question_Id = new SelectList(db.CompetencyQuestions, "QuestionID", "QuestionText", competencySubQuestion.Question_Id);
            ViewBag.SubCategory_Id = new SelectList(db.CompetencySubCategories, "SubCategory_ID", "SubCategory_Name", competencySubQuestion.SubCategory_Id);
            ViewBag.Project_Id = new SelectList(db.Projects, "ProjectID", "ProjectName", competencySubQuestion.Project_Id);
            return View(competencySubQuestion);
        }

        // GET: CompetencySubQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencySubQuestion competencySubQuestion = db.CompetencySubQuestions.Find(id);
            if (competencySubQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Id = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName", competencySubQuestion.Category_Id);
            ViewBag.Level_Id = new SelectList(db.CompetencyLevels, "Level_ID", "Level_Name", competencySubQuestion.Level_Id);
            ViewBag.Level_Id = new SelectList(db.CompetencyLevels, "Level_ID", "Level_Name", competencySubQuestion.Level_Id);
            ViewBag.Question_Id = new SelectList(db.CompetencyQuestions, "QuestionID", "QuestionText", competencySubQuestion.Question_Id);
            ViewBag.SubCategory_Id = new SelectList(db.CompetencySubCategories, "SubCategory_ID", "SubCategory_Name", competencySubQuestion.SubCategory_Id);
            ViewBag.Project_Id = new SelectList(db.Projects, "ProjectID", "ProjectName", competencySubQuestion.Project_Id);
            return View(competencySubQuestion);
        }

        // POST: CompetencySubQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubQuestion_ID,Question_Id,Category_Id,SubCategory_Id,SubQuestionText,Project_Id,Level_Id,ModifiedBy,Modified_Date,IsActive,IsChecked")] CompetencySubQuestion competencySubQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competencySubQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Id = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName", competencySubQuestion.Category_Id);
            ViewBag.Level_Id = new SelectList(db.CompetencyLevels, "Level_ID", "Level_Name", competencySubQuestion.Level_Id);
            ViewBag.Level_Id = new SelectList(db.CompetencyLevels, "Level_ID", "Level_Name", competencySubQuestion.Level_Id);
            ViewBag.Question_Id = new SelectList(db.CompetencyQuestions, "QuestionID", "QuestionText", competencySubQuestion.Question_Id);
            ViewBag.SubCategory_Id = new SelectList(db.CompetencySubCategories, "SubCategory_ID", "SubCategory_Name", competencySubQuestion.SubCategory_Id);
            ViewBag.Project_Id = new SelectList(db.Projects, "ProjectID", "ProjectName", competencySubQuestion.Project_Id);
            return View(competencySubQuestion);
        }

        // GET: CompetencySubQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencySubQuestion competencySubQuestion = db.CompetencySubQuestions.Find(id);
            if (competencySubQuestion == null)
            {
                return HttpNotFound();
            }
            return View(competencySubQuestion);
        }

        // POST: CompetencySubQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetencySubQuestion competencySubQuestion = db.CompetencySubQuestions.Find(id);
            db.CompetencySubQuestions.Remove(competencySubQuestion);
            db.SaveChanges();
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
