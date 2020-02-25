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
    public class CompetencySubCategoriesController : Controller
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        // GET: CompetencySubCategories
        public ActionResult Index()
        {
            var competencySubCategories = db.CompetencySubCategories.Include(c => c.CompetencyCategory);
            return View(competencySubCategories.ToList());
        }

        // GET: CompetencySubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencySubCategory competencySubCategory = db.CompetencySubCategories.Find(id);
            if (competencySubCategory == null)
            {
                return HttpNotFound();
            }
            return View(competencySubCategory);
        }

        // GET: CompetencySubCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName");
            return View();
        }

        // POST: CompetencySubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubCategory_ID,SubCategory_Name,CategoryID,Inserted_By,Inserted_Date")] CompetencySubCategory competencySubCategory)
        {
            if (ModelState.IsValid)
            {
                db.CompetencySubCategories.Add(competencySubCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName", competencySubCategory.CategoryID);
            return View(competencySubCategory);
        }

        // GET: CompetencySubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencySubCategory competencySubCategory = db.CompetencySubCategories.Find(id);
            if (competencySubCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName", competencySubCategory.CategoryID);
            return View(competencySubCategory);
        }

        // POST: CompetencySubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubCategory_ID,SubCategory_Name,CategoryID,Inserted_By,Inserted_Date")] CompetencySubCategory competencySubCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competencySubCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.CompetencyCategories, "Category_ID", "CategoryName", competencySubCategory.CategoryID);
            return View(competencySubCategory);
        }

        // GET: CompetencySubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencySubCategory competencySubCategory = db.CompetencySubCategories.Find(id);
            if (competencySubCategory == null)
            {
                return HttpNotFound();
            }
            return View(competencySubCategory);
        }

        // POST: CompetencySubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetencySubCategory competencySubCategory = db.CompetencySubCategories.Find(id);
            db.CompetencySubCategories.Remove(competencySubCategory);
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
