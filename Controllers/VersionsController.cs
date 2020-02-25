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
    public class VersionsController : Controller
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        // GET: Versions
        public ActionResult Index()
        {
            return View(db.Versions.ToList());
        }

        // GET: Versions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Version version = db.Versions.Find(id);
            if (version == null)
            {
                return HttpNotFound();
            }
            return View(version);
        }

        // GET: Versions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Versions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Version_ID,VersionName")] Models.Version version)
        {
            if (ModelState.IsValid)
            {
                db.Versions.Add(version);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(version);
        }

        // GET: Versions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Version version = db.Versions.Find(id);
            if (version == null)
            {
                return HttpNotFound();
            }
            return View(version);
        }

        // POST: Versions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Version_ID,VersionName")] Models.Version version)
        {
            if (ModelState.IsValid)
            {
                db.Entry(version).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(version);
        }

        // GET: Versions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Version version = db.Versions.Find(id);
            if (version == null)
            {
                return HttpNotFound();
            }
            return View(version);
        }

        // POST: Versions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Version version = db.Versions.Find(id);
            db.Versions.Remove(version);
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
