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
    public class CompetencyLevelsController : Controller
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        // GET: CompetencyLevels
        public ActionResult Index()
        {
            return View(db.CompetencyLevels.ToList());
        }

        // GET: CompetencyLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyLevel competencyLevel = db.CompetencyLevels.Find(id);
            if (competencyLevel == null)
            {
                return HttpNotFound();
            }
            return View(competencyLevel);
        }

        // GET: CompetencyLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompetencyLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Level_ID,Level_Name,InsertedBy,InsterDate")] CompetencyLevel competencyLevel)
        {
            if (ModelState.IsValid)
            {
                db.CompetencyLevels.Add(competencyLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competencyLevel);
        }

        // GET: CompetencyLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyLevel competencyLevel = db.CompetencyLevels.Find(id);
            if (competencyLevel == null)
            {
                return HttpNotFound();
            }
            return View(competencyLevel);
        }

        // POST: CompetencyLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Level_ID,Level_Name,InsertedBy,InsterDate")] CompetencyLevel competencyLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competencyLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competencyLevel);
        }

        // GET: CompetencyLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyLevel competencyLevel = db.CompetencyLevels.Find(id);
            if (competencyLevel == null)
            {
                return HttpNotFound();
            }
            return View(competencyLevel);
        }

        // POST: CompetencyLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetencyLevel competencyLevel = db.CompetencyLevels.Find(id);
            db.CompetencyLevels.Remove(competencyLevel);
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
