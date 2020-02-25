using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetManagement.Models;
using System.Web.Security;
using System.Security.Principal;
using System.Web.Routing;

namespace AssetManagement.Controllers
{
    public class AssetDetailsController : Controller
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        public ActionResult GetUserName( int UserID)
        {
        var UserName=    db.Users.Where(x => x.UserID == UserID).Select(x => x.UserName).ToList();
            return Json(UserName.ToArray(), JsonRequestBehavior.AllowGet);
        }
        public static string GetCurrentUser()
        {
            return System.Web.HttpContext.Current.User.Identity.Name;
        }
        public ActionResult Unauthorized()
        {
            return View();
        }
        // GET: AssetDetails
        [Authorize]
        public ActionResult Index()
        {
            //WindowsAuthenticationModule win = new WindowsAuthenticationModule();

            //var username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            ////var Cred = WindowsIdentity.GetCurrent();
            //var Username = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name.Split('\\');

            //var Identity = System.Web.HttpContext.Current.Request.LogonUserIdentity;
            //var Username = Identity.Name.Split('\\');

            var Username = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name.Split('\\');
            var Current_User = Username[1];
  
            var ChekUser = db.Users.Where(x => x.UserName == Current_User).Select(x => x).ToList();

            Session["UserName"] = Current_User;
            if (ChekUser.Count > 0 && ChekUser[0].RoleID == 10)
            {
                Session["DisplayName"] = ChekUser[0].DisplayName;
                Session["RoleId"] = ChekUser[0].RoleID;
                var assetDetails = db.AssetDetails.Include(a => a.Project).Include(a => a.User).Where(x => x.UserName == Current_User);
                return View(assetDetails.ToList());
            }
            else if (ChekUser.Count > 0 && ChekUser[0].RoleID == 8 || ChekUser.Count > 0 && ChekUser[0].RoleID == 9)
            {
                Session["DisplayName"] = ChekUser[0].DisplayName;
                Session["RoleId"] = ChekUser[0].RoleID;
                var assetDetails = db.AssetDetails.Include(a => a.Project).Include(a => a.User);

                return View(assetDetails.ToList());
            }
            else
            {
                Session["DisplayName"] = ChekUser[0].DisplayName;
                Session["RoleId"] = Request.LogonUserIdentity.Name;
                var assetDetails = db.AssetDetails.Include(a => a.Project).Include(a => a.User);

                return View(assetDetails.ToList());
                //return View("~/Views/AssetDetails/Unauthorized.cshtml");
            }
        }

        // GET: AssetDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetDetail assetDetail = db.AssetDetails.Find(id);
            if (assetDetail == null)
            {
                return HttpNotFound();
            }
            return View(assetDetail);
        }

        // GET: AssetDetails/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: AssetDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,UserName,ProjectID,Type,Manufacturer,Resources_Class,Serial_No,HostName,SpiridonNo,Location,PRNO,PONO,WarrantyStartDate,AgeOfAsset,ExpireBy,Owner,RAM,Storage,Processor,CPUClockSpeed,PhysicalCores,NIC_Count,ISActive,ToBeReplaced,Acknowledge")] AssetDetail assetDetail)
        {
            if (ModelState.IsValid)
            {
                db.AssetDetails.Add(assetDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", assetDetail.ProjectID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", assetDetail.UserID);
            return View(assetDetail);
        }

        // GET: AssetDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetDetail assetDetail = db.AssetDetails.Find(id);
            if (assetDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", assetDetail.ProjectID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", assetDetail.UserID);
            return View(assetDetail);
        }

        // POST: AssetDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,UserName,ProjectID,Type,Manufacturer,Resources_Class,Serial_No,HostName,SpiridonNo,Location,PRNO,PONO,WarrantyStartDate,AgeOfAsset,ExpireBy,Owner,RAM,Storage,Processor,CPUClockSpeed,PhysicalCores,NIC_Count,ISActive,ToBeReplaced,Acknowledge")] AssetDetail assetDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", assetDetail.ProjectID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", assetDetail.UserID);
            return View(assetDetail);
        }

        // GET: AssetDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetDetail assetDetail = db.AssetDetails.Find(id);
            if (assetDetail == null)
            {
                return HttpNotFound();
            }
            return View(assetDetail);
        }

        // POST: AssetDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetDetail assetDetail = db.AssetDetails.Find(id);
            db.AssetDetails.Remove(assetDetail);
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
