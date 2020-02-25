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
    public class CompetencyCategoriesController : Controller
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        // GET: CompetencyCategories
        public ActionResult Index()
        {
            return View(db.CompetencyCategories.ToList());
        }

        // GET: CompetencyCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyCategory competencyCategory = db.CompetencyCategories.Find(id);
            if (competencyCategory == null)
            {
                return HttpNotFound();
            }
            return View(competencyCategory);
        }

        // GET: CompetencyCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompetencyCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category_ID,CategoryName,Inserted_By,Inserted_Date")] CompetencyCategory competencyCategory)
        {
            if (ModelState.IsValid)
            {
                db.CompetencyCategories.Add(competencyCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competencyCategory);
        }

        // GET: CompetencyCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyCategory competencyCategory = db.CompetencyCategories.Find(id);
            if (competencyCategory == null)
            {
                return HttpNotFound();
            }
            return View(competencyCategory);
        }

        // POST: CompetencyCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Category_ID,CategoryName,Inserted_By,Inserted_Date")] CompetencyCategory competencyCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competencyCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competencyCategory);
        }

        // GET: CompetencyCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyCategory competencyCategory = db.CompetencyCategories.Find(id);
            if (competencyCategory == null)
            {
                return HttpNotFound();
            }
            return View(competencyCategory);
        }

        // POST: CompetencyCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetencyCategory competencyCategory = db.CompetencyCategories.Find(id);
            db.CompetencyCategories.Remove(competencyCategory);
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
