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
    public class CompetencyQuestionsController : Controller
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        // GET: CompetencyQuestions
        public ActionResult Index()
        {
            var competencyQuestions = db.CompetencyQuestions.Include(c => c.CompetencyCategory).Include(c => c.Project).Include(c => c.CompetencySubCategory);
            return View(competencyQuestions.ToList());
        }

        // GET: CompetencyQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyQuestion competencyQuestion = db.CompetencyQuestions.Find(id);
            if (competencyQuestion == null)
            {
                return HttpNotFound();
            }
            return View(competencyQuestion);
        }

        // GET: CompetencyQuestions/Create
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.SubCategory_ID = new SelectList(db.CompetencySubCategories, "SubCategory_ID", "SubCategory_Name");
            return View();
        }

        // POST: CompetencyQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionID,QuestionText,QuestionExplanation,ProjectID,Category_ID,SubCategory_ID,InsertedBy,InsertedDate,ModifiedBy,ModifiedDate,IsValid")] CompetencyQuestion competencyQuestion)
        {
            if (ModelState.IsValid)
            {
                db.CompetencyQuestions.Add(competencyQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_ID = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName", competencyQuestion.Category_ID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", competencyQuestion.ProjectID);
            ViewBag.SubCategory_ID = new SelectList(db.CompetencySubCategories, "SubCategory_ID", "SubCategory_Name", competencyQuestion.SubCategory_ID);
            return View(competencyQuestion);
        }

        // GET: CompetencyQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyQuestion competencyQuestion = db.CompetencyQuestions.Find(id);
            if (competencyQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_ID = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName", competencyQuestion.Category_ID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", competencyQuestion.ProjectID);
            ViewBag.SubCategory_ID = new SelectList(db.CompetencySubCategories, "SubCategory_ID", "SubCategory_Name", competencyQuestion.SubCategory_ID);
            return View(competencyQuestion);
        }

        // POST: CompetencyQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionID,QuestionText,QuestionExplanation,ProjectID,Category_ID,SubCategory_ID,InsertedBy,InsertedDate,ModifiedBy,ModifiedDate,IsValid")] CompetencyQuestion competencyQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competencyQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName", competencyQuestion.Category_ID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", competencyQuestion.ProjectID);
            ViewBag.SubCategory_ID = new SelectList(db.CompetencySubCategories, "SubCategory_ID", "SubCategory_Name", competencyQuestion.SubCategory_ID);
            return View(competencyQuestion);
        }

        // GET: CompetencyQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyQuestion competencyQuestion = db.CompetencyQuestions.Find(id);
            if (competencyQuestion == null)
            {
                return HttpNotFound();
            }
            return View(competencyQuestion);
        }

        // POST: CompetencyQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetencyQuestion competencyQuestion = db.CompetencyQuestions.Find(id);
            db.CompetencyQuestions.Remove(competencyQuestion);
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
