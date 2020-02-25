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
    public class ProjectAssetDetailsController : Controller
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        // GET: ProjectAssetDetails
        public ActionResult Index()
        {
            var projectAssetDetails = db.ProjectAssetDetails.Include(p => p.Project).Include(p => p.User);
            return View(projectAssetDetails.ToList());
        }

        // GET: ProjectAssetDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectAssetDetail projectAssetDetail = db.ProjectAssetDetails.Find(id);
            if (projectAssetDetail == null)
            {
                return HttpNotFound();
            }
            return View(projectAssetDetail);
        }

        // GET: ProjectAssetDetails/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: ProjectAssetDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,UserName,ProjectID,Type,Manufacturer,Resources_Class,Serial_No,HostName,SpiridonNo,Location,PRNO,PONO,WarrantyStartDate,AgeOfAsset,ExpireBy,Owner,RAM,Storage,Processor,CPUClockSpeed,PhysicalCores,NIC_Count,ISActive,ToBeReplaced,Acknowledge,ModifiedBy,ModifiedDate")] ProjectAssetDetail projectAssetDetail)
        {
            if (ModelState.IsValid)
            {
                db.ProjectAssetDetails.Add(projectAssetDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectAssetDetail.ProjectID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", projectAssetDetail.UserID);
            return View(projectAssetDetail);
        }

        // GET: ProjectAssetDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectAssetDetail projectAssetDetail = db.ProjectAssetDetails.Find(id);
            if (projectAssetDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectAssetDetail.ProjectID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", projectAssetDetail.UserID);
            return View(projectAssetDetail);
        }

        // POST: ProjectAssetDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,UserName,ProjectID,Type,Manufacturer,Resources_Class,Serial_No,HostName,SpiridonNo,Location,PRNO,PONO,WarrantyStartDate,AgeOfAsset,ExpireBy,Owner,RAM,Storage,Processor,CPUClockSpeed,PhysicalCores,NIC_Count,ISActive,ToBeReplaced,Acknowledge,ModifiedBy,ModifiedDate")] ProjectAssetDetail projectAssetDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectAssetDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectAssetDetail.ProjectID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", projectAssetDetail.UserID);
            return View(projectAssetDetail);
        }

        // GET: ProjectAssetDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectAssetDetail projectAssetDetail = db.ProjectAssetDetails.Find(id);
            if (projectAssetDetail == null)
            {
                return HttpNotFound();
            }
            return View(projectAssetDetail);
        }

        // POST: ProjectAssetDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectAssetDetail projectAssetDetail = db.ProjectAssetDetails.Find(id);
            db.ProjectAssetDetails.Remove(projectAssetDetail);
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
