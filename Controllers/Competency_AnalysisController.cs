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
    public class Competency_AnalysisController : Controller
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        // GET: Competency_Analysis
        public ActionResult Index()
        {
           // var competency_Analysis = db.Competency_Analysis.Include(c => c.CompetencyCategory).Include(c => c.CompetencyQuestion).Include(c => c.User).Include(c => c.FeatureCycle).Include(c => c.Competency_Analysis1).Include(c => c.Competency_Analysis2).Include(c => c.CompetencyLevel).Include(c => c.Project).Include(c => c.CompetencySubCategory);

            var competency_Analysis = db.Competency_Analysis.Include(c => c.CompetencyCategory).Include(c => c.CompetencyQuestion).Include(c => c.User).Include(c => c.FeatureCycle).Include(c => c.CompetencyLevel).Include(c => c.Project).Include(c => c.CompetencySubCategory);
            return View(competency_Analysis.ToList());
        }

        // GET: Competency_Analysis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency_Analysis competency_Analysis = db.Competency_Analysis.Find(id);
            if (competency_Analysis == null)
            {
                return HttpNotFound();
            }
            return View(competency_Analysis);
        }

        // GET: Competency_Analysis/Create
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName");
            ViewBag.QuestionID = new SelectList(db.CompetencyQuestions, "QuestionID", "QuestionText");
            ViewBag.UserId = new SelectList(db.Users, "UserID", "UserName");
            ViewBag.FeatureCycle_ID = new SelectList(db.FeatureCycles, "FeatureCycle_ID", "FeatureCycle_Name");
            ViewBag.CompetencyID = new SelectList(db.Competency_Analysis, "CompetencyID", "InsertedBy");
            ViewBag.CompetencyID = new SelectList(db.Competency_Analysis, "CompetencyID", "InsertedBy");
            ViewBag.Level_ID = new SelectList(db.CompetencyLevels, "Level_ID", "Level_Name");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.SubCategoryID = new SelectList(db.CompetencySubCategories, "SubCategory_ID", "SubCategory_Name");
            return View();
        }

        // POST: Competency_Analysis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetencyID,UserId,ProjectID,FeatureCycle_ID,QuestionID,Category_ID,SubCategoryID,Level_ID,Base_Value,Goal,InsertedBy,InsertedDate,ModifiedBy,ModifiedDate,IsValid")] Competency_Analysis competency_Analysis)
        {
            if (ModelState.IsValid)
            {
                db.Competency_Analysis.Add(competency_Analysis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_ID = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName", competency_Analysis.Category_ID);
            ViewBag.QuestionID = new SelectList(db.CompetencyQuestions, "QuestionID", "QuestionText", competency_Analysis.QuestionID);
            ViewBag.UserId = new SelectList(db.Users, "UserID", "UserName", competency_Analysis.UserId);
            ViewBag.FeatureCycle_ID = new SelectList(db.FeatureCycles, "FeatureCycle_ID", "FeatureCycle_Name", competency_Analysis.FeatureCycle_ID);
            ViewBag.CompetencyID = new SelectList(db.Competency_Analysis, "CompetencyID", "InsertedBy", competency_Analysis.CompetencyID);
            ViewBag.CompetencyID = new SelectList(db.Competency_Analysis, "CompetencyID", "InsertedBy", competency_Analysis.CompetencyID);
            ViewBag.Level_ID = new SelectList(db.CompetencyLevels, "Level_ID", "Level_Name", competency_Analysis.Level_ID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", competency_Analysis.ProjectID);
            ViewBag.SubCategoryID = new SelectList(db.CompetencySubCategories, "SubCategory_ID", "SubCategory_Name", competency_Analysis.SubCategoryID);
            return View(competency_Analysis);
        }

        // GET: Competency_Analysis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency_Analysis competency_Analysis = db.Competency_Analysis.Find(id);
            if (competency_Analysis == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_ID = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName", competency_Analysis.Category_ID);
            ViewBag.QuestionID = new SelectList(db.CompetencyQuestions, "QuestionID", "QuestionText", competency_Analysis.QuestionID);
            ViewBag.UserId = new SelectList(db.Users, "UserID", "UserName", competency_Analysis.UserId);
            ViewBag.FeatureCycle_ID = new SelectList(db.FeatureCycles, "FeatureCycle_ID", "FeatureCycle_Name", competency_Analysis.FeatureCycle_ID);
            ViewBag.CompetencyID = new SelectList(db.Competency_Analysis, "CompetencyID", "InsertedBy", competency_Analysis.CompetencyID);
            ViewBag.CompetencyID = new SelectList(db.Competency_Analysis, "CompetencyID", "InsertedBy", competency_Analysis.CompetencyID);
            ViewBag.Level_ID = new SelectList(db.CompetencyLevels, "Level_ID", "Level_Name", competency_Analysis.Level_ID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", competency_Analysis.ProjectID);
            ViewBag.SubCategoryID = new SelectList(db.CompetencySubCategories, "SubCategory_ID", "SubCategory_Name", competency_Analysis.SubCategoryID);
            return View(competency_Analysis);
        }

        // POST: Competency_Analysis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetencyID,UserId,ProjectID,FeatureCycle_ID,QuestionID,Category_ID,SubCategoryID,Level_ID,Base_Value,Goal,InsertedBy,InsertedDate,ModifiedBy,ModifiedDate,IsValid")] Competency_Analysis competency_Analysis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competency_Analysis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName", competency_Analysis.Category_ID);
            ViewBag.QuestionID = new SelectList(db.CompetencyQuestions, "QuestionID", "QuestionText", competency_Analysis.QuestionID);
            ViewBag.UserId = new SelectList(db.Users, "UserID", "UserName", competency_Analysis.UserId);
            ViewBag.FeatureCycle_ID = new SelectList(db.FeatureCycles, "FeatureCycle_ID", "FeatureCycle_Name", competency_Analysis.FeatureCycle_ID);
            ViewBag.CompetencyID = new SelectList(db.Competency_Analysis, "CompetencyID", "InsertedBy", competency_Analysis.CompetencyID);
            ViewBag.CompetencyID = new SelectList(db.Competency_Analysis, "CompetencyID", "InsertedBy", competency_Analysis.CompetencyID);
            ViewBag.Level_ID = new SelectList(db.CompetencyLevels, "Level_ID", "Level_Name", competency_Analysis.Level_ID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", competency_Analysis.ProjectID);
            ViewBag.SubCategoryID = new SelectList(db.CompetencySubCategories, "SubCategory_ID", "SubCategory_Name", competency_Analysis.SubCategoryID);
            return View(competency_Analysis);
        }

        // GET: Competency_Analysis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency_Analysis competency_Analysis = db.Competency_Analysis.Find(id);
            if (competency_Analysis == null)
            {
                return HttpNotFound();
            }
            return View(competency_Analysis);
        }

        // POST: Competency_Analysis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competency_Analysis competency_Analysis = db.Competency_Analysis.Find(id);
            db.Competency_Analysis.Remove(competency_Analysis);
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
