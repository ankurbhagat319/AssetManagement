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
    public class FeatureCyclesController : Controller
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        // GET: FeatureCycles
        public ActionResult Index()
        {
            var featureCycles = db.FeatureCycles.Include(f => f.Version);
            return View(featureCycles.ToList());
        }

        // GET: FeatureCycles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeatureCycle featureCycle = db.FeatureCycles.Find(id);
            if (featureCycle == null)
            {
                return HttpNotFound();
            }
            return View(featureCycle);
        }

        // GET: FeatureCycles/Create
        public ActionResult Create()
        {
            ViewBag.Version_ID = new SelectList(db.Versions, "Version_ID", "VersionName");
            return View();
        }

        // POST: FeatureCycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeatureCycle_ID,FeatureCycle_Name,Version_ID,StartDate,EndDate,ModifiedBy,ModidfiedDate,IsActive")] FeatureCycle featureCycle)
        {
            if (ModelState.IsValid)
            {
                db.FeatureCycles.Add(featureCycle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Version_ID = new SelectList(db.Versions, "Version_ID", "VersionName", featureCycle.Version_ID);
            return View(featureCycle);
        }

        // GET: FeatureCycles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeatureCycle featureCycle = db.FeatureCycles.Find(id);
            if (featureCycle == null)
            {
                return HttpNotFound();
            }
            ViewBag.Version_ID = new SelectList(db.Versions, "Version_ID", "VersionName", featureCycle.Version_ID);
            return View(featureCycle);
        }

        // POST: FeatureCycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeatureCycle_ID,FeatureCycle_Name,Version_ID,StartDate,EndDate,ModifiedBy,ModidfiedDate,IsActive")] FeatureCycle featureCycle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(featureCycle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Version_ID = new SelectList(db.Versions, "Version_ID", "VersionName", featureCycle.Version_ID);
            return View(featureCycle);
        }

        // GET: FeatureCycles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeatureCycle featureCycle = db.FeatureCycles.Find(id);
            if (featureCycle == null)
            {
                return HttpNotFound();
            }
            return View(featureCycle);
        }

        // POST: FeatureCycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeatureCycle featureCycle = db.FeatureCycles.Find(id);
            db.FeatureCycles.Remove(featureCycle);
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
